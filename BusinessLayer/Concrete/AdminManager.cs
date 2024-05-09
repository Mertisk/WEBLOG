using BusinessLayer.Abstract;
using DataAccsessLayer.Abstract;
using EntityLayer.Concrete;
using System.Collections.Generic;

namespace BusinessLayer.Concrete
{
    public class AdminManager : IAdminService
    {
        IAdminDal _adminDal;

        public AdminManager(IAdminDal adminDal)
        {
            _adminDal = adminDal;
        }

        public List<Admin> GetList()
        {
            return _adminDal.GetListAll();
        }

        public void TAdd(Admin t)
        {
            throw new System.NotImplementedException();
        }

        public void TDelete(Admin t)
        {
            throw new System.NotImplementedException();
        }

        public Admin TGetById(int id)
        {
            return _adminDal.GetByID(id);
        }

        public void TUpdate(Admin t)
        {
            throw new System.NotImplementedException();
        }
    }
}
