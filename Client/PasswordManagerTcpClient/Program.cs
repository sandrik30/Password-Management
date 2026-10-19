using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;

Console.WriteLine("1. Register");
Console.WriteLine("2. Login");
Console.Write("Choose: ");

string? choice = Console.ReadLine();

if (choice != "1" && choice != "2")
{
    Console.WriteLine("Invalid choice");
    return;
}

string command = choice == "1" ? "REGISTER" : "LOGIN";

Console.Write("Username: ");
string username = Console.ReadLine() ?? "";

string email = "";

if (command == "REGISTER")
{
    Console.Write("Email: ");
    email = Console.ReadLine() ?? "";
}

Console.Write("Password: ");
string password = Console.ReadLine() ?? "";

var request = new
{
    Command = command,
    Username = username,
    Email = email,
    Password = password
};

string json = JsonSerializer.Serialize(request);

using Socket client = new Socket(
    AddressFamily.InterNetwork,
    SocketType.Stream,
    ProtocolType.Tcp
);

await client.ConnectAsync(IPAddress.Loopback, 5000);

using NetworkStream stream = new NetworkStream(
    client,
    ownsSocket: false
);

using StreamWriter writer = new StreamWriter(
    stream,
    new UTF8Encoding(false)
)
{
    AutoFlush = true
};

using StreamReader reader = new StreamReader(
    stream,
    Encoding.UTF8
);

await writer.WriteLineAsync(json);

string? response = await reader.ReadLineAsync();

Console.WriteLine("Server response: " + response);