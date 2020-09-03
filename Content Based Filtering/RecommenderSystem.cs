using Content_Based_Filtering.Interfaces;
using Content_Based_Filtering.Parsers;
using Content_Based_Filtering.Vectorizers;
using Model.Algorithm;
using Model.Shop;
using Resources;
using Resources.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Content_Based_Filtering
{
    public class RecommenderSystem : IRecommender
    {
        private readonly IResourcer<Book> _resourceManager;
        private readonly IParser<Book> _bookParser;
        private readonly ICreator<ItemProfile, string> _itemProfilesManager;
        public Shop Shop { get; private set; }
        public ICollection<string> BookDistinguishingFeatures { get; private set; }
        public ICollection<ItemProfile> ItemProfiles { get; private set; }
        public RecommenderSystem()
        {
            _resourceManager = new ResourceManager();
            _bookParser = new BookParser();
            _itemProfilesManager = new ItemProfileManager();
        }
        public void Recommend()
        {
            PrepareShop();
            BookDistinguishingFeatures = _bookParser.GetDistinguishingFeatures(Shop.Warehouse.Books);
            ItemProfiles = _itemProfilesManager.CreateProfiles(BookDistinguishingFeatures, Shop);           
        }
        private void PrepareShop()
        {
            Warehouse warehouse = new Warehouse();
            warehouse.Books = _resourceManager.ReadSource();

            Shop = new Shop("Best Book Shop");
            Shop.Warehouse = warehouse;

            Client client = new Client("Christopher", "Crown");
            client.Orders = GenerateOrders(Shop.Warehouse);
            Shop.Clients.Add(client);
        }

        private ICollection<Order> GenerateOrders(Warehouse warehouse)
        {
            ICollection<Order> orders = new List<Order>();

            for (int i = 0; i < 3; i++)
            {
                Order order = new Order(i + 1, DateTime.Now);
                order.Products = PrepareOrderedBooks(warehouse);
                orders.Add(order);
            }

            return orders;
        }

        private ICollection<Book> PrepareOrderedBooks(Warehouse warehouse)
        {
            ICollection<Book> books = warehouse.Books;
            ICollection<Book> orderedBooks = new List<Book>();

            Book[] tabOfBooks = books.ToArray<Book>();
            Random random = new Random();

            for (int i = 0; i < 5; i++)
            {
                int index = random.Next(books.Count);

                Book book = tabOfBooks[index];

                if (orderedBooks.Contains(book))
                {
                    while (orderedBooks.Contains(book))
                    {
                        index = random.Next(books.Count);

                        book = tabOfBooks[index];
                    }

                    orderedBooks.Add(book);
                }
                else
                {
                    orderedBooks.Add(book);
                }
            }

            return orderedBooks;
        }
    }
}
