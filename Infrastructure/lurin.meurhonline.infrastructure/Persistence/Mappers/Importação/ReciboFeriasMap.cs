using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

using lurin.meurhonline.domain.model;

namespace lurin.meurhonline.infrastructure.persistence.mapper
{
    public class ReciboFeriasMap : EntityTypeConfiguration<ReciboFeriasModel>
    {
        public ReciboFeriasMap()
        {
            ToTable("ReciboFerias");
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Ano).IsRequired();
            Property(x => x.Estabelecimento).IsRequired();
            Property(x => x.EmpresaId).IsOptional();
            Property(x => x.ColaboradorId).IsRequired();
            Property(x => x.InicioPeriodoAquisitivo).IsOptional();
            Property(x => x.FImPeriodoAquisitivo).IsOptional();
            Property(x => x.InicioPeriodoGozo).IsOptional();
            Property(x => x.FimPeriodoGozo).IsOptional();
            Property(x => x.DiasGozo).IsOptional();
            Property(x => x.InicioPeriodoAbono).IsOptional();
            Property(x => x.FimPeriodoAbono).IsOptional();
            Property(x => x.InicioPeriodoLicenca).IsOptional();
            Property(x => x.FimPeriodoLicenca).IsOptional();
            Property(x => x.TotalVencimento).IsOptional();
            Property(x => x.TotalDescontos).IsOptional();
            Property(x => x.TotalLiquido).IsOptional();
            Property(x => x.Texto).IsOptional();
            Property(x => x.LocalData).IsOptional();
            Property(x => x.DataCadastro).IsRequired();
        }
    }
}
