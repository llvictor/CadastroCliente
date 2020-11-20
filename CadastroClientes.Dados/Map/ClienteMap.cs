using CadastroClientes.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CadastroClientes.Dados.Map
{
    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Cliente");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(x => x.DataNascimento)
                .HasColumnType("timestamp")
                .IsRequired();

            builder.Property(x => x.Sexo)
                .HasColumnType("varchar(1)")
                .IsRequired();

            builder.Property(x => x.Cep)
                .HasColumnType("varchar(8)");

            builder.Property(x => x.Logradouro)
                .HasColumnType("varchar(50)");

            builder.Property(x => x.Numero)
                .HasColumnType("varchar(5)");

            builder.Property(x => x.Complemento)
                .HasColumnType("varchar(50)");

            builder.Property(x => x.Bairro)
                .HasColumnType("varchar(50)");

            builder.Property(x => x.Uf)
                .HasColumnType("varchar(2)");

            builder.Property(x => x.Cidade)
                .HasColumnType("varchar(30)");
        }
    }
}
