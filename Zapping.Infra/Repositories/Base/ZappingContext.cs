﻿using Microsoft.EntityFrameworkCore;
using prmToolkit.NotificationPattern;
using System;
using System.Collections.Generic;
using System.Text;
using Zapping.Domain.Entities;
using Zapping.Infra.Repositories.Map;

namespace Zapping.Infra.Repositories.Base
{
    public partial class ZappingContext : DbContext
    {
        // Criar as tabelas
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Campanha> Campanha { get; set; }
        public DbSet<Envio> Envio { get; set; }
        public DbSet<Grupo> Grupo { get; set; }
        public DbSet<Contato> Contato { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("Server=localhost;Database=zapping;Uid=root;Pwd=123456");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //ignorar classes
            modelBuilder.Ignore<Notification>();
            //modelBuilder.Ignore<Nome>();
            //modelBuilder.Ignore<Email>();

            //aplicar configurações
            modelBuilder.ApplyConfiguration(new MapUsuario());
            modelBuilder.ApplyConfiguration(new MapGrupo());
            modelBuilder.ApplyConfiguration(new MapContato());
            modelBuilder.ApplyConfiguration(new MapCampanha());
            modelBuilder.ApplyConfiguration(new MapEnvio());


            base.OnModelCreating(modelBuilder);
        }
    }
}
