using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Shop
{
    public class Client
    {
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public string FullName
        {
            get
            {
                return Name + " " + Surname;
            }

        }
        public ICollection<Order> Orders { get; private set; }
        public ICollection<Book> AllPurchasedProducts { get; private set; }
        public Client(string name, string surname, ICollection<Order> orders)
        {
            Name = name;
            Surname = surname;
            Orders = orders;
            AllPurchasedProducts = new List<Book>();

            foreach(Order order in Orders)
            {
                foreach(Book book in order.Products)
                {
                    if(!AllPurchasedProducts.Contains(book))
                    {
                        AllPurchasedProducts.Add(book);
                    }
                }
            }
        }

    }
}
