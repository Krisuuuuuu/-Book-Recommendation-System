using Model.Shop;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Algorithm
{
    public class UserPredictions
    {
        public Client Client { get; private set; }
        public UserProfile UserProfile { get; private set; }
        public double[] Predictions { get; set; }
        public IDictionary<Book, double> Results {get; set;}
        public UserPredictions(Client client, UserProfile userProfile)
        {
            Client = client;
            UserProfile = userProfile;
            Results = new Dictionary<Book, double>();
        }
    }
}
