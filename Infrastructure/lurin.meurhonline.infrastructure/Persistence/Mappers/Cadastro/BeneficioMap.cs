using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

using lurin.meurhonline.domain.model;

namespace lurin.meurhonline.infrastructure.persistence.mapper
{
    public class BeneficioMap : EntityTypeConfiguration<BeneficioModel>
    {
        public BeneficioMap()
        {
            ToTable("Beneficio");
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Nome).IsRequired();
            Property(x => x.RegraDesconto).IsRequired();
            Property(x => x.CustoBeneficio).IsRequired();
            Property(x => x.BeneficioTipoId).IsRequired();
            Property(x => x.DataCadastro).IsRequired();
        }
    }
}
