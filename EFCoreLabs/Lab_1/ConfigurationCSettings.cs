using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Lab_1
{
    public class ConfigurationCSettings
    {
        public IConfiguration GetConfig()
        {
            IConfiguration config = new ConfigurationBuilder()
                                                               .SetBasePath(Directory.GetCurrentDirectory())
                                                               .AddJsonFile("appsettings.json")
                                                                .Build();
            return config;
        }            
    }
}
