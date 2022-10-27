using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

using lurin.meurhonline.domain.model;

namespace lurin.meurhonline.infrastructure.persistence.mapper
{
    public class AbsenteismoLogMap : EntityTypeConfiguration<AbsenteismoLogModel>
    {
        public AbsenteismoLogMap()
        {
            ToTable("AbsenteismoLog");
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Cpf).IsRequired();
            Property(x => x.LogErro).IsRequired();
            Property(x => x.DataCadastro).IsRequired();
        }
    }
}
