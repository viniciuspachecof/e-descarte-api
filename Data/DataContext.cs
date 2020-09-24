using System.Collections.Generic;
using e_descarte_api.Models;
using Microsoft.EntityFrameworkCore;

namespace e_descarte_api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<PontoDescarte> pontodescarte { get; set; }
        public DbSet<Usuario> usuario { get; set; }
        public DbSet<Item> item { get; set; }
        public DbSet<PontoDescarteItem> pontodescarteitem { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {              
            builder.Entity<Usuario>()
            .HasData(new List<Usuario>{
                    new Usuario(1, "Vinicius", "vinicius.pachecof@hotmail.com", "123"),
                    new Usuario(2, "Rodolfo", "rodolfo.casagrande@hotmail.com", "321"),
            });

            builder.Entity<PontoDescarte>()
            .HasData(new List<PontoDescarte>{
                    new PontoDescarte(1, "FAMCRI", "(48) 3445-8811", -28.6868546, -49.3845147),
                    new PontoDescarte(2, "Faculdades ESUCRI", "(48) 3431-3700", -28.6811761, -49.3738259)
            });

            builder.Entity<Item>()
            .HasData(new List<Item>{
                    new Item(1, "Rádio"),
                    new Item(2, "Televisão")
            });
        }
    }
};