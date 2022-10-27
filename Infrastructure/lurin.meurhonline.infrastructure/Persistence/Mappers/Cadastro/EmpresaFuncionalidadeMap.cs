using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

using lurin.meurhonline.domain.model;

namespace lurin.meurhonline.infrastructure.persistence.mapper
{
    public class EmpresaFuncionalidadeMap : EntityTypeConfiguration<EmpresaFuncionalidadeModel>
    {
        public EmpresaFuncionalidadeMap()
        {
            ToTable("EmpresaFuncionalidade");
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            Property(x => x.Grupo).IsRequired();
            Property(x => x.TipoFuncionario).IsRequired();
            Property(x => x.Nome).IsRequired();
        }
    }
}
