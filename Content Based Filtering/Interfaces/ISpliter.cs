using System;
using System.Collections.Generic;
using System.Text;

namespace Content_Based_Filtering.Interfaces
{
    public interface ISplitter
    {
        ICollection<string> SplitMultipleFeatures(string delimiter, string item);
    }
}
