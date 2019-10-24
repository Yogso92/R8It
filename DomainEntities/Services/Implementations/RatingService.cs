using DAL;
using DbEntities;
using DomainEntities;
using R8It_Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tools;

namespace R8It_Domain.Services.Implementations
{
    public class RatingService : IRatingService
    {
        private readonly IRatingTypeRepository TypeRepository;
        private readonly IRateChoiceRepository ChoiceRepository;
        public RatingService(IRateChoiceRepository choiceRepository, IRatingTypeRepository typeRepository)
        {
            TypeRepository = typeRepository;
            ChoiceRepository = choiceRepository;
        }
        public void Delete(int ratingTypeId) //ratechoices will delete by cascade in db
        {
            TypeRepository.Delete(ratingTypeId);
        }

        public RatingType Get(int id)
        {
            RatingType ratingType = TypeRepository.Get(id).Map<RatingType>();
            ratingType.RateChoices = GetRateChoices(id);
            return ratingType;
        }

        public List<RatingType> GetAll()
        {
            List<RatingType> ratingTypes = TypeRepository.GetAll().Select(s => s.Map<RatingType>()).ToList();
            foreach(RatingType type in ratingTypes){
                type.RateChoices = GetRateChoices(type.Id);
            }
            return ratingTypes;
        }

        public List<RateChoice> GetRateChoices(int ratingtypeid)
        {
            return ChoiceRepository.GetChoices(ratingtypeid).Select(c => c.Map<RateChoice>()).ToList();
        }

        public RatingType Insert(RatingType ratingType)
        {
            TypeRepository.Insert(ratingType.Map<DbRatingType>()).Map<RatingType>();
            foreach(RateChoice choice in ratingType.RateChoices)
            {
                InsertChoice(choice);
            }
            ratingType.RateChoices = GetRateChoices(ratingType.Id);
            ratingType = Get(ratingType.Id);
            return ratingType;
        }

        public RateChoice InsertChoice(RateChoice rateChoice)
        {
            return ChoiceRepository.Insert(rateChoice.Map<DbRateChoice>()).Map<RateChoice>();
        }

        public RatingType Update(RatingType ratingType)
        {
            TypeRepository.Update(ratingType.Map<DbRatingType>());
            foreach(RateChoice choice in ratingType.RateChoices)
            {
                UpdateChoice(choice);
            }
            return Get(ratingType.Id);
        }

        public RateChoice UpdateChoice(RateChoice rateChoice)
        {
            if(rateChoice.Id != 0)
            {
                return ChoiceRepository.Update(rateChoice.Map<DbRateChoice>()).Map<RateChoice>();
            }
            return ChoiceRepository.Insert(rateChoice.Map<DbRateChoice>()).Map<RateChoice>();
        }
    }
}
