using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System.Collections.Generic;

namespace DataAccsessLayer.Abstract
{
    public interface IBlogDal : IGenericDal<Blog>
    {

        //category listesini getir diyoruz ınclude kullanımı için başlangıcı generic içine yazmadık çünkü ilgili entity list<Blog>,bu adımdan sonra efblogrepositorye bak
        List<Blog> GetListWithCategory();


    }
}
