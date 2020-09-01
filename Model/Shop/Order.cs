using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Shop
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public ICollection<Book> Products { get; set; }

        public Order(int id, DateTime dateTime)
        {
            Products = new List<Book>();
            Id = id;
            Date = dateTime;
        }
    }
}
