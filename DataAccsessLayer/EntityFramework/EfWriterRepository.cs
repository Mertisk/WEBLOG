﻿using DataAccsessLayer.Abstract;
using DataAccsessLayer.Repositories;
using EntityLayer.Concrete;

namespace DataAccsessLayer.EntityFramework
{
    public class EfWriterRepository : GenericRepository<Writer>, IWriterDal
    {
    }
}
