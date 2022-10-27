using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileHelpers;

namespace lurin.meurhonline.domain.layout.importacao.Holerite
{

    public class LayoutHolerite
    {
        public HoleriteLinha3[] HoleriteLinha3;
        public HoleriteLinha7a23[] HoleriteLinha7a23;
        public HoleriteLinha24[] HoleriteLinha24;
        public HoleriteLinha26[] HoleriteLinha26;
        public HoleriteLinha28[] HoleriteLinha28;
    }

    [FixedLengthRecord(FixedMode.AllowMoreChars)]
    public class HoleriteLinha3
    {
        [FieldOptional]
        [FieldFixedLength(8)]
        [FieldTrim(TrimMode.Both)]
        public string Matricula;

        [FieldOptional]
        [FieldFixedLength(3)]
        public string Filler1;

        [FieldOptional]
        [FieldFixedLength(40)]
        [FieldTrim(TrimMode.Both)]
        public string Nome;
    }

    [FixedLengthRecord(FixedMode.AllowVariableLength)]
    public class HoleriteLinha7a23
    {
        [FieldOptional]
        [FieldFixedLength(4)]
        [FieldTrim(TrimMode.Both)]
        public string Evento;

        [FieldOptional]
        [FieldFixedLength(25)]
        [FieldTrim(TrimMode.Both)]
        public string Descricao;

        [FieldOptional]
        [FieldFixedLength(11)]
        [FieldTrim(TrimMode.Both)]
        public string Quantidade;

        [FieldOptional]
        [FieldFixedLength(15)]
        [FieldTrim(TrimMode.Both)]
        public string ValoresPositivos;

        [FieldOptional]
        [FieldFixedLength(14)]
        [FieldTrim(TrimMode.Both)]
        public string ValoresNegativos;
    }

    [FixedLengthRecord(FixedMode.AllowVariableLength)]
    public class HoleriteLinha24
    {
        [FieldOptional]
        [FieldFixedLength(40)]
        public string Filler;

        [FieldOptional]
        [FieldFixedLength(15)]
        [FieldTrim(TrimMode.Both)]
        public string TotalProventos;

        [FieldOptional]
        [FieldFixedLength(15)]
        [FieldTrim(TrimMode.Both)]
        public string TotalDescontos;
    }

    [FixedLengthRecord(FixedMode.AllowVariableLength)]
    public class HoleriteLinha26
    {
        [FieldOptional]
        [FieldFixedLength(55)]
        public string Filler1;

        [FieldOptional]
        [FieldFixedLength(15)]
        [FieldTrim(TrimMode.Both)]
        public string Liquido;
    }

    [FixedLengthRecord(FixedMode.AllowVariableLength)]
    public class HoleriteLinha28
    {
        [FieldOptional]
        [FieldFixedLength(12)]
        [FieldTrim(TrimMode.Both)]
        public string SalarioBase;

        [FieldOptional]
        [FieldFixedLength(14)]
        [FieldTrim(TrimMode.Both)]
        public string SalarioContrINSS;

        [FieldOptional]
        [FieldFixedLength(14)]
        [FieldTrim(TrimMode.Both)]
        public string BaseCalcFGTS;

        [FieldOptional]
        [FieldFixedLength(13)]
        [FieldTrim(TrimMode.Both)]
        public string FTGSMes;

        [FieldOptional]
        [FieldFixedLength(14)]
        [FieldTrim(TrimMode.Both)]
        public string BaseCalcIRRF;
    }
}
