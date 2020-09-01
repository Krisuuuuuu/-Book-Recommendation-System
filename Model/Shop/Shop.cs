using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Shop
{
    public class Shop
    {
        public string Name { get; set; }
        public ICollection<Client> Clients { get; set; }
        public Warehouse Warehouse { get; set; }

        public Shop(string name)
        {
            Clients = new List<Client>();
            Name = name;
        }
    }
}
