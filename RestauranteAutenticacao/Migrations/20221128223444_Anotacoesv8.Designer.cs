﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RestauranteAutenticacao.Models;

#nullable disable

namespace RestauranteAutenticacao.Migrations
{
    [DbContext(typeof(Contexto))]
    [Migration("20221128223444_Anotacoesv8")]
    partial class Anotacoesv8
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("RestauranteAutenticacao.Models.Bebida", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("preco")
                        .HasColumnType("real");

                    b.Property<int>("quantidade")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("Bebida");
                });

            modelBuilder.Entity("RestauranteAutenticacao.Models.Cliente", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("endereco")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasMaxLength(35)
                        .HasColumnType("nvarchar(35)");

                    b.Property<string>("telefone")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("nvarchar(14)");

                    b.HasKey("id");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("RestauranteAutenticacao.Models.Consultas.PedidoGroupStatus", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("cliente")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("marmita")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("preco")
                        .HasColumnType("real");

                    b.Property<string>("status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("PedidoGroupStatus");
                });

            modelBuilder.Entity("RestauranteAutenticacao.Models.Consultas.PedidoQuerry", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("bebida")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("cliente")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("endereco")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("marmita")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("preco")
                        .HasColumnType("real");

                    b.Property<string>("preparo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("PedidoQuerry");
                });

            modelBuilder.Entity("RestauranteAutenticacao.Models.Marmita", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("preco")
                        .HasColumnType("real");

                    b.Property<int>("tamanho")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("Marmita");
                });

            modelBuilder.Entity("RestauranteAutenticacao.Models.Pedido", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<int>("bebidaid")
                        .HasColumnType("int");

                    b.Property<int>("clienteid")
                        .HasColumnType("int");

                    b.Property<int>("marmitaid")
                        .HasColumnType("int");

                    b.Property<int>("quantidadebebida")
                        .HasColumnType("int");

                    b.Property<int>("status")
                        .HasColumnType("int");

                    b.Property<string>("tempoPedido")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("bebidaid");

                    b.HasIndex("clienteid");

                    b.HasIndex("marmitaid");

                    b.ToTable("Pedido");
                });

            modelBuilder.Entity("RestauranteAutenticacao.Models.Pedido", b =>
                {
                    b.HasOne("RestauranteAutenticacao.Models.Bebida", "bebida")
                        .WithMany("pedidos")
                        .HasForeignKey("bebidaid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RestauranteAutenticacao.Models.Cliente", "cliente")
                        .WithMany("pedidos")
                        .HasForeignKey("clienteid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RestauranteAutenticacao.Models.Marmita", "marmitas")
                        .WithMany("pedidos")
                        .HasForeignKey("marmitaid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("bebida");

                    b.Navigation("cliente");

                    b.Navigation("marmitas");
                });

            modelBuilder.Entity("RestauranteAutenticacao.Models.Bebida", b =>
                {
                    b.Navigation("pedidos");
                });

            modelBuilder.Entity("RestauranteAutenticacao.Models.Cliente", b =>
                {
                    b.Navigation("pedidos");
                });

            modelBuilder.Entity("RestauranteAutenticacao.Models.Marmita", b =>
                {
                    b.Navigation("pedidos");
                });
#pragma warning restore 612, 618
        }
    }
}
