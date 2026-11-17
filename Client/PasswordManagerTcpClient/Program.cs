using PasswordManager.ClientCore;

Console.WriteLine("1. Register");
Console.WriteLine("2. Login");
Console.Write("Choose: ");
string? choice = Console.ReadLine();
if (choice != "1" && choice != "2") { Console.WriteLine("Invalid choice"); return; }
Console.Write("Username: ");
string username = Console.ReadLine() ?? "";
string email = "";
if (choice == "1") { Console.Write("Email: "); email = Console.ReadLine() ?? ""; }
Console.Write("Password: ");
string password = Console.ReadLine() ?? "";
try
{
    var tcp = new TcpClientService();
    string reply = choice == "1"
        ? await tcp.RegisterAsync(username, email, password)
        : await tcp.LoginAsync(username, password);
    Console.WriteLine("Server response: " + reply);
}
catch (Exception ex) when (ex is System.Net.Sockets.SocketException or IOException or OperationCanceledException)
{
    Console.WriteLine("TCP connection failed: " + ex.Message);
}
