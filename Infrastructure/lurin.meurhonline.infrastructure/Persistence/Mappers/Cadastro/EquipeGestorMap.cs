using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

using lurin.meurhonline.domain.model;

namespace lurin.meurhonline.infrastructure.persistence.mapper
{
    public class EquipeGestorMap : EntityTypeConfiguration<EquipeGestorModel>
    {
        public EquipeGestorMap()
        {
            ToTable("EquipeGestor");
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.ColaboradorId).IsRequired();
            Property(x => x.LotacaoUnidadeInicialId).IsRequired();
            Property(x => x.LotacaoUnidadeFinalId).IsRequired();
            Property(x => x.DataCadastro).IsRequired();
        }
    }
}
