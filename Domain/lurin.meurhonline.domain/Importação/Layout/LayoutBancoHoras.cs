using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileHelpers;

namespace lurin.meurhonline.domain.layout.importacao.Bancohoras
{

    public class LayoutBancoHoras
    {
        public BancoHorasCabecalho[] bancoHorasCabecalho;
        public BancoHorasLinhaDetalhe[] bancoHorasLinhaDetalhe;
        
    }


    [FixedLengthRecord(FixedMode.AllowLessChars)]
    public class BancoHorasLinhaDetalhe
    {
        [FieldFixedLength(8)]
        [FieldTrim(TrimMode.Both)]
        public string Matricula;

        [FieldFixedLength(8)]
        public string Filler1;

        [FieldFixedLength(40)]
        [FieldTrim(TrimMode.Both)]
        public string ColaboradorNome;

        [FieldFixedLength(6)]
        public string Filler2;

        [FieldFixedLength(12)]
        [FieldTrim(TrimMode.Both)]
        public string HorasPositivas;

        [FieldFixedLength(6)]
        public string Filler3;

        [FieldFixedLength(12)]
        [FieldTrim(TrimMode.Both)]
        public string HorasNegativas;

        [FieldFixedLength(6)]
        public string Filler4;

        [FieldFixedLength(12)]
        [FieldTrim(TrimMode.Both)]
        public string HoraSaldo;
    }

    [FixedLengthRecord(FixedMode.AllowLessChars)]
    public class BancoHorasCabecalho
    {
        [FieldFixedLength(19)]
        public string Filler1;

        [FieldFixedLength(7)]
        [FieldTrim(TrimMode.Both)]
        public string Estabelecimento;

        [FieldFixedLength(69)]
        [FieldTrim(TrimMode.Both)]
        public string Filler2;

    }

}