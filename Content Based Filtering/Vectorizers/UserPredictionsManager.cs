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
            TFIDFRepresentation tfidf, ICollection<ItemProfile> itemProfiles)
        {
            ICollection<UserPredictions> usersPredictions = new List<UserPredictions>();

            Client[] clientsArray = clients.ToArray();
            UserProfile[] userProfilesArray = userProfiles.ToArray();

            for (int i = 0; i < clientsArray.Length; i++)
            {
                UserPredictions userPredictions = new UserPredictions(clientsArray[i], userProfilesArray[i]);

                //userPredictions.Predictions = CalculateUserPredictions(userProfilesArray[i], userPredictions, tfidf, itemProfiles);

                usersPredictions.Add(userPredictions);
            }

            return usersPredictions;
        }

        //private double[] CalculateUserPredictions(UserProfile userProfile, UserPredictions userPredictions, 
        //    TFIDFRepresentation tfidf, ICollection<ItemProfile> itemProfiles)
        //{

        //    double[] weightedScores = new double[itemProfiles.Count];
        //    double[] idf = tfidf.DistinguishingFeaturesIDF;

        //    ItemProfile[] itemProfilesArray = itemProfiles.ToArray();



        //    return predictions;
        //}
    }
}
