using Model.Algorithm;
using Model.Shop;
using System.Collections.Generic;

namespace Content_Based_Filtering.Interfaces
{
    public interface IEvaluator
    {
        ICollection<UserPredictions> CreateUserPredictions(ICollection<Client> clients, ICollection<UserProfile> userProfiles,
            ICollection<ItemProfile> itemProfiles);
        ICollection<UserPredictions> PrepareResults(ICollection<UserPredictions> usersPredictions);
   }
}
