using BusinessLayer.Abstract;
using DataAccsessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class NewsLatterManager : INewsLatterService
    {
        INewsLatterDal _newsLatterDal;

        public NewsLatterManager(INewsLatterDal newsLatterDal)
        {
            _newsLatterDal = newsLatterDal;
        }

        public void AddLatter(NewsLatter newsLatter)
        {
            _newsLatterDal.Insert(newsLatter);
        }
    }
}
