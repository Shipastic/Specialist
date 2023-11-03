namespace Lab_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            static void PrintOneHundredThreadOne()
            {
                for (int i = 1; i <= 100; i++)
                {
                    Console.WriteLine($"threadOne : {i}");
                }
            }

            static void PrintOneHundredThreadTwo(object? par)
            {
                if (par is Thread t)
                {
                    if (t.ThreadState == ThreadState.Unstarted)
                        return;
                    Console.WriteLine($"threadOne state: {t.ThreadState}");
                    t.Join();
                }
                for (int i = 1; i <= 100; i++)
                {
                    Console.WriteLine($"threadTwo : {i}");
                }
            }

            Thread threadOne = new Thread(PrintOneHundredThreadOne);
            Thread threadTwo = new Thread(PrintOneHundredThreadTwo);

            threadOne.Start();
            Thread.Sleep(1000);
            threadTwo.Start(threadOne);
        }
    }
}