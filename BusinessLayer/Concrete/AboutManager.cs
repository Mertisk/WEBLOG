using BusinessLayer.Abstract;
using DataAccsessLayer.Abstract;
using EntityLayer.Concrete;
using System.Collections.Generic;

namespace BusinessLayer.Concrete
{
    public class AboutManager : IGenericService<About>
    {
        IAboutDal _aboutDal;

        public AboutManager(IAboutDal aboutDal)
        {
            _aboutDal = aboutDal;
        }

        public About TGetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<About> GetList()
        {
            return _aboutDal.GetListAll();
        }

        public void TAdd(About t)
        {
            throw new System.NotImplementedException();
        }

        public void TDelete(About t)
        {
            throw new System.NotImplementedException();
        }

        public void TUpdate(About t)
        {
            throw new System.NotImplementedException();
        }
    }
}
