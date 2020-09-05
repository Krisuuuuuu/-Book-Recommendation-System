using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Algorithm
{
    public class UserProfile
    {
        public ICollection<ItemProfile> ItemProfilesOfPurchasedProduct { get; private set; }
        public double[] Preferences { get; set; }
        public double[,] PreferencesMatrix { get; set; }


        public UserProfile(ICollection<ItemProfile> itemProfilesOfPurchasedProduct, int distinguishingFeatueresNumber)
        {
            PreferencesMatrix = new double[itemProfilesOfPurchasedProduct.Count, distinguishingFeatueresNumber];
            Preferences = new double[distinguishingFeatueresNumber];
            ItemProfilesOfPurchasedProduct = itemProfilesOfPurchasedProduct;
        }
    }
}
