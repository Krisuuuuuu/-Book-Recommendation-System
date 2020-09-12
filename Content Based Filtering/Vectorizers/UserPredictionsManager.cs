using Content_Based_Filtering.Interfaces;
using Model.Algorithm;
using Model.Shop;
using System;
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
                UserPredictions userPredictions = new UserPredictions(clientsArray[i], userProfilesArray[i]);

                userPredictions.Predictions = CalculateUserPredictions(userProfilesArray[i], itemProfiles);

                usersPredictions.Add(userPredictions);
            }

            return usersPredictions;
        }

        private double[] CalculateUserPredictions(UserProfile userProfile, ICollection<ItemProfile> itemProfiles)
        {
            double[] predictions = new double[itemProfiles.Count];
            ItemProfile[] itemProfilesArray = itemProfiles.ToArray();

            for (int i = 0; i < itemProfilesArray.Length; i++)
            {
                for (int j = 0; j < predictions.Length; j++)
                {
                    predictions[i] += itemProfilesArray[i].WeightedScores[j] * userProfile.Preferences[j];
                }
            }
            return predictions;
        }
    }
}
