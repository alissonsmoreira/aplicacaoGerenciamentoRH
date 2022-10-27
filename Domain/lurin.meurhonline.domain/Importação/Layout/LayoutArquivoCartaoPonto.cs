using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileHelpers;

namespace lurin.meurhonline.domain.layout.importacao.cartaoponto
{

    public class LayoutArquivoCartaoPonto
    {}

    [FixedLengthRecord(FixedMode.AllowMoreChars)]
    public class CartaoPontoHeaderLinha5
    {
        [FieldFixedLength(19)]
        public string Filler;

        [FieldFixedLength(7)]
        [FieldTrim(TrimMode.Both)]
        public string Estabelecimento;
    }

    [FixedLengthRecord(FixedMode.AllowMoreChars)]
    public class CartaoPontoHeaderLinha6
    {
        [FieldFixedLength(19)]
        public string Filler;

        [FieldFixedLength(9)]
        [FieldTrim(TrimMode.Both)]
        public string Matricula;
    }

    [FixedLengthRecord(FixedMode.AllowLessChars)]
    public class CartaoPontoHeaderLinha8
    {
        [FieldFixedLength(66)]
        public string Filler;

        [FieldFixedLength(11)]
        [FieldTrim(TrimMode.Both)]
        public string DataInicioPeriodo;

        [FieldFixedLength(16)]
        public string Filler2;

        [FieldFixedLength(11)]
        [FieldTrim(TrimMode.Both)]
        public string DataTerminoPeriodo;
    }

    [FixedLengthRecord(FixedMode.AllowLessChars)]
    public class CartaoPontoDetalhesLinha14
    {
        [FieldFixedLength(3)]
        [FieldTrim(TrimMode.Both)]
        public string Dia;

        [FieldFixedLength(1)]
        [FieldTrim(TrimMode.Both)]
        public string Filler1;

        [FieldFixedLength(3)]
        [FieldTrim(TrimMode.Both)]
        public string DiaSemana;

        [FieldOptional]
        [FieldFixedLength(1)]
        [FieldTrim(TrimMode.Both)]
        public string Filler2;

        [FieldOptional]
        [FieldFixedLength(4)]
        [FieldTrim(TrimMode.Both)]
        public string NumeroJornada;

        [FieldOptional]
        [FieldFixedLength(1)]
        [FieldTrim(TrimMode.Both)]
        public string Filler3;

        [FieldOptional]
        [FieldFixedLength(2)]
        [FieldTrim(TrimMode.Both)]
        public string TipoDia;

        [FieldOptional]
        [FieldFixedLength(1)]
        [FieldTrim(TrimMode.Both)]
        public string Filler4;

        [FieldOptional]
        [FieldFixedLength(5)]
        [FieldTrim(TrimMode.Both)]
        public string Marcacao1;

        [FieldOptional]
        [FieldFixedLength(1)]
        [FieldTrim(TrimMode.Both)]
        public string Filler5;

        [FieldOptional]
        [FieldFixedLength(1)]
        [FieldTrim(TrimMode.Both)]
        public string TipoMarcacao1;

        [FieldOptional]
        [FieldFixedLength(1)]
        [FieldTrim(TrimMode.Both)]
        public string Filler6;

        [FieldOptional]
        [FieldFixedLength(5)]
        [FieldTrim(TrimMode.Both)]
        public string Marcacao2;

        [FieldOptional]
        [FieldFixedLength(1)]
        [FieldTrim(TrimMode.Both)]
        public string Filler7;

        [FieldOptional]
        [FieldFixedLength(1)]
        [FieldTrim(TrimMode.Both)]
        public string TipoMarcacao2;

        [FieldOptional]
        [FieldFixedLength(1)]
        [FieldTrim(TrimMode.Both)]
        public string Filler8;

        [FieldOptional]
        [FieldFixedLength(5)]
        [FieldTrim(TrimMode.Both)]
        public string Marcacao3;

        [FieldOptional]
        [FieldFixedLength(1)]
        [FieldTrim(TrimMode.Both)]
        public string Filler9;

