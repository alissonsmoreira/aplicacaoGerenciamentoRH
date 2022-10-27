using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

using lurin.meurhonline.domain.model;

namespace lurin.meurhonline.infrastructure.persistence.mapper
{
    public class HoleriteMap : EntityTypeConfiguration<HoleriteModel>
    {
        public HoleriteMap()
        {
            ToTable("Holerite");
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.ColaboradorId).IsRequired();
            Property(x => x.Mes).IsRequired();
            Property(x => x.Ano).IsRequired();
            Property(x => x.EmpresaId).IsOptional();
            Property(x => x.Matricula).IsOptional();
            Property(x => x.Nome).IsOptional();
            Property(x => x.TotalProventos).IsOptional();
            Property(x => x.TotalDescontos).IsOptional();
            Property(x => x.Liquido).IsOptional();
            Property(x => x.SalarioBase).IsOptional();
            Property(x => x.SalarioContrINSS).IsOptional();
            Property(x => x.BaseCalcFGTS).IsOptional();
            Property(x => x.FTGSMes).IsOptional();
            Property(x => x.BaseCalcIRRF).IsOptional();
            Property(x => x.DataCadastro).IsRequired();
        }
    }
}