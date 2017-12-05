using SQLite;
using System;

namespace TP2.Core.Repositories.Entities
{
    public class Product : Entity
    {
        public string Modal { get; set; }
        [Unique]
        public string SerialNumber { get; set; }
        public DateTime DateProduction { get; set; }
        public string RadioId { get; set; }
        public string Description { get; set; }
        public bool IsInInventory { get; set; } // Pour trier de tout les produitd de ceux qui sont dans l'inventaire
    }
}