        [FieldOptional]
        [FieldFixedLength(1)]
        [FieldTrim(TrimMode.Both)]
        public string TipoMarcacao3;

        [FieldOptional]
        [FieldFixedLength(1)]
        [FieldTrim(TrimMode.Both)]
        public string Filler10;

        [FieldOptional]
        [FieldFixedLength(5)]
        [FieldTrim(TrimMode.Both)]
        public string Marcacao4;

        [FieldOptional]
        [FieldFixedLength(1)]
        [FieldTrim(TrimMode.Both)]
        public string Filler11;

        [FieldOptional]
        [FieldFixedLength(1)]
        [FieldTrim(TrimMode.Both)]
        public string TipoMarcacao4;

        [FieldOptional]
        [FieldFixedLength(1)]
        [FieldTrim(TrimMode.Both)]
        public string Filler12;

        [FieldOptional]
        [FieldFixedLength(5)]
        [FieldTrim(TrimMode.Both)]
        public string Marcacao5;

        [FieldOptional]
        [FieldFixedLength(1)]
        [FieldTrim(TrimMode.Both)]
        public string Filler13;

        [FieldOptional]
        [FieldFixedLength(1)]
        [FieldTrim(TrimMode.Both)]
        public string TipoMarcacao5;

        [FieldOptional]
        [FieldFixedLength(1)]
        [FieldTrim(TrimMode.Both)]
        public string Filler14;

        [FieldOptional]
        [FieldFixedLength(5)]
        [FieldTrim(TrimMode.Both)]
        public string Marcacao6;

        [FieldOptional]
        [FieldFixedLength(1)]
        [FieldTrim(TrimMode.Both)]
        public string Filler15;

        [FieldOptional]
        [FieldFixedLength(1)]
        [FieldTrim(TrimMode.Both)]
        public string TipoMarcacao6;

        [FieldOptional]
        [FieldFixedLength(1)]
        [FieldTrim(TrimMode.Both)]
        public string Filler16;

        [FieldOptional]
        [FieldFixedLength(5)]
        [FieldTrim(TrimMode.Both)]
        public string Marcacao7;

        [FieldOptional]
        [FieldFixedLength(1)]
        [FieldTrim(TrimMode.Both)]
        public string Filler17;

        [FieldOptional]
        [FieldFixedLength(1)]
        [FieldTrim(TrimMode.Both)]
        public string TipoMarcacao7;

        [FieldOptional]
        [FieldFixedLength(1)]
        [FieldTrim(TrimMode.Both)]
        public string Filler18;

        [FieldOptional]
        [FieldFixedLength(5)]
        [FieldTrim(TrimMode.Both)]
        public string Marcacao8;

        [FieldOptional]
        [FieldFixedLength(1)]
        [FieldTrim(TrimMode.Both)]
        public string Filler19;

        [FieldOptional]
        [FieldFixedLength(1)]
        [FieldTrim(TrimMode.Both)]
        public string TipoMarcacao8;

        [FieldOptional]
        [FieldFixedLength(7)]
        [FieldTrim(TrimMode.Both)]
        public string Filler20;

        [FieldOptional]
        [FieldFixedLength(5)]
        [FieldTrim(TrimMode.Both)]
        public string InicioJornada;

        [FieldOptional]
        [FieldFixedLength(1)]
        [FieldTrim(TrimMode.Both)]
        public string Filler21;

        [FieldOptional]
        [FieldFixedLength(5)]
        [FieldTrim(TrimMode.Both)]
        public string TerminoJornada;

        [FieldOptional]
        [FieldFixedLength(1)]
        [FieldTrim(TrimMode.Both)]
        public string Filler22;

        [FieldOptional]
        [FieldFixedLength(5)]
        [FieldTrim(TrimMode.Both)]
        public string QuantHoras;

        [FieldOptional]
        [FieldFixedLength(1)]
        [FieldTrim(TrimMode.Both)]
        public string Filler23;

        [FieldOptional]
        [FieldFixedLength(50)]
        [FieldTrim(TrimMode.Both)]
        public string DescricaoOcorrencia;
    }

