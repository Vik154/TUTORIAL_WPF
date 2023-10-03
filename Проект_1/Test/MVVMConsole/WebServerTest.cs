using WebCV;

namespace MVVMConsole;

internal static class WebServerTest {
    
    public static void Run() {

        var server = new WebServer(8080);
        server.RequestReceived += OnRequestReceived;
        server.Start();
        Console.WriteLine("Сервер запущен");
        Console.ReadLine();
    }

    private static void OnRequestReceived(object? sender, RequestReceiverEventArgs e) {
        var context = e.Context;

        Console.WriteLine($"Connection {context.Request.UserHostAddress}");

        using var writer = new StreamWriter(context.Response.OutputStream);
        writer.WriteLine("Hello from test web server");
    }
}
