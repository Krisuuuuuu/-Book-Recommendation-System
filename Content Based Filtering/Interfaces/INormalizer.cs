using System.Collections.Generic;

namespace Content_Based_Filtering.Interfaces
{
    public interface INormalizer<T>
    {
        ICollection<T> Normalize(ICollection<T> itemProfiles);
    }
}
