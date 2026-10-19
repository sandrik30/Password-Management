using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Configuration;
using Npgsql;

// PostgreSQL connection string from User Secrets
var configuration = new ConfigurationBuilder()
    .AddUserSecrets<Program>()
    .Build();

string connectionString =
    configuration.GetConnectionString("PostgreSQL")
    ?? throw new Exception("PostgreSQL connection string not found");

// Create TCP Socket
using Socket listener = new Socket(
    AddressFamily.InterNetwork,
    SocketType.Stream,
    ProtocolType.Tcp
);

// Listen only on this computer
listener.Bind(new IPEndPoint(IPAddress.Loopback, 5000));
listener.Listen(10);

Console.WriteLine("TCP Server started on port 5000");

// Accept clients
while (true)
{
    Socket client = await listener.AcceptAsync();

    _ = Task.Run(async () =>
    {
        using (client)
        {
            try
            {
                // Receive the complete request
                using NetworkStream stream = new NetworkStream(
                    client,
                    ownsSocket: false
                );

                using StreamReader reader = new StreamReader(
                    stream,
                    Encoding.UTF8
                );

                using StreamWriter writer = new StreamWriter(
                    stream,
                    new UTF8Encoding(false)
                )
                {
                    AutoFlush = true
                };

                string? requestJson = await reader.ReadLineAsync();

                string response = "invalidRequest";

                if (requestJson != null)
                {
                    TcpRequest? request =
                        JsonSerializer.Deserialize<TcpRequest>(requestJson);

                    if (request != null)
                    {
                        response = await ProcessRequest(request);
                    }
                }

                await writer.WriteLineAsync(response);
            }
            catch (Exception ex)
            {
                Console.WriteLine("TCP error: " + ex.Message);
            }
        }
    });
}

// Process LOGIN and REGISTER
async Task<string> ProcessRequest(TcpRequest request)
{
    if (string.IsNullOrWhiteSpace(request.Username) ||
        string.IsNullOrWhiteSpace(request.Password))
    {
        return "emptyFields";
    }

    if (request.Command == "LOGIN")
    {
        string passwordHash = Convert.ToHexString(
            SHA256.HashData(
                Encoding.UTF8.GetBytes(request.Password)
            )
        );

        await using NpgsqlConnection db =
            new NpgsqlConnection(connectionString);

        await db.OpenAsync();

        string sql =
            "SELECT COUNT(*) FROM users " +
            "WHERE username = @username AND password_hash = @passwordHash";

        await using NpgsqlCommand command =
            new NpgsqlCommand(sql, db);

        command.Parameters.AddWithValue("@username", request.Username);
        command.Parameters.AddWithValue("@passwordHash", passwordHash);

        long count =
            (long)(await command.ExecuteScalarAsync())!;

        return count == 1 ? "loginSuccess" : "invalidLogin";
    }

    if (request.Command == "REGISTER")
    {
        if (string.IsNullOrWhiteSpace(request.Email))
        {
            return "emptyFields";
        }

        await using NpgsqlConnection db =
            new NpgsqlConnection(connectionString);

        await db.OpenAsync();

        string checkSql =
            "SELECT COUNT(*) FROM users " +
            "WHERE username = @username OR email = @email";

        await using NpgsqlCommand checkCommand =
            new NpgsqlCommand(checkSql, db);

        checkCommand.Parameters.AddWithValue(
            "@username",
            request.Username
        );

        checkCommand.Parameters.AddWithValue(
            "@email",
            request.Email
        );

        long count =
            (long)(await checkCommand.ExecuteScalarAsync())!;

        if (count > 0)
        {
            return "userAlreadyExists";
        }

        string passwordHash = Convert.ToHexString(
            SHA256.HashData(
                Encoding.UTF8.GetBytes(request.Password)
            )
        );

        string insertSql =
            "INSERT INTO users (username, email, password_hash) " +
            "VALUES (@username, @email, @passwordHash)";

        await using NpgsqlCommand insertCommand =
            new NpgsqlCommand(insertSql, db);

        insertCommand.Parameters.AddWithValue(
            "@username",
            request.Username
        );

        insertCommand.Parameters.AddWithValue(
            "@email",
            request.Email
        );

        insertCommand.Parameters.AddWithValue(
            "@passwordHash",
            passwordHash
        );

        await insertCommand.ExecuteNonQueryAsync();

        return "accountCreated";
    }

    return "unknownCommand";
}

// Request structure
record TcpRequest(
    string Command,
    string Username,
    string Email,
    string Password
);