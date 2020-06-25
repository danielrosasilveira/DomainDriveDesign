using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Configuration
{
    public class ContextBase : DbContext
    {

        public ContextBase(DbContextOptions<ContextBase> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public ContextBase()
        {

        }

        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            try
            {
                // Se não estiver configurado no projeto IU pega deginição de chame do json configurado
                if (!optionsBuilder.IsConfigured)
                    // para o UseSqlServer foi instalado o pacto Microsoft.EntityFrameworkCore.SqlServer
                    optionsBuilder.UseSqlServer(GetStringConectionConfig());
                base.OnConfiguring(optionsBuilder);
            }
            catch (Exception ex)
            {
                var message = ex.Message;
            }
            
        }        

        private string GetStringConectionConfig()
        {
            string strCon = "Data Source=DS-SISTEMAS\\SQLEXPRESS;Initial Catalog=DDD;Integrated Security=False;User ID=sa;Password=sa;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False";
            return strCon;
        }

        
    }
}
