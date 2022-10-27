using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

using lurin.meurhonline.domain.model;

namespace lurin.meurhonline.infrastructure.persistence.mapper
{
    public class DivergenciaLogMap : EntityTypeConfiguration<DivergenciaLogModel>
    {
        public DivergenciaLogMap()
        {
            ToTable("DivergenciaLog");
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Matricula).IsRequired();
            Property(x => x.LogErro).IsRequired();
            Property(x => x.DataCadastro).IsRequired();
        }
    }
}
