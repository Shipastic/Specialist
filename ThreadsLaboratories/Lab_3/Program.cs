namespace Lab_3
{
    class Sync
    {
        public double x = 1;
        public bool phase = true;
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Sync sync = new Sync();
            new Thread(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    lock (sync)
                    {
                        while (!sync.phase)
                        {
                            Monitor.Wait(sync);
                        }
                        sync.x = Math.Cos(sync.x);
                        Console.Write($"{sync.x} ");
                        sync.phase = !sync.phase;
                        Monitor.Pulse(sync);
                    }
                }
            }).Start();

            new Thread(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    lock (sync)
                    {
                        while (sync.phase)
                        {
                            Monitor.Wait(sync);
                        }
                        sync.x = Math.Acos(sync.x);
                        Console.WriteLine($"{sync.x}");
                        sync.phase = !sync.phase;
                        Monitor.Pulse(sync);
                    }
                }
            }).Start();
        }
    }
}