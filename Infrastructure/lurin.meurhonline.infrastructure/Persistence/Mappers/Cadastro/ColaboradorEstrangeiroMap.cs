using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

using lurin.meurhonline.domain.model;

namespace lurin.meurhonline.infrastructure.persistence.mapper
{
    public class ColaboradorEstrangeiroMap : EntityTypeConfiguration<ColaboradorEstrangeiroModel>
    {
        public ColaboradorEstrangeiroMap()
        {
            ToTable("ColaboradorEstrangeiro");
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.ColaboradorId).IsRequired();
            Property(x => x.Origem).IsRequired();
            Property(x => x.ColaboradorEstrangeiroTipoVistoId).IsRequired();
            Property(x => x.Passaporte).IsRequired();
            Property(x => x.OrgaoEmissorPassaporte).IsOptional();
            Property(x => x.PaisEmissorPassaporte).IsOptional();
            Property(x => x.UFPassaporte).IsOptional();
            Property(x => x.DataEmissaoPassaporte).IsOptional();
            Property(x => x.PortariaNaturalizacao).IsOptional();
            Property(x => x.IdentidadeEstrangeira).IsOptional();
            Property(x => x.ValidadeIdentidadeEstrangeira).IsOptional();
            Property(x => x.AnoChegada).IsOptional();
            Property(x => x.DataCadastro).IsRequired();
        }
    }
}
