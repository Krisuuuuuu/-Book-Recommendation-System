﻿using Content_Based_Filtering.Vectorizers;
using Model.Algorithm;
using Model.Shop;
using System;
using System.Collections.Generic;
using System.Text;

namespace Content_Based_Filtering.Interfaces
{
    public interface IEvaluator
    {
        ICollection<UserPredictions> CreateUserPredictions(ICollection<Client> clients, ICollection<UserProfile> userProfiles, 
            TFIDFRepresentation tfidf, ICollection<ItemProfile> itemProfiles);    
   }
}
