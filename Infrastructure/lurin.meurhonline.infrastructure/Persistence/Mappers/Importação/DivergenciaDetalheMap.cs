using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

using lurin.meurhonline.domain.model;

namespace lurin.meurhonline.infrastructure.persistence.mapper
{
    public class DivergenciaDetalheMap : EntityTypeConfiguration<DivergenciaDetalheModel>
    {
        public DivergenciaDetalheMap()
        {
            ToTable("DivergenciaDetalhe");
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.DiaSemana).IsOptional();
            Property(x => x.Dia).IsOptional();
            Property(x => x.Horario1).IsOptional();
            Property(x => x.Horario2).IsOptional();
            Property(x => x.Horario3).IsOptional();
            Property(x => x.Horario4).IsOptional();
            Property(x => x.InicioJornada).IsOptional();
            Property(x => x.FimJornada).IsOptional();
            Property(x => x.DiferencaHoras).IsOptional();
            Property(x => x.DivergenciaId).IsRequired();
            Property(x => x.MotivoAprovacao).IsOptional();
            Property(x => x.SolicitacaoStatusId).IsRequired();
            Property(x => x.DataConclusao).IsOptional();
            Property(x => x.JustificativaDivergenciaId).IsOptional();
        }
    }
}
