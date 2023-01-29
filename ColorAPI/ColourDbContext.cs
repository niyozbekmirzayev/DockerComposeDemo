using ColorAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ColorAPI
{
    public class ColourDbContext : DbContext
    {
        public ColourDbContext(DbContextOptions<ColourDbContext> options) : base(options)
        {

        }

        public virtual DbSet<Colour> Colours { get; set; }
    }
}
