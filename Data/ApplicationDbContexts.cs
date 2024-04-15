using Microsoft.EntityFrameworkCore;
using bulkAction.Models;
namespace bulkAction.Data
{
    public class ApplicationDbContexts:DbContext
    {
        public DbSet<Fruits> fruits { get; set; }
        public ApplicationDbContexts(DbContextOptions <ApplicationDbContexts> options) : base(options)
        {

        }
    }
}
