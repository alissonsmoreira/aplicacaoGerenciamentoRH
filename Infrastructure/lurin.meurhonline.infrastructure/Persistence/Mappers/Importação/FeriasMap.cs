using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

using lurin.meurhonline.domain.model;

namespace lurin.meurhonline.infrastructure.persistence.mapper
{
    public class FeriasMap : EntityTypeConfiguration<FeriasModel>
    {
        public FeriasMap()
        {
            ToTable("Ferias");
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.EmpresaId).IsRequired(); 
            Property(x => x.Estabelecimento).IsRequired();
            Property(x => x.DataCadastro).IsRequired();
        }
    }
}
