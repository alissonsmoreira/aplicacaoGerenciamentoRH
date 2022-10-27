using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileHelpers;

namespace lurin.meurhonline.domain.layout.importacao.AvisoFerias
{

    public class LayoutAvisoFerias
    {
        public AvisoFeriasLinha2[] AvisoFeriasLinha2;
        public AvisoFeriasLinha9[] AvisoFeriasLinha9;
        public AvisoFeriasLinha14a20[] AvisoFeriasLinha14a20;
        public AvisoFeriasLinha22[] AvisoFeriasLinha22;
    }

    [FixedLengthRecord(FixedMode.AllowMoreChars)]
    public class AvisoFeriasLinha2
    {
        [FieldOptional]
        [FieldFixedLength(10)]
        public string Filler;

        [FieldOptional]
        [FieldFixedLength(4)]
        [FieldTrim(TrimMode.Both)]
        public string Estabelecimento;

        [FieldOptional]
        [FieldFixedLength(47)]
        public string Filler2;

        [FieldOptional]
        [FieldFixedLength(18)]
        [FieldTrim(TrimMode.Both)]
        public string CNPJ;
    }

    [FixedLengthRecord(FixedMode.AllowMoreChars)]
    public class AvisoFeriasLinha9
    {
        [FieldOptional]
        [FieldFixedLength(24)]
        public string Filler;

        [FieldOptional]
        [FieldFixedLength(12)]
        [FieldTrim(TrimMode.Both)]
        public string CPF;

        [FieldOptional]
        [FieldFixedLength(2)]
        public string Filler1;

        [FieldOptional]
        [FieldFixedLength(41)]
        [FieldTrim(TrimMode.Both)]
        public string Nome;
    }

    [FixedLengthRecord(FixedMode.AllowLessChars)]
    public class AvisoFeriasLinha14a20
    {
        [FieldOptional]
        [FieldFixedLength(1)]
        public string Filler;

        [FieldOptional]
        [FieldFixedLength(78)]
        [FieldTrim(TrimMode.Both)]
        public string Texto;

        [FieldOptional]
        [FieldFixedLength(1)]
        public string Filler2;
    }

    [FixedLengthRecord(FixedMode.AllowLessChars)]
    public class AvisoFeriasLinha22
    {
        [FieldOptional]
        [FieldFixedLength(2)]
        public string Filler;

        [FieldOptional]
        [FieldFixedLength(77)]
        [FieldTrim(TrimMode.Both)]
        public string LocalData;

        [FieldOptional]
        [FieldFixedLength(1)]
        public string Filler2;
    }
 }