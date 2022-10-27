using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

using lurin.meurhonline.domain.model;

namespace lurin.meurhonline.infrastructure.persistence.mapper
{
    public class AvisoFeriasMap : EntityTypeConfiguration<AvisoFeriasModel>
    {
        public AvisoFeriasMap()
        {
            ToTable("AvisoFerias");
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.EmpresaId).IsOptional();
            Property(x => x.CPNJ).IsOptional();
            Property(x => x.Ano).IsRequired();
            Property(x => x.ColaboradorId).IsRequired();
            Property(x => x.Estabelecimento).IsOptional();
            Property(x => x.CPF).IsOptional();
            Property(x => x.Nome).IsOptional();
            Property(x => x.Texto).IsOptional();
            Property(x => x.LocalData).IsOptional();           
            Property(x => x.DataCadastro).IsRequired();
        }
    }
}

