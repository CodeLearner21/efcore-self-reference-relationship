using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelfRefExtityExample.Data
{
    public class ApiContextFactory : IDesignTimeDbContextFactory<ApiContext>
    {
        public ApiContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApiContext>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=demo-database;Trusted_Connection=True;MultipleActiveResultSets=true");

            return new ApiContext(optionsBuilder.Options);
        }
    }
}
