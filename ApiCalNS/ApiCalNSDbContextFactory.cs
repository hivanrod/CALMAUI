using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace ApiCalNS
{
    public class ApiCalNSDbContextFactory : IDesignTimeDbContextFactory<ApiCalNSDbContext>
    {
        public ApiCalNSDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApiCalNSDbContext>();
            var connStr = ConfigurationHelper.GetCurrentSettings("ConnectionStrings:DefaultConnection");
            optionsBuilder.UseSqlServer(connStr);
            return new ApiCalNSDbContext(optionsBuilder.Options);
        }
    }
}