    [FixedLengthRecord(FixedMode.AllowLessChars)]
    public class CartaoPontoSaldoHorasLinha1
    {
        [FieldFixedLength(58)]
        [FieldTrim(TrimMode.Both)]
        public string PeriodoBancoHoras;
    }

    [FixedLengthRecord(FixedMode.AllowLessChars)]
    public class CartaoPontoSaldoHorasLinha2
    {
        [FieldFixedLength(19)]
        public string Filler1;

        [FieldFixedLength(7)]
        [FieldTrim(TrimMode.Both)]
        public string HorasPositivas;

        [FieldFixedLength(27)]
        public string Filler2;

        [FieldFixedLength(7)]
        [FieldTrim(TrimMode.Both)]
        public string HorasNegativas;

        [FieldFixedLength(40)]
        public string Filler3;

        [FieldFixedLength(11)]
        [FieldTrim(TrimMode.Both)]
        public string SaldoMes;
    }

    [FixedLengthRecord(FixedMode.AllowLessChars)]
    public class CartaoPontoSaldoHorasLinha4
    {
        [FieldFixedLength(65)]
        [FieldTrim(TrimMode.Both)]
        public string PeriodoDiaPonte;
    }

    [FixedLengthRecord(FixedMode.AllowLessChars)]
    public class CartaoPontoSaldoHorasLinha5
    {
        [FieldFixedLength(19)]
        public string Filler1;

        [FieldFixedLength(7)]
        [FieldTrim(TrimMode.Both)]
        public string HorasPositivas;

        [FieldFixedLength(27)]
        public string Filler2;

        [FieldFixedLength(7)]
        [FieldTrim(TrimMode.Both)]
        public string HorasNegativas;

        [FieldFixedLength(40)]
        public string Filler3;

        [FieldFixedLength(11)]
        [FieldTrim(TrimMode.Both)]
        public string SaldoMes;
    }

    [FixedLengthRecord(FixedMode.AllowLessChars)]
    public class CartaoPontoSaldoHorasLinha10
    {
        [FieldFixedLength(3)]
        [FieldTrim(TrimMode.Both)]
        public string CodigoEvento;

        [FieldFixedLength(2)]
        public string Filler1;

        [FieldFixedLength(30)]
        [FieldTrim(TrimMode.Both)]
        public string DescricaoEvento;

        [FieldFixedLength(1)]
        public string Filler3;

        [FieldFixedLength(11)]
        [FieldTrim(TrimMode.Both)]
        public string QuantidadeHoras;

        [FieldFixedLength(20)]
        public string Filler4;

        [FieldFixedLength(15)]
        [FieldTrim(TrimMode.Both)]
        public string HorasPositivasBancoHoras;

        [FieldFixedLength(18)]
        public string Filler5;

        [FieldFixedLength(9)]
        [FieldTrim(TrimMode.Both)]
        public string HorasPositivasDiaPonte;
    }

    [FixedLengthRecord(FixedMode.AllowLessChars)]
    public class CartaoPontoSaldoHorasLinha11
    {
        [FieldFixedLength(3)]
        [FieldTrim(TrimMode.Both)]
        public string CodigoEvento;

        [FieldFixedLength(2)]
        public string Filler1;

        [FieldFixedLength(30)]
        [FieldTrim(TrimMode.Both)]
        public string DescricaoEvento;

        [FieldFixedLength(1)]
        public string Filler3;

        [FieldFixedLength(11)]
        [FieldTrim(TrimMode.Both)]
        public string QuantidadeHoras;

        [FieldFixedLength(20)]
        public string Filler4;

        [FieldFixedLength(15)]
        [FieldTrim(TrimMode.Both)]
        public string HorasNegativasBancoHoras;

        [FieldFixedLength(18)]
        public string Filler5;

        [FieldFixedLength(9)]
        [FieldTrim(TrimMode.Both)]
        public string HorasNegativasDiaPonte;
    }

    [FixedLengthRecord(FixedMode.AllowLessChars)]
    public class CartaoPontoSaldoHorasLinha12
    {
        [FieldFixedLength(3)]
        [FieldTrim(TrimMode.Both)]
        public string CodigoEvento;

