using BusinessLayer.Abstract;
using DataAccsessLayer.Abstract;
using EntityLayer.Concrete;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer.Concrete
{
    public class BlogManager : IBlogService
    {
        IBlogDal _blogDal;


        public BlogManager(IBlogDal blogDal)
        {
            _blogDal = blogDal;

        }

        public void BlogAdd(Blog blog)
        {
            throw new System.NotImplementedException();
        }

        public void BlogDelete(Blog blog)
        {
            throw new System.NotImplementedException();
        }

        public void BlogUpdate(Blog blog)
        {
            throw new System.NotImplementedException();
        }



        public List<Blog> GetBlogListWithCategory()
        {
            return _blogDal.GetListWithCategory();
        }

        public Blog TGetById(int id)
        {
            return _blogDal.GetByID(id);
        }

        public List<Blog> GetList()
        {
            return _blogDal.GetListAll();

        }

        public List<Blog> GetBlogById(int id)
        {
            return _blogDal.GetListAll(x => x.BlogID == id);
        }

        public List<Blog> GetBlogListByWriter(int id)
        {
            return _blogDal.GetListAll(x => x.WriterID == id);
        }

        public List<Blog> GetLast3Blog()
        {
            //3 tane  blog verisi çeker
            return _blogDal.GetListAll().Take(3).ToList();
        }

        public void TAdd(Blog t)
        {
            _blogDal.Insert(t);

        }

        public void TDelete(Blog t)
        {
            _blogDal.Delete(t);
        }

        public void TUpdate(Blog t)
        {
            _blogDal.Update(t);
        }


    }
}
