using DomainEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace R8It_Domain.Services.Interfaces
{
    public interface IRatingService
    {
        RatingType Get(int id);
        List<RatingType> GetAll();
        List<RateChoice> GetRateChoices(int ratingtypeid);
        RatingType Update(RatingType ratingType);
        RateChoice UpdateChoice(RateChoice rateChoice);
        RatingType Insert(RatingType ratingType);
        RateChoice InsertChoice(RateChoice rateChoice);
        void Delete(int ratingTypeId);

    }
}
