using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class TalentCardManager : ITalentCardService
    {
        ITalentCardDal _talentCardDal;

        public TalentCardManager(ITalentCardDal talentCardDal)
        {
            _talentCardDal = talentCardDal;
        }

        public List<TalentCard> GetAll()
        {
            return _talentCardDal.List();
        }

        public TalentCard GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void TalentCardAdd(TalentCard talentCard)
        {
            _talentCardDal.Insert(talentCard);
        }

        public void TalentCardDelete(TalentCard talentCard)
        {
            throw new NotImplementedException();
        }

        public void TalentCardUpdate(TalentCard talentCard)
        {
            throw new NotImplementedException();
        }
    }
}
