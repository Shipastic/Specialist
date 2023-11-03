using Grpc.Net.Client;

using static GrpcServer.CoursesService;

namespace GrpcClient
{
    internal class Program
    {
        async static Task Main(string[] args)
        {
            using var channel = GrpcChannel.ForAddress("http://localhost:5198");

            var client = new CoursesServiceClient(channel);
            var reply = await client.ListCoursesAsync(new Google.Protobuf.WellKnownTypes.Empty());

            foreach (var c in reply.Courses)
                Console.WriteLine($"{c.Id}.{c.Title} : {c.Duration}");
        }
    }
}