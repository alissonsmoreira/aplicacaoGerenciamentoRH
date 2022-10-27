using FileHelpers;

namespace lurin.meurhonline.domain.importacao.layout.divergencia
{
    [FixedLengthRecord(FixedMode.AllowMoreChars)]
    public class LinhaEstabelecimento
    {
        [FieldFixedLength(29)]
        public string Filler;

        [FieldFixedLength(11)]
        [FieldTrim(TrimMode.Both)]
        public string Estabelecimento;
    }
    [FixedLengthRecord(FixedMode.AllowMoreChars)]
    public class LinhaColaborador
    {
        [FieldFixedLength(5)]
        public string Filler;

        [FieldFixedLength(11)]
        [FieldTrim(TrimMode.Both)]
        public string Matricula;

        [FieldFixedLength(2)]
        public string Filler2;

        [FieldFixedLength(41)]
        [FieldTrim(TrimMode.Both)]
        public string Nome;
    }
    [FixedLengthRecord(FixedMode.AllowVariableLength)]
    public class Detalhe
    {
        [FieldFixedLength(4)]
        [FieldOptional]
        [FieldTrim(TrimMode.Both)]
        public string DiaSemana;

        [FieldFixedLength(10)]
        [FieldOptional]
        [FieldTrim(TrimMode.Both)]
        public string Dia;

        [FieldFixedLength(10)]
        [FieldOptional]
        public string Filler;

        [FieldFixedLength(5)]
        [FieldOptional]
        [FieldTrim(TrimMode.Both)]
        public string Horario1;

        [FieldFixedLength(4)]
        [FieldOptional]
        public string Filler2;

        [FieldFixedLength(5)]
        [FieldOptional]
        [FieldTrim(TrimMode.Both)]
        public string Horario2;

        [FieldFixedLength(4)]
        [FieldOptional]
        public string Filler3;

        [FieldFixedLength(5)]
        [FieldOptional]
        [FieldTrim(TrimMode.Both)]
        public string Horario3;

        [FieldFixedLength(4)]
        [FieldOptional]
        public string Filler4;

        [FieldFixedLength(5)]
        [FieldOptional]
        [FieldTrim(TrimMode.Both)]
        public string Horario4;

        [FieldFixedLength(5)]
        [FieldOptional]
        public string Filler5;

        [FieldFixedLength(5)]
        [FieldOptional]
        [FieldTrim(TrimMode.Both)]
        public string InicioJornada;

        [FieldFixedLength(2)]
        [FieldOptional]
        public string Filler6;

        [FieldFixedLength(5)]
        [FieldOptional]
        [FieldTrim(TrimMode.Both)]
        public string FimJornada;

        [FieldFixedLength(2)]
        [FieldOptional]
        public string Filler7;

        [FieldFixedLength(5)]
        [FieldOptional]
        [FieldTrim(TrimMode.Both)]
        public string DiferencaHoras;

        [FieldFixedLength(22)]
        [FieldOptional]
        public string Filler8;

        //[FieldFixedLength(16)]
        [FieldFixedLength(29)]
        [FieldOptional]
        [FieldTrim(TrimMode.Both)]
        public string Descricao;
    }

    //[FixedLengthRecord(FixedMode.AllowVariableLength)]
    
    //public class QuebraColaborador
    //{
    //    [FieldFixedLength(1)]
    //    public string Filler;
    //}
}


