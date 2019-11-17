using bugtraq.API.Models;
using Microsoft.EntityFrameworkCore;

namespace bugtraq.API.Data
{
  public class DataContext : DbContext
  {
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    public DbSet<BugList> BugLists { get; set; }
  }
}