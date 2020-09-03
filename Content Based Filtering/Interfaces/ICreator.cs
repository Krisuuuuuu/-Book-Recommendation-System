using Model.Algorithm;
using Model.Shop;
using System;
using System.Collections.Generic;
using System.Text;

namespace Content_Based_Filtering.Interfaces
{
    public interface ICreator<T, U>
    {
        ICollection<T> CreateProfiles(ICollection<U> collection, Shop shop);
    }
}
