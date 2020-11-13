using System.Collections.Generic;

namespace Content_Based_Filtering.Interfaces
{
    public interface ISplitter
    {
        ICollection<string> SplitMultipleFeatures(string delimiter, string item);
    }
}
