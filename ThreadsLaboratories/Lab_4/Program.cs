using System.Net;
using System.Net.Sockets;
using System.Text;

const int MAX_CONNECTION_IN_QUEUE = 10;
const int MAX_THREADS = 20;
const int PORT = 2424;

ThreadPool.SetMaxThreads(MAX_THREADS, MAX_THREADS);


IPEndPoint ipPoint = new IPEndPoint(IPAddress.Any, PORT);
using Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
socket.Bind(ipPoint);
socket.Listen(MAX_CONNECTION_IN_QUEUE);
int requestCount = 0;
var sync = new object();

while (true)
{
    Socket clientSocket = socket.Accept();

    _ = Task.Run(() =>
    {
        Console.WriteLine($"Remote client: {clientSocket.RemoteEndPoint} ");
        using var stream = new NetworkStream(clientSocket);
        using var reader = new StreamReader(stream, Encoding.UTF8);
        using var writer = new StreamWriter(stream, Encoding.UTF8);
        string result = reader.ReadLine();
        lock (sync)
        {
            requestCount++;          
        }

        Console.WriteLine($"Received: {result}, Requests: {requestCount}");
        Thread.Sleep(100);

        writer.WriteLine(result.ToUpper());
        writer.Flush();
        clientSocket.Dispose();

    });

}
