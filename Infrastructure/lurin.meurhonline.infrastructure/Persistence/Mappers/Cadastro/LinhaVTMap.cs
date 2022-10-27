using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

using lurin.meurhonline.domain.model;

namespace lurin.meurhonline.infrastructure.persistence.mapper
{
    public class LinhaVTMap : EntityTypeConfiguration<LinhaVTModel>
    {
        public LinhaVTMap()
        {
            ToTable("LinhaVT");
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.NomeLinha).IsRequired();
            Property(x => x.ValorLinha).IsRequired();
            Property(x => x.OperadoraVTId).IsRequired();
            Property(x => x.DataCadastro).IsRequired();
        }
    }
}
