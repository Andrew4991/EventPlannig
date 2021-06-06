using EventPlannig.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace EventPlannig.DAL.EF
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
             //Database.EnsureDeleted();
            Database.EnsureCreated(); // создаем базу данных при первом обращении  
        }

        public DbSet<Event> Events { get; set; }

        public DbSet<EventField> EventFields { get; set; }

        public DbSet<EventRequiry> EventRequiries { get; set; }
    }
}
