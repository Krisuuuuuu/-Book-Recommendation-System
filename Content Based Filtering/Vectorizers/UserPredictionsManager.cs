using Content_Based_Filtering.Interfaces;
using Model.Algorithm;
using Model.Shop;
using System.Collections.Generic;
using System.Linq;

namespace Content_Based_Filtering.Vectorizers
{
    public class UserPredictionsManager : IEvaluator
    {
        public ICollection<UserPredictions> CreateUserPredictions(ICollection<Client> clients, ICollection<UserProfile> userProfiles,
            ICollection<ItemProfile> itemProfiles)
        {
            ICollection<UserPredictions> usersPredictions = new List<UserPredictions>();

            Client[] clientsArray = clients.ToArray();
            UserProfile[] userProfilesArray = userProfiles.ToArray();

            for (int i = 0; i < clientsArray.Length; i++)
            {
                UserPredictions userPredictions = new UserPredictions(userProfilesArray[i]);

                userPredictions.Predictions = CalculateUserPredictions(userProfilesArray[i], itemProfiles, userPredictions.Results);

                userPredictions.Results = userPredictions.Results.OrderByDescending(i => i.Value).ToDictionary(x => x.Key, x => x.Value);

                usersPredictions.Add(userPredictions);
            }

            return usersPredictions;
        }

        public ICollection<UserPredictions> PrepareResults(ICollection<UserPredictions> usersPredictions)
        {
            foreach(UserPredictions userPredictions in usersPredictions)
            {
                foreach(KeyValuePair<Book, double> results in userPredictions.Results)
                {
                    if(userPredictions.UserProfile.Client.AllPurchasedProducts.Contains(results.Key))
                    {
                        userPredictions.Results.Remove(results);
                    }
                }
            }

            return usersPredictions;
        }

        private double[] CalculateUserPredictions(UserProfile userProfile, ICollection<ItemProfile> itemProfiles, IDictionary<Book, double> results)
        {
            double[] predictions = new double[itemProfiles.Count];
            ItemProfile[] itemProfilesArray = itemProfiles.ToArray();

            for (int i = 0; i < itemProfilesArray.Length; i++)
            {
                for (int j = 0; j < itemProfilesArray[0].WeightedScores.Length; j++)
                {
                    predictions[i] += itemProfilesArray[i].WeightedScores[j] * userProfile.Preferences[j];
                }

                results.Add(itemProfilesArray[i].Book, predictions[i]);
            }
            return predictions;
        }
    }
}
