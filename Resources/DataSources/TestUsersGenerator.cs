using Model.Shop;
using System;
using System.Collections.Generic;
using System.Text;

namespace Resources.DataSources
{
    public static class TestUsersGenerator
    {
        public static ICollection<Client> GenerateClients()
        {
            ICollection<Client> clients = new List<Client>();
            ICollection<Order> orders = new List<Order>();

            Book book1 = new Book()
            {
                Authors = "Andrzej Sapkowski",
                Title = "The Witcher: Blood of Elves",
                Genres = "Dark Fantasy|Action|Magic|Slav|Fiction|Non-Humans"
            };

            Book book2 = new Book()
            {
                Authors = "John Ronald Reuel Tolkien",
                Title = "The Lord of the Rings: The Return of the King",
                Genres = "Fantasy|Action|Magic|Fiction|Adventure|Non-Humans"
            };

            Order order = new Order(1, DateTime.Now);
            order.Products.Add(book1);
            order.Products.Add(book2);
            orders.Add(order);


            Client client = new Client("Christopher", "Crown");
            client.Orders = orders;

            clients.Add(client);
            return clients;
        }
    }
}
