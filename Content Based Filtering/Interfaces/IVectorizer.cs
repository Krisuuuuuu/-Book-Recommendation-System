using Model.Algorithm;
using System.Collections.Generic;

namespace Content_Based_Filtering.Interfaces
{
    public interface IVectorizer
    {
        double[] CalculateDF(ICollection<ItemProfile> itemProfiles, TFIDFRepresentation tfidfRepresentation);
        double[] CalculateIDF(TFIDFRepresentation tfidfRepresentation, int total);
        ICollection<ItemProfile> CalculateWeightedScores(TFIDFRepresentation tfidf, ICollection<ItemProfile> itemProfiles);
    }
}
