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
        public DbSet<Cidade> cidade { get; set; }
        public DbSet<RankingPontuacao> rankingpontuacao { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {              
            builder.Entity<Usuario>()
            .HasData(new List<Usuario>{
                    new Usuario(1, "Vinicius", "vinicius@hotmail.com", "123456789", "CATADOR"),
                    new Usuario(2, "Rodolfo", "rodolfo@hotmail.com", "987654321", "DESCARTANTE"),
            });

            builder.Entity<PontoDescarte>()
            .HasData(new List<PontoDescarte>{
                    new PontoDescarte(1, "FAMCRI", "(48) 3445-8811", -28.6868546, -49.3845147, true, 0, 1, 1),
                    new PontoDescarte(2, "Faculdades ESUCRI", "(48) 3431-3700", -28.6811761, -49.3738259, true, 1, 2, 2)
            });

            builder.Entity<Item>()
            .HasData(new List<Item>{
                    new Item(1, "Rádio", 1),
                    new Item(2, "Televisores", 2),
                    new Item(3, "Tablets", 3),
                    new Item(4, "Monitores", 4),
                    new Item(5, "Teclados", 5),
                    new Item(6, "Impressoras", 6),
                    new Item(7, "Câmeras Fotográficas", 7),
                    new Item(8, "Aparelhos de Som", 8),
                    new Item(9, "Geladeira", 9),
                    new Item(10, "Fogão", 10),
            });

            builder.Entity<Cidade>()
            .HasData(new List<Cidade>{
                    new Cidade(1, "Joinville", "SC"),
                    new Cidade(2, "Florianópolis", "SC"),
                    new Cidade(3, "Blumenau", "SC"),
                    new Cidade(4, "São José", "SC"),
                    new Cidade(5, "Chapecó", "SC"),
                    new Cidade(6, "Itajaí", "SC"),
                    new Cidade(7, "Criciúma", "SC"),
                    new Cidade(8, "Jaraguá do Sul", "SC"),
                    new Cidade(9, "Palhoça", "SC"),
                    new Cidade(10, "Lages", "SC")
            });
        }
    }
};