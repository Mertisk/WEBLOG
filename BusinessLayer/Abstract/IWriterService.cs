using EntityLayer.Concrete;
using System.Collections.Generic;

namespace BusinessLayer.Abstract
{
    public interface IWriterService : IGenericService<Writer>
    {
        //ıd'ye göre yazar bilgisini getir
        List<Writer> GetWriterById(int id);


    }
}
