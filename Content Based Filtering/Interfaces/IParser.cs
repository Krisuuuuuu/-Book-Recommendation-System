using System;
using System.Collections.Generic;
using System.Text;

namespace Content_Based_Filtering.Interfaces
{
    public interface IParser<T>
    {
        ICollection<string> GetDistinguishingFeatures(ICollection<T> collection);
    }
}
