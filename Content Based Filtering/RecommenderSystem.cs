using Content_Based_Filtering.Interfaces;
using Content_Based_Filtering.Parsers;
using Content_Based_Filtering.Printers;
using Content_Based_Filtering.Vectorizers;
using Model.Algorithm;
using Model.Shop;
using Resources;
using Resources.DataSources;
using Resources.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Content_Based_Filtering
{
    public class RecommenderSystem : IRecommender
    {
        private readonly IResourcer<Book> _resourceManager;
        private readonly IParser<Book> _bookParser;
        private readonly INormalizer<ItemProfile> _normalizationManager;
        private readonly ICreator<ItemProfile, string> _itemProfilesManager;
        private readonly ICreator<UserProfile, ItemProfile> _userProfilesManager;
        private readonly IVectorizer _tfidfManager;
        private readonly IEvaluator _userPredictionsManager;
        private readonly IPrinter _printer;
        private readonly Stopwatch _stopwatch;
        public Shop Shop { get; private set; }
        public TFIDFRepresentation TFIDFRepresentation { get; private set; }
        public ICollection<string> BookDistinguishingFeatures { get; private set; }
        public ICollection<ItemProfile> ItemProfiles { get; private set; }
        public ICollection<UserProfile> UserProfiles { get; private set; }
        public ICollection<UserPredictions> UsersPredictions { get; private set; }
        public TimeSpan SimulationTime { get; private set; }
        public RecommenderSystem()
        {
            _resourceManager = new ResourceManager();
            _bookParser = new BookParser();
            _itemProfilesManager = new ItemProfileManager();
            _normalizationManager = new NormalizationManager();
            _userProfilesManager = new UserProfileManager();
            _tfidfManager = new TFIDFManager();
            _userPredictionsManager = new UserPredictionsManager();
            _printer = new Printer();
            _stopwatch = new Stopwatch();
        }
        public void Recommend()
        {
            _stopwatch.Start();

            PrepareShop();

            BookDistinguishingFeatures = _bookParser.GetDistinguishingFeatures(Shop.Warehouse.Books);
            ItemProfiles = _itemProfilesManager.CreateProfiles(BookDistinguishingFeatures, Shop);
            ItemProfiles = _normalizationManager.Normalize(ItemProfiles);

            UserProfiles = _userProfilesManager.CreateProfiles(ItemProfiles, Shop);

            TFIDFRepresentation = new TFIDFRepresentation(BookDistinguishingFeatures.Count);
            TFIDFRepresentation.DistinguishingFeaturesDF = _tfidfManager.CalculateDF(ItemProfiles, TFIDFRepresentation);
            TFIDFRepresentation.DistinguishingFeaturesIDF = _tfidfManager.CalculateIDF(TFIDFRepresentation, ItemProfiles.Count);

            ItemProfiles = _tfidfManager.CalculateWeightedScores(TFIDFRepresentation, ItemProfiles);

            UsersPredictions = _userPredictionsManager.CreateUserPredictions(Shop.Clients, UserProfiles, ItemProfiles);
            UsersPredictions = _userPredictionsManager.PrepareResults(UsersPredictions);

            _stopwatch.Stop();
            SimulationTime = _stopwatch.Elapsed;

            _printer.PrintResults(UsersPredictions, 10);
            _printer.PrintSimulationTime(SimulationTime);
            _resourceManager.SaveResults(UsersPredictions);


        }
        private void PrepareShop()
        {
            Warehouse warehouse = new Warehouse();
            warehouse.Books = _resourceManager.ReadSource();
            //warehouse.Books = TestBooksGenerator.GenerateBooks();

            Shop = new Shop("Best Book Shop");
            Shop.Warehouse = warehouse;

            var orders = GenerateOrders(Shop.Warehouse);

            Client client = new Client("Christopher", "Crown", orders);
            Shop.Clients.Add(client);
            //Shop.Clients = TestUsersGenerator.GenerateClients(warehouse.Books);
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

            Book[] tabOfBooks = books.ToArray();
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
