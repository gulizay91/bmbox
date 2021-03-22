using Bmbox.Entity.Entity;
using Microsoft.EntityFrameworkCore;

namespace Bmbox.Repository.Configuration
{
  public class BmboxContext : DbContext
  {
    public BmboxContext(DbContextOptions<BmboxContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      /* modelBuilder.Ignore<View_GetAccountMovie_Result>(); // this view does not have unique key like pk
       */
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    }

    // Tables
    public DbSet<Account> Account { get; set; }
    public DbSet<AccountType> AccountType { get; set; }
    public DbSet<AccountMovie> AccountMovie { get; set; }
    public DbSet<AccountTvSeries> AccountTvSeries { get; set; }

    public DbSet<AccountBook> AccountBook { get; set; }

    // Store Procedures / View / Functions
    /*
    public DbSet<View_GetAccountMovie_Result> ViewGetAccountMovie { get; set; }
    public DbSet<SP_GetAccountMovieFavorites_Result> SP_AccountMovieFavorites { get; set; }
    */
  }
}
