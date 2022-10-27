using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

using lurin.meurhonline.domain.model;

namespace lurin.meurhonline.infrastructure.persistence.mapper
{
    public class ColaboradorEmpregadorMap : EntityTypeConfiguration<ColaboradorEmpregadorModel>
    {
        public ColaboradorEmpregadorMap()
        {
            ToTable("ColaboradorEmpregador");
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.ColaboradorId).IsRequired();
            Property(x => x.CargoUnidadeId).IsRequired();
            Property(x => x.CentroCustoUnidadeId).IsRequired();
            Property(x => x.LotacaoUnidadeId).IsRequired();
            Property(x => x.TipoRegistroId).IsOptional();
            Property(x => x.TipoMaoObraId).IsOptional();
            Property(x => x.UnidadeNegocioId).IsOptional();
            Property(x => x.NumeroCartaoPonto).IsOptional();
            Property(x => x.Situacao).IsOptional();
            Property(x => x.TurnoId).IsOptional();
            Property(x => x.CategoriaSalarialId).IsOptional();
            Property(x => x.Salario).IsOptional();
            Property(x => x.DataAdmissao).IsOptional();
            Property(x => x.SindicatoId).IsOptional();
            Property(x => x.DataCadastro).IsRequired();
            Property(x => x.Salario).IsOptional();
        }
    }
}
