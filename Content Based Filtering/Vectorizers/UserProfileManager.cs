using Content_Based_Filtering.Interfaces;
using Model.Algorithm;
using Model.Shop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
            ICollection<UserProfile> userProfiles = new List<UserProfile>();
            int featuresNumber = GetFeaturesNumber(allItemProfiles.ToArray());
            var clients = shop.Clients;
       
            foreach (Client client in clients)
            {
                ICollection<ItemProfile> itemProfilesOfPurchasedProducts = SelectItemProfilesOfPurchasedProduct(allItemProfiles, client.Orders);

                UserProfile userProfile = new UserProfile(itemProfilesOfPurchasedProducts, featuresNumber);

                userProfile.PreferencesMatrix = _matrixManager.Fill(itemProfilesOfPurchasedProducts, userProfile.PreferencesMatrix);

                userProfile.Preferences = SetUserPreferences(userProfile.PreferencesMatrix, itemProfilesOfPurchasedProducts.Count, featuresNumber);

                userProfiles.Add(userProfile);
            }

            return userProfiles;
        }

        private ICollection<ItemProfile> SelectItemProfilesOfPurchasedProduct(ICollection<ItemProfile> allItemProfiles, ICollection<Order> orders)
        {
            ICollection<ItemProfile> itemProfilesOfPurchasedProduct = new List<ItemProfile>();

            foreach (Order order in orders)
            {
                foreach (ItemProfile item in allItemProfiles)
                {
                    
                    if (order.Products.Contains(item.Book) && !itemProfilesOfPurchasedProduct.Contains(item))
                    {
                        itemProfilesOfPurchasedProduct.Add(item);
                        Console.WriteLine("Item: " + item.Book.Title);
                    }
                }

                foreach (Book book in order.Products)
                {
                    Console.WriteLine("Product: " + book.Title);
                }
            }

            ItemProfile[] items = allItemProfiles.ToArray();
            itemProfilesOfPurchasedProduct.Add(items[0]);
            itemProfilesOfPurchasedProduct.Add(items[1]);

            return itemProfilesOfPurchasedProduct;
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
