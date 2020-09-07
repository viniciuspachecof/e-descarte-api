using System.Collections.Generic;
using e_descarte_api.Models;
using Microsoft.EntityFrameworkCore;

namespace e_descarte_api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<PontoDescarte> pontodescarte { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {         
            builder.Entity<PontoDescarte>()
            .HasData(new List<PontoDescarte>{
                    new PontoDescarte(1, "FAMCRI", "(48) 3445-8811", -28.686901, -49.384303),
                    new PontoDescarte(2, "Faculdades ESUCRI", "(48) 3431-3700", -28.681298, -49.3748468)
            });
        }
    }
};