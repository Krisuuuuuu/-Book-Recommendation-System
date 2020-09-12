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
        public ICollection<Order> Orders { get; set; }

        public Client(string name, string surname)
        {
            Orders = new List<Order>();
            Name = name;
            Surname = surname;
        }

    }
}
