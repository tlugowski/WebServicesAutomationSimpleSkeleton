using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServiceTests
{
    public class Configuration
    {
        private const string ConfigurationPath = "configuration.json";

        public int WeatherInfo { get; set; }

        public string PageServiceBaseUrl { get; set; }

        public string GetPageByIdPath { get; set; }

        public string PostPageByPath { get; set; }

        public string AuthorizationToken { get; set; }

        internal static Configuration ReadFromFile()
            => JsonConvert.DeserializeObject<Configuration>(File.ReadAllText(ConfigurationPath));
    }
}
