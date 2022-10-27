using FileHelpers;

namespace lurin.meurhonline.domain.importacao.layout.Ferias
{
    [FixedLengthRecord(FixedMode.AllowMoreChars)]
    [IgnoreEmptyLines]
    public class Estabelecimento
    {
        [FieldFixedLength(16)]
        [FieldOptional]
        public string Filler;

        [FieldFixedLength(7)]
        [FieldTrim(TrimMode.Both)]
        [FieldOptional]
        public string codEstabelecimento;
    }

    [FixedLengthRecord(FixedMode.AllowVariableLength)]
    [IgnoreEmptyLines]
    public class Detalhe
    {
        [FieldFixedLength(8)]
        [FieldOptional]
        [FieldTrim(TrimMode.Both)]
        public string Matricula;

        [FieldFixedLength(4)]
        [FieldOptional]
        public string Filler;

        [FieldFixedLength(26)]
        [FieldOptional]
        [FieldTrim(TrimMode.Both)]
        public string Nome;

        [FieldFixedLength(11)]
        [FieldOptional]
        [FieldTrim(TrimMode.Both)]
        public string InicioPeriodo;

        [FieldFixedLength(10)]
        [FieldOptional]
        [FieldTrim(TrimMode.Both)]
        public string FimPeriodo;

        [FieldFixedLength(4)]
        [FieldOptional]
        [FieldTrim(TrimMode.Both)]
        public string Situacao;

        [FieldFixedLength(22)]
        [FieldOptional]
        public string Filler4;

        [FieldFixedLength(5)]
        [FieldOptional]
        [FieldTrim(TrimMode.Both)]
        public string DiasDireito;

        [FieldFixedLength(5)]
        [FieldOptional]
        [FieldTrim(TrimMode.Both)]
        public string DiasConcedido;

        [FieldFixedLength(5)]
        [FieldOptional]
        [FieldTrim(TrimMode.Both)]
        public string DiasProgramado;

        [FieldFixedLength(10)]
        [FieldOptional]
        [FieldTrim(TrimMode.Both)]
        public string InicioFerias;

        [FieldFixedLength(1)]
        [FieldOptional]
        public string Filler5;

        [FieldFixedLength(5)]
        [FieldOptional]
        [FieldTrim(TrimMode.Both)]
        public string DiasGozo;

        [FieldFixedLength(5)]
        [FieldOptional]
        [FieldTrim(TrimMode.Both)]
        public string DiasAbono;

        [FieldFixedLength(5)]
        [FieldOptional]
        [FieldTrim(TrimMode.Both)]
        public string DiasLicenca;

        [FieldFixedLength(5)]
        [FieldOptional]
        [FieldTrim(TrimMode.Both)]
        public string Saldo;
    }
}
    

