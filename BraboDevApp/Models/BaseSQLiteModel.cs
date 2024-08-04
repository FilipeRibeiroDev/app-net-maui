using SQLite;

namespace BraboDevApp.Models
{
    public class BaseSQLiteModel
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
    }
}
