using System;
using System.Collections.Generic;
using System.Text;

namespace DAO.Mappings
{
    public class CartuchoRepository: Cartu
    {
        public CartuchoRepository()
        {
            this.ToTable("CARTUCHOS");
            this.Property(c => c.NomeModelo).HasMaxLength(150);
        }
    }
}
