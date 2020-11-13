using Model.Shop;
using System.Collections.Generic;

namespace Model.Algorithm
{
    public class UserPredictions
    {
        public UserProfile UserProfile { get; private set; }
        public double[] Predictions { get; set; }
        public IDictionary<Book, double> Results {get; set;}
        public UserPredictions(UserProfile userProfile)
        {
            UserProfile = userProfile;
            Results = new Dictionary<Book, double>();
        }
    }
}
