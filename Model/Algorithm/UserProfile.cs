using Model.Shop;
using System.Collections.Generic;

namespace Model.Algorithm
{
    public class UserProfile
    {
        public Client Client { get; private set; }
        public ICollection<ItemProfile> ItemProfilesOfPurchasedProduct { get; private set; }
        public double[] Preferences { get; set; }
        public double[,] PreferencesMatrix { get; set; }


        public UserProfile(Client client, ICollection<ItemProfile> itemProfilesOfPurchasedProduct, int distinguishingFeatueresNumber)
        {
            Client = client;
            PreferencesMatrix = new double[itemProfilesOfPurchasedProduct.Count, distinguishingFeatueresNumber];
            Preferences = new double[distinguishingFeatueresNumber];
            ItemProfilesOfPurchasedProduct = itemProfilesOfPurchasedProduct;
        }
    }
}
