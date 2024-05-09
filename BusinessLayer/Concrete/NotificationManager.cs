using BusinessLayer.Abstract;
using DataAccsessLayer.Abstract;
using EntityLayer.Concrete;
using System.Collections.Generic;

namespace BusinessLayer.Concrete
{
    public class NotificationManager : INotificationService
    {
        INotificationDal _notificationDal;

        public NotificationManager(INotificationDal notificationDal)
        {
            _notificationDal = notificationDal;
        }

        public List<Notification> GetList()
        {
            return _notificationDal.GetListAll();
        }

        public void TAdd(Notification t)
        {
            throw new System.NotImplementedException();
        }

        public void TDelete(Notification t)
        {
            throw new System.NotImplementedException();
        }

        public Notification TGetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public void TUpdate(Notification t)
        {
            throw new System.NotImplementedException();
        }
    }
}
