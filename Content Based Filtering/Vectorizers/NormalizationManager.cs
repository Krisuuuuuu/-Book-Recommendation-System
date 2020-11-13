using Content_Based_Filtering.Interfaces;
using Model.Algorithm;
using System;
using System.Collections.Generic;

namespace Content_Based_Filtering.Vectorizers
{
    public class NormalizationManager : INormalizer<ItemProfile>
    {
        public ICollection<ItemProfile> Normalize(ICollection<ItemProfile> itemProfiles)
        {
            foreach (ItemProfile itemProfile in itemProfiles)
            {
                itemProfile.DistinguishingFeaturesBinaryRepresentation = NormalizeValuesInVector(itemProfile.DistinguishingFeaturesBinaryRepresentation, 
                    itemProfile.DistinguishingFeatures.Count); ;
            }

            return itemProfiles;
        }

        private double[] NormalizeValuesInVector(double[] vector, int total)
        {
            for (int i = 0; i < vector.Length; i++)
            {
                vector[i] = vector[i] / Math.Sqrt(total);
            }

            return vector;
        }
    }
}
