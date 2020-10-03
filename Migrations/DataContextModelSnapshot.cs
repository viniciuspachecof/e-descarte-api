﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using e_descarte_api.Data;

namespace e_descarte_api.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("e_descarte_api.Models.Cidade", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("nome")
                        .HasColumnType("text");

                    b.Property<string>("uf")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("cidade");

                    b.HasData(
                        new
                        {
                            id = 1,
                            nome = "Joinville",
                            uf = "SC"
                        },
                        new
                        {
                            id = 2,
                            nome = "Florianópolis",
                            uf = "SC"
                        },
                        new
                        {
                            id = 3,
                            nome = "Blumenau",
                            uf = "SC"
                        },
                        new
                        {
                            id = 4,
                            nome = "São José",
                            uf = "SC"
                        },
                        new
                        {
                            id = 5,
                            nome = "Chapecó",
                            uf = "SC"
                        },
                        new
                        {
                            id = 6,
                            nome = "Itajaí",
                            uf = "SC"
                        },
                        new
                        {
                            id = 7,
                            nome = "Criciúma",
                            uf = "SC"
                        },
                        new
                        {
                            id = 8,
                            nome = "Jaraguá do Sul",
                            uf = "SC"
                        },
                        new
                        {
                            id = 9,
                            nome = "Palhoça",
                            uf = "SC"
                        },
                        new
                        {
                            id = 10,
                            nome = "Lages",
                            uf = "SC"
                        });
                });

            modelBuilder.Entity("e_descarte_api.Models.Item", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("nome")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("item");

                    b.HasData(
                        new
                        {
                            id = 1,
                            nome = "Rádio"
                        },
                        new
                        {
                            id = 2,
                            nome = "Televisores"
                        },
                        new
                        {
                            id = 3,
                            nome = "Tablets"
                        },
                        new
                        {
                            id = 4,
                            nome = "Monitores"
                        },
                        new
                        {
                            id = 5,
                            nome = "Teclados"
                        },
                        new
                        {
                            id = 6,
                            nome = "Impressoras"
                        },
                        new
                        {
                            id = 7,
                            nome = "Câmeras Fotográficas"
                        },
                        new
                        {
                            id = 8,
                            nome = "Aparelhos de Som"
                        },
                        new
                        {
                            id = 9,
                            nome = "Geladeira"
                        },
                        new
                        {
                            id = 10,
                            nome = "Fogão"
                        });
                });

            modelBuilder.Entity("e_descarte_api.Models.PontoDescarte", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("cidadeId")
                        .HasColumnType("integer");

                    b.Property<string>("fone")
                        .HasColumnType("text");

                    b.Property<double>("latitude")
                        .HasColumnType("double precision");

                    b.Property<double>("longitude")
                        .HasColumnType("double precision");

                    b.Property<string>("nome")
                        .HasColumnType("text");

                    b.Property<bool>("status")
                        .HasColumnType("boolean");

                    b.Property<int>("usuarioId")
                        .HasColumnType("integer");

                    b.HasKey("id");

                    b.HasIndex("cidadeId");

                    b.HasIndex("usuarioId");

                    b.ToTable("pontodescarte");

                    b.HasData(
                        new
                        {
                            id = 1,
                            cidadeId = 1,
                            fone = "(48) 3445-8811",
                            latitude = -28.6868546,
                            longitude = -49.384514699999997,
                            nome = "FAMCRI",
                            status = true,
                            usuarioId = 1
                        },
                        new
                        {
                            id = 2,
                            cidadeId = 2,
                            fone = "(48) 3431-3700",
                            latitude = -28.681176099999998,
                            longitude = -49.3738259,
                            nome = "Faculdades ESUCRI",
                            status = true,
                            usuarioId = 2
                        });
                });

            modelBuilder.Entity("e_descarte_api.Models.PontoDescarteItem", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("itemId")
                        .HasColumnType("integer");

                    b.Property<int>("pontodescarteId")
                        .HasColumnType("integer");

                    b.Property<int>("quant")
                        .HasColumnType("integer");

                    b.Property<int>("usuarioId")
                        .HasColumnType("integer");

                    b.HasKey("id");

                    b.HasIndex("itemId");

                    b.HasIndex("pontodescarteId");

                    b.HasIndex("usuarioId");

                    b.ToTable("pontodescarteitem");
                });

            modelBuilder.Entity("e_descarte_api.Models.Usuario", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("email")
                        .HasColumnType("text");

                    b.Property<string>("nome")
                        .HasColumnType("text");

                    b.Property<string>("senha")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("usuario");

                    b.HasData(
                        new
                        {
                            id = 1,
                            email = "vinicius.pachecof@hotmail.com",
                            nome = "Vinicius",
                            senha = "123"
                        },
                        new
                        {
                            id = 2,
                            email = "rodolfo.casagrande@hotmail.com",
                            nome = "Rodolfo",
                            senha = "321"
                        });
                });

            modelBuilder.Entity("e_descarte_api.Models.PontoDescarte", b =>
                {
                    b.HasOne("e_descarte_api.Models.Cidade", "cidade")
                        .WithMany()
                        .HasForeignKey("cidadeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("e_descarte_api.Models.Usuario", "usuario")
                        .WithMany()
                        .HasForeignKey("usuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("e_descarte_api.Models.PontoDescarteItem", b =>
                {
                    b.HasOne("e_descarte_api.Models.Item", "item")
                        .WithMany()
                        .HasForeignKey("itemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("e_descarte_api.Models.PontoDescarte", "pontodescarte")
                        .WithMany()
                        .HasForeignKey("pontodescarteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("e_descarte_api.Models.Usuario", "usuario")
                        .WithMany()
                        .HasForeignKey("usuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
