using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using WebAPI.Models.Entities;

namespace WebAPI
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            try
            {
                var DbCreator = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
                if (DbCreator != null)
                {
                    if (!DbCreator.CanConnect()) DbCreator.Create();
                    if (!DbCreator.HasTables()) DbCreator.CreateTables();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public DbSet<SampleModel> entity {get; set;} = null!;
    }
}