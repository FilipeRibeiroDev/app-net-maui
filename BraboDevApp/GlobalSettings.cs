using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BraboDevApp
{
    public class GlobalSettings
    {
        public const string DefaultEndpoint = "https://dummyjson.com";
        public string UserEndpoint { get; set; }
        public static GlobalSettings Instance { get; } = new GlobalSettings();

        public GlobalSettings()
        {
            UserEndpoint = $"{DefaultEndpoint}/user";
        }
    }
}
