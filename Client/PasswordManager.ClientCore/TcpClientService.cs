using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;

namespace PasswordManager.ClientCore;

public sealed class TcpClientService
{
    private const int Port = 5000;

    public Task<string> LoginAsync(string username, string password) =>
        SendAsync(new TcpRequest("LOGIN", username, "", password));

    public Task<string> RegisterAsync(string username, string email, string password) =>
        SendAsync(new TcpRequest("REGISTER", username, email, password));

    private static async Task<string> SendAsync(TcpRequest request)
    {
        using var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        await socket.ConnectAsync(IPAddress.Loopback, Port, timeout.Token);

        using var stream = new NetworkStream(socket, ownsSocket: false);
        using var writer = new StreamWriter(stream, new UTF8Encoding(false)) { AutoFlush = true };
        using var reader = new StreamReader(stream, Encoding.UTF8);
        await writer.WriteLineAsync(JsonSerializer.Serialize(request));
        string? reply = await reader.ReadLineAsync().WaitAsync(timeout.Token);
        return reply ?? "serverError";
    }
}

public sealed record TcpRequest(string Command, string Username, string Email, string Password);
