using Model.Algorithm;
using System;
using System.Collections.Generic;

namespace Content_Based_Filtering.Interfaces
{
    public interface IPrinter
    {
        void PrintResults(ICollection<UserPredictions> usersPredictions, int number);
        void PrintSimulationTime(TimeSpan time);
    }
}
