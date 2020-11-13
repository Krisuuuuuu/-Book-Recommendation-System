using System.Collections.Generic;

namespace Content_Based_Filtering.Interfaces
{
    public interface IFiller<T>
    {
        double[,] Fill(ICollection<T> collection, double[,] matrix);
    }
}
