using BusinessLayer.Abstract;
using DataAccsessLayer.Abstract;
using EntityLayer.Concrete;
using System.Collections.Generic;

namespace BusinessLayer.Concrete
{
    public class WriterManager : IWriterService
    {
        IWriterDal _writerDal;

        public WriterManager(IWriterDal writerDal)
        {
            _writerDal = writerDal;
        }

        public List<Writer> GetList()
        {
            throw new System.NotImplementedException();
        }

        public List<Writer> GetWriterById(int id)
        {
            return _writerDal.GetListAll(x => x.WriterID == id);
        }

        public void TAdd(Writer t)
        {
            _writerDal.Insert(t);

        }

        public void TDelete(Writer t)
        {
            throw new System.NotImplementedException();
        }

        public Writer TGetById(int id)
        {
            return _writerDal.GetByID(id);
        }

        public void TUpdate(Writer t)
        {
            _writerDal.Update(t);
        }
    }
}
