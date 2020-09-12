using Model.Shop;
using System.Collections.Generic;

namespace Model.Algorithm
{
    public class ItemProfile
    {
        public Book Book { get; private set; }
        public ICollection<string> DistinguishingFeatures { get; private set; }
        public double[] DistinguishingFeaturesBinaryRepresentation { get; set; }
        public double[] WeightedScores { get; set; }
        public ItemProfile(Book book, ICollection<string> features, double[] binaryRepresentation)
        {
            Book = book;
            DistinguishingFeatures = features;
            DistinguishingFeaturesBinaryRepresentation = binaryRepresentation;
            WeightedScores = new double[binaryRepresentation.Length];
        }
    }
}
