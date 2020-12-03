using Content_Based_Filtering.Interfaces;
using Model.Algorithm;
using Model.Shop;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Content_Based_Filtering.Vectorizers
{
    public class UserProfileManager : ICreator<UserProfile, ItemProfile>
    {
        private readonly IFiller<ItemProfile> _matrixManager;
        public UserProfileManager()
        {
            _matrixManager = new MatrixManager();
        }
        public ICollection<UserProfile> CreateProfiles(ICollection<ItemProfile> allItemProfiles, Shop shop)
        {
            ConcurrentBag<UserProfile> userProfiles = new ConcurrentBag<UserProfile>();
            int featuresNumber = GetFeaturesNumber(allItemProfiles.ToArray());
            var clients = shop.Clients;

            Parallel.ForEach(clients, (client) => 
            {
                ICollection<ItemProfile> itemProfilesOfPurchasedProducts = SelectItemProfilesOfPurchasedProduct(allItemProfiles, 
                    client.Orders);

                UserProfile userProfile = new UserProfile(client, itemProfilesOfPurchasedProducts, featuresNumber);

                userProfile.PreferencesMatrix = _matrixManager.Fill(itemProfilesOfPurchasedProducts, 
                    userProfile.PreferencesMatrix);

                userProfile.Preferences = SetUserPreferences(userProfile.PreferencesMatrix, 
                    itemProfilesOfPurchasedProducts.Count, featuresNumber);

                userProfiles.Add(userProfile);
            });

            return userProfiles.ToList();
        }

        private ICollection<ItemProfile> SelectItemProfilesOfPurchasedProduct(ICollection<ItemProfile> allItemProfiles, 
            ICollection<Order> orders)
        {
            ConcurrentBag<ItemProfile> itemProfilesOfPurchasedProduct = new ConcurrentBag<ItemProfile>();

            foreach (Order order in orders)
            {
                Parallel.ForEach(allItemProfiles, (item) => 
                {
                    if (order.Products.Contains(item.Book) && !itemProfilesOfPurchasedProduct.Contains(item))
                    {
                        itemProfilesOfPurchasedProduct.Add(item);
                    }
                });
            }

            return itemProfilesOfPurchasedProduct.ToList();
        }

        private double[] SetUserPreferences(double[,] matrix, int rows, int columns)
        {
            double[] vector = new double[columns];

            for (int i = 0; i < columns; i++)
            {
                double value = 0;

                for (int j = 0; j < rows; j++)
                {
                    value += matrix[j, i];
                    vector[i] = value;
                }
            }

            return vector;
        }

        private int GetFeaturesNumber(ItemProfile[] itemProfiles)
        {
            return itemProfiles[0].DistinguishingFeaturesBinaryRepresentation.Length;
        }
    }
}
