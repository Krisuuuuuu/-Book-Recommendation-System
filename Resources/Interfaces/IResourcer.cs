using System.Collections.Generic;

namespace Resources.Interfaces
{
    interface IResourcer<T> where T : class
    {
        ICollection<T> ReadSource();
    }
}
