using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

using lurin.meurhonline.domain.model;

namespace lurin.meurhonline.infrastructure.persistence.mapper
{
    public class DocumentoAdmissionalMap : EntityTypeConfiguration<DocumentoAdmissionalModel>
    {
        public DocumentoAdmissionalMap()
        {
            ToTable("DocumentoAdmissional");
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Nome).IsRequired();
            Property(x => x.DataCadastro).IsRequired();
        }
    }
}
