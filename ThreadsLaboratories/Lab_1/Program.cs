namespace Lab_1
{
    public class ThreadLab
    {
        public int Start { get; init; }
        public int End { get; init; }
        public void PrintDigitsWyaTwo()
        {
            for (int i = Start; i <= End; i++)
            {
                Console.WriteLine($"Create Thread Way 2: {i}");
            }
        }
    }

    record class TwoParamsForThread(int Start, int End);
    internal class Program
    {
        static void Main(string[] args)
        {
            static void PrintDigitsWaiOne(object? prms)
            {

                if (prms is TwoParamsForThread Prms)
                {
                    for (int i = Prms.Start; i <= Prms.End; i++)
                    {

                        Console.WriteLine($"Create Thread Way 1: {i}");

                    }
                }
            }

            Thread threadClass = new Thread
                                    (new ThreadLab()
                                    {
                                        Start = 2,
                                        End = 10,
                                    }
                                    .PrintDigitsWyaTwo);

            Thread threadRecord = new Thread(PrintDigitsWaiOne);

            threadClass.Start();
            threadRecord.Start(new TwoParamsForThread(7, 20));
        }
    }
}