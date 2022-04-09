using Microsoft.EntityFrameworkCore;
using ShoppingApiRepository.SqlEntity;
using System.Collections.Generic;

namespace ShoppingApiRepository
{
    public class SqlDbContext: DbContext
    {
        public SqlDbContext(DbContextOptions options): base(options)
        {}

        public DbSet<SqlEntityProductModal> Products { get; set; }
    }
}
