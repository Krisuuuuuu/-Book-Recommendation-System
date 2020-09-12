using Content_Based_Filtering.Interfaces;
using Model.Algorithm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Content_Based_Filtering.Vectorizers
{
    public class TFIDFManager : IVectorizer
    {
        public double[] CalculateDF(ICollection<ItemProfile> itemProfiles, TFIDFRepresentation tfidfRepresentation)
        {
            ItemProfile[] itemProfilesArray = itemProfiles.ToArray();
            double[] dfs = new double[itemProfilesArray[0].DistinguishingFeaturesBinaryRepresentation.Length];

            for (int i = 0; i < itemProfilesArray[0].DistinguishingFeaturesBinaryRepresentation.Length; i++)
            {
                int counter = 0;

                for (int j = 0; j < itemProfilesArray.Length; j++)
                {
                    if (itemProfilesArray[j].DistinguishingFeaturesBinaryRepresentation[i] != 0)
                    {
                        counter++;
                    }
                }

                dfs[i] = counter;
            }

            return dfs;
        }

        public double[] CalculateIDF(TFIDFRepresentation tfidfRepresentation, int total)
        {
            double[] idf = new double[tfidfRepresentation.DistinguishingFeaturesDF.Length];

            for (int i = 0; i < idf.Length; i++)
            {
                idf[i] = Math.Log10(total / tfidfRepresentation.DistinguishingFeaturesDF[i]);
            }

            return idf;
        }

        public ICollection<ItemProfile> CalculateWeightedScores(TFIDFRepresentation tfidf, ICollection<ItemProfile> itemProfiles)
        {
            double[] idf = tfidf.DistinguishingFeaturesIDF;

            ItemProfile[] itemProfilesArray = itemProfiles.ToArray();

            foreach(ItemProfile item in itemProfiles)
            {
                for (int i = 0; i < idf.Length; i++)
                {
                    item.WeightedScores[i] = item.DistinguishingFeaturesBinaryRepresentation[i] * idf[i];
                }
            }

            return itemProfiles;

        }
    }
}
