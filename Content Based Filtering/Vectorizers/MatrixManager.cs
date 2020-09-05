using Content_Based_Filtering.Interfaces;
using Model.Algorithm;
using System.Collections.Generic;
using System.Linq;

namespace Content_Based_Filtering.Vectorizers
{
    public class MatrixManager : IFiller<ItemProfile>
    {
        public double[,] Fill(ICollection<ItemProfile> itemProfiles, double[,] matrix)
        {
            ItemProfile[] itemProfilesArray = itemProfiles.ToArray();

            for (int i = 0; i < itemProfilesArray.Length; i++)
            {
                for (int j = 0; j < itemProfilesArray[i].DistinguishingFeaturesBinaryRepresentation.Length; j++)
                {
                    matrix[i, j] = itemProfilesArray[i].DistinguishingFeaturesBinaryRepresentation[j];
                }
            }

            return matrix;
        }
    }
}
