using System.Collections.Generic;

namespace BusinessLayer.Abstract
{
    public interface IGenericService<T> where T : class
    {
        void TAdd(T t);
        void TDelete(T t);
        void TUpdate(T t);
        T TGetById(int id);

        List<T> GetList();
    }
}
