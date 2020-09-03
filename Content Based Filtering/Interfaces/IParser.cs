using System;
using System.Collections.Generic;
using System.Text;

namespace Content_Based_Filtering.Interfaces
{
    public interface IParser<T> where T: class
    {
        ICollection<string> GetDistinguishingFeatures(ICollection<T> collection);
    }
}
