using FileHelpers;

namespace lurin.meurhonline.domain.importacao.layout.ReciboFerias
{
    [FixedLengthRecord(FixedMode.AllowMoreChars)]
    public class LinhaEstabelecimento
    {
        [FieldFixedLength(11)]
        public string Filler;

        [FieldFixedLength(3)]
        [FieldTrim(TrimMode.Both)]
        public string Estabelecimento;
    }
    [FixedLengthRecord(FixedMode.AllowMoreChars)]
    public class LinhaColaborador
    {
        [FieldFixedLength(24)]
        public string Filler;

        [FieldFixedLength(12)]
        [FieldTrim(TrimMode.Both)]
        public string CPF;

        [FieldFixedLength(42)]
        [FieldTrim(TrimMode.Both)]
        public string Nome;
    }
    [FixedLengthRecord(FixedMode.AllowMoreChars)]
    public class PeriodoAquisitivo
    {
        [FieldFixedLength(30)]
        public string Filler;

        [FieldFixedLength(10)]
        [FieldTrim(TrimMode.Both)]
        public string InicioPeriodo;

        [FieldFixedLength(03)]
        public string Filler2;

        [FieldFixedLength(10)]
        [FieldTrim(TrimMode.Both)]
        public string FimPeriodo;
    }
    [FixedLengthRecord(FixedMode.AllowMoreChars)]
    public class PeriodoGozo
    {
        [FieldFixedLength(30)]
        public string Filler;

        [FieldFixedLength(10)]
        [FieldTrim(TrimMode.Both)]
        public string InicioPeriodo;

        [FieldFixedLength(03)]
        public string Filler2;

        [FieldFixedLength(10)]
        [FieldTrim(TrimMode.Both)]
        public string FimPeriodo;
        
        [FieldFixedLength(21)]
        public string Filler3;

        [FieldFixedLength(5)]
        [FieldTrim(TrimMode.Both)]
        public string DiasGozo;
    }
    [FixedLengthRecord(FixedMode.AllowMoreChars)]
    public class PeriodoAbono
    {
        [FieldFixedLength(30)]
        public string Filler;

        [FieldFixedLength(10)]
        [FieldTrim(TrimMode.Both)]
        public string InicioPeriodo;

        [FieldFixedLength(03)]
        public string Filler2;

        [FieldFixedLength(10)]
        [FieldTrim(TrimMode.Both)]
        public string FimPeriodo;
    }
    [FixedLengthRecord(FixedMode.AllowMoreChars)]
    public class PeriodoLicenca
    {
        [FieldFixedLength(30)]
        public string Filler;

        [FieldFixedLength(10)]
        [FieldTrim(TrimMode.Both)]
        public string InicioPeriodo;

        [FieldFixedLength(03)]
        public string Filler2;

        [FieldFixedLength(10)]
        [FieldTrim(TrimMode.Both)]
        public string FimPeriodo;
    }
    [FixedLengthRecord(FixedMode.AllowMoreChars)]
    public class Vencimento
    {
        [FieldFixedLength(5)]
        public string Filler;

        [FieldFixedLength(6)]
        [FieldTrim(TrimMode.Both)]
        public string Evento;

        [FieldFixedLength(33)]
        [FieldTrim(TrimMode.Both)]
        public string Descricao;

        [FieldFixedLength(17)]
        [FieldTrim(TrimMode.Both)]
        public string BaseCalculo;

        [FieldFixedLength(18)]
        [FieldTrim(TrimMode.Both)]
        public string Valor;
    }
    [FixedLengthRecord(FixedMode.AllowMoreChars)]
    public class TotalVencimento
    {
        [FieldFixedLength(61)]
        public string Filler;
        [FieldFixedLength(14)]
        [FieldTrim(TrimMode.Both)]
        public string ValorVencimento;
    }
    [FixedLengthRecord(FixedMode.AllowMoreChars)]
    public class Desconto
    {
        [FieldFixedLength(5)]
        public string Filler;

        [FieldFixedLength(6)]
        [FieldTrim(TrimMode.Both)]
        public string Evento;

        [FieldFixedLength(33)]
        [FieldTrim(TrimMode.Both)]
        public string Descricao;

        [FieldFixedLength(17)]
        [FieldTrim(TrimMode.Both)]
        public string BaseCalculo;

        [FieldFixedLength(18)]
        [FieldTrim(TrimMode.Both)]
        public string Valor;
    }
    [FixedLengthRecord(FixedMode.AllowMoreChars)]
    public class TotalDesconto
    {
        [FieldFixedLength(61)]
        public string Filler;
        [FieldFixedLength(14)]
        [FieldTrim(TrimMode.Both)]
        public string ValorDesconto;
    }
    [FixedLengthRecord(FixedMode.AllowMoreChars)]
    public class Liquido
    {
        [FieldFixedLength(61)]
        public string Filler;
        [FieldFixedLength(14)]
        [FieldTrim(TrimMode.Both)]
        public string ValorLiquido;
    }
    [FixedLengthRecord(FixedMode.AllowMoreChars)]
    public class TextoFinal
    {
        [FieldFixedLength(2)]
        public string Filler;
        [FieldFixedLength(77)]
        [FieldTrim(TrimMode.Both)]
        public string Texto;
    }
    [FixedLengthRecord(FixedMode.AllowMoreChars)]
    public class LocalDataFinal
    {
        [FieldFixedLength(2)]
        public string Filler;
        [FieldFixedLength(77)]
        [FieldTrim(TrimMode.Both)]
        public string LocalData;
    }
    [FixedLengthRecord(FixedMode.AllowMoreChars)]
    public class QuebraPagina
    {
        [FieldFixedLength(1)]
        public string Filler;

    }
}


