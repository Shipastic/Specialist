using Lab_2.Services;
using Microsoft.Extensions.Configuration;

namespace Lab_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IConfiguration configuration;

            ConfigurationCSettings settings = new ConfigurationCSettings();
            configuration = settings.GetConfig();

            ApplicationContext applicationContext = new ApplicationContext(configuration);

            InitDB initDb = new InitDB(applicationContext);
            initDb.Init();

            StudentInfoService infoService = new StudentInfoService(applicationContext);
            infoService.OutputInfoStudent();
            Console.WriteLine("=====================================");
            Console.WriteLine("Program finished!");
        }
    }
}