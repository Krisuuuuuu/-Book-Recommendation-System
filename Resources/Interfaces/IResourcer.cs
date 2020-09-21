using Model.Algorithm;
using System.Collections.Generic;

namespace Resources.Interfaces
{
    public interface IResourcer<T> where T : class
    {
        ICollection<T> ReadSource();
        void SaveResults(ICollection<UserPredictions> usersPredictions);
    }
}
