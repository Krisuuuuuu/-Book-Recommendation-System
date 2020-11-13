using Model.Shop;
using System.Collections.Generic;

namespace Content_Based_Filtering.Interfaces
{
    public interface ICreator<T, U>
    {
        ICollection<T> CreateProfiles(ICollection<U> collection, Shop shop);
    }
}
