﻿using Yuri.DataAccess.Data;
using Yuri.DataAccess.Repository.IRepository;
using Yuri.Models;

namespace Yuri.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {

        private ApplicationDbContext _db;

        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }




        public void Update(Product obj)
        {
            _db.Products.Update(obj);
        }
    }
}
