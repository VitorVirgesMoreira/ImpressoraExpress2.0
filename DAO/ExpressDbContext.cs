using DAO.Mappings;

using System.Data.Entity.ModelConfiguration.Conventions;
using System.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using Microsoft.EntityFrameworkCore;

namespace DAO
{
    public class ExpressDbContext : DbContext
    {
        public ExpressDbContext():base()
        {

        }
        public DbSet <ClienteDTO> Clientes { get; set; }
        public DbSet <CartuchoDTO> Cartuchos { get; set; }
        public DbSet <ImpressoraDTO> Impressoras { get; set; }
        public DbSet <MovimentacaoDTO> Movimentacoes{ get; set; }
        public DbSet <UsuarioDTO> Usuarios { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
