using GameZone.Models;

namespace GameZone.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> option)
          : base(option) { }

      
        
            protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          
            modelBuilder.Entity<Gamedevices>()
                .HasKey(e => new { e.gameid, e.devicesid });

            modelBuilder.Entity<Category>()
                .HasData(new Category[]
                {
                    new Category {Id=1,Name="sports" },
                    new Category {Id=2,Name="action" },
                    new Category {Id=3,Name="adventure" },
                    new Category {Id=4,Name="racing" },
                    new Category {Id=5,Name="fighting" },
                    new Category {Id=6,Name="film" }






                });
            modelBuilder.Entity <Devices>()
                .HasData(new Devices[] {

                new Devices {Id=1,Name ="playstation",icon="bi bi-playstation" },

                    new Devices {Id=2,Name ="xbox",icon="bi bi-xbox" },
                    new Devices {Id=3,Name ="nintendo switch",icon="bi bi-nintendo-switch" },
                    new Devices {Id=4,Name ="pc",icon="bi bi-display" }



        });
        }



        public DbSet<Game> Games { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<Devices> devices { get; set; }

        public DbSet<Gamedevices> gamedevices { get; set; }



    }

        
    
}
