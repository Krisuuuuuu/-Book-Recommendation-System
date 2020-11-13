using System.Collections.Generic;

namespace Model.Shop
{
    public class Warehouse
    {
        public ICollection<Book> Books { get; set; }

        public Warehouse()
        {
            Books = new List<Book>();
        }
    }
}
