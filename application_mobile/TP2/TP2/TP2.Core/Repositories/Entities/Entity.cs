
using SQLite;

namespace TP2.Core.Repositories.Entities
{
    public class Entity
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
    }
}