        [FieldFixedLength(2)]
        public string Filler1;

        [FieldFixedLength(30)]
        [FieldTrim(TrimMode.Both)]
        public string DescricaoEvento;

        [FieldFixedLength(1)]
        public string Filler3;

        [FieldFixedLength(11)]
        [FieldTrim(TrimMode.Both)]
        public string QuantidadeHoras;

        [FieldFixedLength(20)]
        public string Filler4;

        [FieldFixedLength(15)]
        [FieldTrim(TrimMode.Both)]
        public string SaldoBancoHoras;

        [FieldFixedLength(18)]
        public string Filler5;

        [FieldFixedLength(9)]
        [FieldTrim(TrimMode.Both)]
        public string SaldoDiaPonte;
    }

    [FixedLengthRecord(FixedMode.AllowLessChars)]
    public class CartaoPontoSaldoHorasLinha13
    {
        [FieldFixedLength(3)]
        [FieldTrim(TrimMode.Both)]
        public string CodigoEvento;

        [FieldFixedLength(2)]
        public string Filler1;

        [FieldFixedLength(30)]
        [FieldTrim(TrimMode.Both)]
        public string DescricaoEvento;

        [FieldFixedLength(1)]
        public string Filler3;

        [FieldFixedLength(11)]
        [FieldTrim(TrimMode.Both)]
        public string QuantidadeHoras;

        [FieldFixedLength(20)]
        public string Filler4;

        [FieldFixedLength(15)]
        [FieldTrim(TrimMode.Both)]
        public string HrsPagasBancoHoras;

        [FieldFixedLength(18)]
        public string Filler5;

        [FieldFixedLength(9)]
        [FieldTrim(TrimMode.Both)]
        public string HrsPagasDiaPonte;
    }

    [FixedLengthRecord(FixedMode.AllowLessChars)]
    public class CartaoPontoSaldoHorasLinha14
    {
        [FieldFixedLength(3)]
        [FieldTrim(TrimMode.Both)]
        public string CodigoEvento;

        [FieldFixedLength(2)]
        public string Filler1;

        [FieldFixedLength(30)]
        [FieldTrim(TrimMode.Both)]
        public string DescricaoEvento;

        [FieldFixedLength(1)]
        public string Filler3;

        [FieldFixedLength(11)]
        [FieldTrim(TrimMode.Both)]
        public string QuantidadeHoras;

        [FieldFixedLength(20)]
        public string Filler4;

        [FieldFixedLength(15)]
        [FieldTrim(TrimMode.Both)]
        public string HrsDescontadasBancoHoras;

        [FieldFixedLength(18)]
        public string Filler5;

        [FieldFixedLength(9)]
        [FieldTrim(TrimMode.Both)]
        public string HrsDescontadasDiaPonte;
    }

    [FixedLengthRecord(FixedMode.AllowLessChars)]
    public class CartaoPontoSaldoHorasLinha15
    {
        [FieldFixedLength(3)]
        [FieldTrim(TrimMode.Both)]
        public string CodigoEvento;

        [FieldFixedLength(2)]
        public string Filler1;

        [FieldFixedLength(30)]
        [FieldTrim(TrimMode.Both)]
        public string DescricaoEvento;

        [FieldFixedLength(1)]
        public string Filler3;

        [FieldFixedLength(11)]
        [FieldTrim(TrimMode.Both)]
        public string QuantidadeHoras;

        [FieldFixedLength(20)]
        public string Filler4;

        [FieldFixedLength(15)]
        [FieldTrim(TrimMode.Both)]
        public string HrsCompensadasBancoHoras;

        [FieldFixedLength(18)]
        public string Filler5;

        [FieldFixedLength(9)]
        [FieldTrim(TrimMode.Both)]
        public string HrsCompensadasDiaPonte;
    }

    [FixedLengthRecord(FixedMode.AllowLessChars)]
    public class CartaoPontoSaldoHorasLinha128
    {
        [FieldOptional]
        [FieldFixedLength(132)]
        [FieldTrim(TrimMode.Both)]
        public string UltimaLinha;
    }
}