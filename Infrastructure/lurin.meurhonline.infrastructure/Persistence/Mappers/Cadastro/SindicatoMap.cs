using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

using lurin.meurhonline.domain.model;

namespace lurin.meurhonline.infrastructure.persistence.mapper
{
    public class SindicatoMap : EntityTypeConfiguration<SindicatoModel>
    {
        public SindicatoMap()
        {
            ToTable("Sindicato");
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Nome).IsRequired();
            Property(x => x.Cnpj).IsRequired();
            Property(x => x.DataBaseMes).IsRequired();
            Property(x => x.DataBaseAno).IsRequired();
            Property(x => x.Representante).IsOptional();
            Property(x => x.TelefoneComercial).IsOptional();
            Property(x => x.TelefoneCelular).IsOptional();
            Property(x => x.DataCadastro).IsRequired();
        }
    }
}
