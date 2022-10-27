using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

using lurin.meurhonline.domain.model;

namespace lurin.meurhonline.infrastructure.persistence.mapper
{
    public class CartaoPontoCabecalhoMap : EntityTypeConfiguration<CartaoPontoCabecalhoModel>
    {
        public CartaoPontoCabecalhoMap()
        {
            ToTable("CartaoPontoCabecalho");
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.CartaoPontoId).IsRequired();
            Property(x => x.DataCadastro).IsRequired();

            Property(x => x.Estabelecimento).IsOptional();
            Property(x => x.Matricula).IsOptional();
            Property(x => x.DataInicioPeriodo).IsOptional();
            Property(x => x.DataTerminoPeriodo).IsOptional();
            Property(x => x.PeriodoBancoHoras).IsOptional();
            Property(x => x.HorasPositivas1).IsOptional();
            Property(x => x.HorasNegativas1).IsOptional();
            Property(x => x.SaldoMes1).IsOptional();
            Property(x => x.PeriodoDiaPonte).IsOptional();
            Property(x => x.HorasPositivas2).IsOptional();
            Property(x => x.HorasNegativas2).IsOptional();
            Property(x => x.SaldoMes2).IsOptional();
            Property(x => x.CodigoEvento1).IsOptional();
            Property(x => x.DescricaoEvento1).IsOptional();
            Property(x => x.QuantidadeHoras1).IsOptional();
            Property(x => x.HorasPositivasBancoHoras).IsOptional();
            Property(x => x.HorasPositivasDiaPonte).IsOptional();
            Property(x => x.CodigoEvento2).IsOptional();
            Property(x => x.DescricaoEvento2).IsOptional();
            Property(x => x.QuantidadeHoras2).IsOptional();
            Property(x => x.HorasNegativasBancoHoras).IsOptional();
            Property(x => x.HorasNegativasDiaPonte).IsOptional();
            Property(x => x.CodigoEvento3).IsOptional();
            Property(x => x.DescricaoEvento3).IsOptional();
            Property(x => x.QuantidadeHoras3).IsOptional();
            Property(x => x.SaldoBancoHoras).IsOptional();
            Property(x => x.SaldoDiaPonte).IsOptional();
            Property(x => x.CodigoEvento4).IsOptional();
            Property(x => x.DescricaoEvento4).IsOptional();
            Property(x => x.QuantidadeHoras4).IsOptional();
            Property(x => x.HrsPagasBancoHoras).IsOptional();
            Property(x => x.HrsPagasDiaPonte).IsOptional();
            Property(x => x.CodigoEvento5).IsOptional();
            Property(x => x.DescricaoEvento5).IsOptional();
            Property(x => x.QuantidadeHoras5).IsOptional();
            Property(x => x.HrsDescontadasBancoHoras).IsOptional();
            Property(x => x.HrsDescontadasDiaPonte).IsOptional();
            Property(x => x.CodigoEvento6).IsOptional();
            Property(x => x.DescricaoEvento6).IsOptional();
            Property(x => x.QuantidadeHoras6).IsOptional();
            Property(x => x.HrsCompensadasBancoHoras).IsOptional();
            Property(x => x.HrsCompensadasDiaPonte).IsOptional();
        }
    }
}

