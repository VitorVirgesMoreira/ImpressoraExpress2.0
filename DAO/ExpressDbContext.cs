using DAO.Mappings;
using Entity;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class ExpressDbContext : DbContext
    {
        public ExpressDbContext():base(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")
        {

        }
        public DbSet <ClienteDTO> Clientes { get; set; }
        public DbSet <CartuchoDTO> Cartuchos { get; set; }
        public DbSet <ImpressoraDTO> Impressoras { get; set; }
        public DbSet <MovimentacaoDTO> Movimentacoes{ get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.Properties()
                        .Where(c => c.PropertyType == typeof(string))
                        .Configure(c => c.IsRequired().IsUnicode(false));

            base.OnModelCreating(modelBuilder);
        }
    }
}
