using System;
using System.Collections.Generic;
using System.Text;

namespace Content_Based_Filtering.Interfaces
{
    public interface IFiller<T>
    {
        double[,] Fill(ICollection<T> collection, double[,] matrix);
    }
}
