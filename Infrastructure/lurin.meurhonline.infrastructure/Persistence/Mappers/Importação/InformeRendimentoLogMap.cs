using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

using lurin.meurhonline.domain.model;

namespace lurin.meurhonline.infrastructure.persistence.mapper
{
    public class InformeRendimentoLogMap : EntityTypeConfiguration<InformeRendimentoLogModel>
    {
        public InformeRendimentoLogMap()
        {
            ToTable("InformeRendimentoLog");
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.CPF).IsOptional();
            Property(x => x.LogErro).IsOptional();
            Property(x => x.DataCadastro).IsRequired();
        }
    }
}
