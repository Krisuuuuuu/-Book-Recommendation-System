using System;
using System.Collections.Generic;
using System.Text;

namespace Content_Based_Filtering.Interfaces
{
    public interface INormalizer<T>
    {
        ICollection<T> Normalize(ICollection<T> itemProfiles);
    }
}
