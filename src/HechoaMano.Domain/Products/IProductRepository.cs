﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HechoaMano.Domain.Products
{
    public  interface IProductRepository
    {
        Task<Product?> GetAsync(ProductId id);
        Task AddAsync(Product product);
        Task UpdateAsync(Product product);
        Task DeleteAsync(ProductId id);
        Task<IEnumerable<Product>> GetAll();
    }
}
