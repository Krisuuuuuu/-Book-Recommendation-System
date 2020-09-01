using System;
using System.Collections.Generic;
using System.Text;

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
