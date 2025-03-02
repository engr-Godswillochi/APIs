using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookTrackApi.Interface
{
    public interface IReviewRepository
    {
        public Task GetAll();
    }
}