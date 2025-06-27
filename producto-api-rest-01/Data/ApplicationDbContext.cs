using Microsoft.EntityFrameworkCore;
using producto_api_rest_01.models;

namespace producto_api_rest_01.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Producto> Productos { get; set; }
    }
}
