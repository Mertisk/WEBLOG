﻿using DataAccsessLayer.Abstract;
using DataAccsessLayer.Repositories;
using EntityLayer.Concrete;

namespace DataAccsessLayer.EntityFramework
{
    public class EfNewsLatterRepository : GenericRepository<NewsLatter>, INewsLatterDal
    {
    }
}
