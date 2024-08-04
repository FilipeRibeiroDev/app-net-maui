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

        #region Loca Database
        public const string DatabaseFilename = "BraboDevSQLite.db3";

        public const SQLite.SQLiteOpenFlags Flags =
            SQLite.SQLiteOpenFlags.ReadWrite |
            SQLite.SQLiteOpenFlags.Create |
            SQLite.SQLiteOpenFlags.SharedCache;

        public static string DatabasePath =>
            Path.Combine(FileSystem.AppDataDirectory, DatabaseFilename);

        #endregion

        public GlobalSettings()
        {
            UserEndpoint = $"{DefaultEndpoint}/user";
        }
    }
}
