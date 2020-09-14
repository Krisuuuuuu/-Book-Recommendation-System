using Model.Algorithm;
using System;
using System.Collections.Generic;
using System.Text;

namespace Content_Based_Filtering.Interfaces
{
    public interface IPrinter
    {
        void PrintResults(ICollection<UserPredictions> usersPredictions, int number);
    }
}
