using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class EshopDb: DbContext
    {
        public EshopDb(DbContextOptions<EshopDb> options)
            :base(options)
        {

        }

        public DbSet<Product> Products{ get; set; }
    }
}
