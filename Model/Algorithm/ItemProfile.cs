using Model.Shop;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.Algorithm
{
    public class ItemProfile
    {
        public Book Book { get; private set; }
        public ICollection<string> DistinguishingFeatures { get; private set; }
        public double[] DistinguishingFeaturesBinaryRepresentation { get; set; }

        public ItemProfile(Book book, ICollection<string> features, double[] binaryRepresentation)
        {
            Book = book;
            DistinguishingFeatures = features;
            DistinguishingFeaturesBinaryRepresentation = binaryRepresentation;
        }
    }
}
