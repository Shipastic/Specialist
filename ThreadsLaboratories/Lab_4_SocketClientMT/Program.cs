using System.Net;
using System.Net.Sockets;
using System.Text;

const int CLIENTS = 100;

ThreadPool.SetMinThreads(CLIENTS, CLIENTS);
ThreadPool.SetMaxThreads(CLIENTS, CLIENTS);

Task[] tasks = new Task[CLIENTS];
for (int i = 0; i < tasks.Length; i++)
{
    tasks[i] = new Task(() =>
    {
        try
        {
            using var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect("127.0.0.1", 2424);
            using var stream = new NetworkStream(socket);
            using var reader = new StreamReader(stream, Encoding.UTF8);
            using var writer = new StreamWriter(stream, Encoding.UTF8);

            writer.WriteLine($"Hello from {Thread.CurrentThread.ManagedThreadId}");
            writer.Flush();

            string result = reader.ReadLine();
            Console.WriteLine(result);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    });
}

foreach (Task task in tasks)
{
    task.Start();
}
Task.WaitAll(tasks);