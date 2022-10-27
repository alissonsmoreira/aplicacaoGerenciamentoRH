using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

using lurin.meurhonline.domain.model;

namespace lurin.meurhonline.infrastructure.persistence.mapper
{
    public class ColaboradorDocumentoAdmissionalMap : EntityTypeConfiguration<ColaboradorDocumentoAdmissionalModel>
    {
        public ColaboradorDocumentoAdmissionalMap()
        {
            ToTable("ColaboradorDocumentoAdmissional");
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.ColaboradorId).IsRequired();
            Property(x => x.DocumentoAdmissionalId).IsRequired();
            Property(x => x.DocumentoNome).IsRequired();
            Property(x => x.DataCadastro).IsRequired();
        }
    }
}
