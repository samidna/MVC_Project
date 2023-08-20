using Microsoft.EntityFrameworkCore;
using Riode.Models;

namespace Riode.DataAccess;

public class RiodeDbContext : DbContext
{
    public RiodeDbContext(DbContextOptions options) : base(options) { }
    public DbSet<Slider> Sliders { get; set; }  
}
