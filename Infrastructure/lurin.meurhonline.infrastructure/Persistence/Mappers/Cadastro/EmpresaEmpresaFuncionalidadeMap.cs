using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

using lurin.meurhonline.domain.model;

namespace lurin.meurhonline.infrastructure.persistence.mapper
{
    public class EmpresaEmpresaFuncionalidadeMap : EntityTypeConfiguration<EmpresaEmpresaFuncionalidadeModel>
    {
        public EmpresaEmpresaFuncionalidadeMap()
        {
            ToTable("EmpresaEmpresaFuncionalidade");
            HasKey(pu => new { pu.EmpresaId, pu.EmpresaFuncionalidadeId });

        }
    }
}
