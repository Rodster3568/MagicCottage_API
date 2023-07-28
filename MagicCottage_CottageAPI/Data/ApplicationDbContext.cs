using MagicCottage_CottageAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MagicCottage_CottageAPI.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Cottage> Cottages { get; set; }
    }
}
