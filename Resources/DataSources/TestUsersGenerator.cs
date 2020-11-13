using Model.Shop;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Resources.DataSources
{
    public static class TestUsersGenerator
    {
        public static ICollection<Client> GenerateClients(ICollection<Book> books)
        {
            ICollection<Client> clients = new List<Client>();
            ICollection<Order> orders = new List<Order>();

            Order order = new Order(1, DateTime.Now);
            order.Products.Add(books.ToArray()[0]);
            order.Products.Add(books.ToArray()[1]);
            orders.Add(order);


            Client client = new Client("Christopher", "Crown", orders);

            clients.Add(client);
            return clients;
        }
    }
}
