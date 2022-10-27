using FileHelpers;

namespace lurin.meurhonline.domain.importacao.layout.InformeRendimento
{
    [FixedLengthRecord(FixedMode.AllowMoreChars)]
    public class IRCabecalho2
    {
        [FieldFixedLength(02)]
        public string Filler;

        [FieldFixedLength(38)]
        [FieldTrim(TrimMode.Both)]
        public string Ministerio;

        [FieldFixedLength(01)]
        public string Filler2;

        [FieldFixedLength(38)]
        [FieldTrim(TrimMode.Both)]
        public string TipoDocumento;
    }
    [FixedLengthRecord(FixedMode.AllowMoreChars)]
    public class IRCabecalho3
    {
        [FieldFixedLength(41)]
        public string Filler;

        [FieldFixedLength(38)]
        [FieldTrim(TrimMode.Both)]
        public string ContinuacaoTipoDocumento;
    }
    [FixedLengthRecord(FixedMode.AllowMoreChars)]
    public class IRCabecalho4
    {
        [FieldFixedLength(2)]
        public string Filler;

        [FieldFixedLength(38)]
        [FieldTrim(TrimMode.Both)]
        public string Secretaria;

        [FieldFixedLength(01)]
        public string Filler2;


        [FieldFixedLength(38)]
        [FieldTrim(TrimMode.Both)]
        public string Documento;
    }
    [FixedLengthRecord(FixedMode.AllowMoreChars)]
    public class IRCabecalho5
    {
        [FieldFixedLength(2)]
        public string Filler;

        [FieldFixedLength(38)]
        [FieldTrim(TrimMode.Both)]
        public string Exercicio;

        [FieldFixedLength(01)]
        public string Filler2;


        [FieldFixedLength(38)]
        [FieldTrim(TrimMode.Both)]
        public string AnoCalendario;
    }

    [FixedLengthRecord(FixedMode.AllowMoreChars)]
    public class IRSessao1Linha1
    {
        [FieldFixedLength(2)]
        public string Filler;

        [FieldFixedLength(77)]
        [FieldTrim(TrimMode.Both)]
        public string FontePagadora;
    }

    [FixedLengthRecord(FixedMode.AllowMoreChars)]
    public class IRSessao1Linha2
    {
        [FieldFixedLength(2)]
        public string Filler;

        [FieldFixedLength(56)]
        [FieldTrim(TrimMode.Both)]
        public string Empresa;

        [FieldFixedLength(21)]
        [FieldTrim(TrimMode.Both)]
        public string CNPJ;
    }

    [FixedLengthRecord(FixedMode.AllowMoreChars)]
    public class IRSessao2Linha1
    {
        [FieldFixedLength(2)]
        public string Filler;

        [FieldFixedLength(77)]
        [FieldTrim(TrimMode.Both)]
        public string DadosPessoaFisica;
    }

    [FixedLengthRecord(FixedMode.AllowMoreChars)]
    public class IRSessao2Linha2
    {
        [FieldFixedLength(5)]
        public string Filler;

        [FieldFixedLength(20)]
        [FieldTrim(TrimMode.Both)]
        public string DescricaoCPF;

        [FieldFixedLength(54)]
        [FieldTrim(TrimMode.Both)]
        public string CPF;
    }

    [FixedLengthRecord(FixedMode.AllowMoreChars)]
    public class IRSessao2Linha3
    {
        [FieldFixedLength(5)]
        public string Filler;

        [FieldFixedLength(20)]
        [FieldTrim(TrimMode.Both)]
        public string DescricaoNome;

        [FieldFixedLength(54)]
        [FieldTrim(TrimMode.Both)]
        public string Nome;
    }

    [FixedLengthRecord(FixedMode.AllowMoreChars)]
    public class IRSessao2Linha4
    {
        [FieldFixedLength(5)]
        public string Filler;

        [FieldFixedLength(20)]
        [FieldTrim(TrimMode.Both)]
        public string DescricaoNatureza;

        [FieldFixedLength(54)]
        [FieldTrim(TrimMode.Both)]
        public string Natureza;
    }

    [FixedLengthRecord(FixedMode.AllowMoreChars)]
    public class IRRendimentosSessaoTributaveis
    {
        [FieldFixedLength(2)]
        public string Filler;

        [FieldFixedLength(61)]
        [FieldTrim(TrimMode.Both)]
        public string TipoRendimento;

        [FieldFixedLength(1)]
        public string Filler2;

        [FieldFixedLength(15)]
        [FieldTrim(TrimMode.Both)]
        public string Moeda;
    }

    [FixedLengthRecord(FixedMode.AllowMoreChars)]
    public class IRRendimentosTributaveis
    {
        [FieldFixedLength(5)]
        public string Filler;

        [FieldFixedLength(58)]
        [FieldTrim(TrimMode.Both)]
        public string TipoEvento;

        [FieldFixedLength(1)]
        public string Filler2;

        [FieldFixedLength(15)]
        [FieldTrim(TrimMode.Both)]
        public string Valor;
    }

    [FixedLengthRecord(FixedMode.AllowMoreChars)]
    public class IRRendimentosSessaoIsentos
    {
        [FieldFixedLength(2)]
        public string Filler;

        [FieldFixedLength(61)]
        [FieldTrim(TrimMode.Both)]
        public string TipoRendimento;

        [FieldFixedLength(1)]
        public string Filler2;

        [FieldFixedLength(15)]
        [FieldTrim(TrimMode.Both)]
        public string Moeda;
    }
    [FixedLengthRecord(FixedMode.AllowMoreChars)]
    public class IRRendimentosIsentos
    {
        [FieldFixedLength(5)]
        public string Filler;

        [FieldFixedLength(58)]
        [FieldTrim(TrimMode.Both)]
        public string TipoEvento;

        [FieldFixedLength(1)]
        public string Filler2;

        [FieldFixedLength(15)]
        [FieldTrim(TrimMode.Both)]
        public string Valor;
    }
    [FixedLengthRecord(FixedMode.AllowMoreChars)]
    public class IRRendimentosSessaoSujeitoTrib
    {
        [FieldFixedLength(2)]
        public string Filler;

        [FieldFixedLength(67)]
        [FieldTrim(TrimMode.Both)]
        public string TipoRendimento;

        [FieldFixedLength(10)]
        [FieldTrim(TrimMode.Both)]
        public string Moeda;
    }
    [FixedLengthRecord(FixedMode.AllowMoreChars)]
    public class IRRendimentosSujeitoTrib
    {
        [FieldFixedLength(5)]
        public string Filler;

        [FieldFixedLength(58)]
        [FieldTrim(TrimMode.Both)]
        public string TipoEvento;

        [FieldFixedLength(1)]
        public string Filler2;

        [FieldFixedLength(15)]
        [FieldTrim(TrimMode.Both)]
        public string Valor;
    }
    [FixedLengthRecord(FixedMode.AllowMoreChars)]
    public class IRRendimentosSessaoReceb
    {
        [FieldFixedLength(2)]
        public string Filler;

        [FieldFixedLength(67)]
        [FieldTrim(TrimMode.Both)]
        public string TipoRendimento;

        [FieldFixedLength(10)]
        [FieldTrim(TrimMode.Both)]
        public string Moeda;
    }
    [FixedLengthRecord(FixedMode.AllowMoreChars)]
    public class IRRendimentosReceb
    {
        [FieldFixedLength(5)]
        public string Filler;

        [FieldFixedLength(58)]
        [FieldTrim(TrimMode.Both)]
        public string TipoEvento;

        [FieldFixedLength(1)]
        public string Filler2;

        [FieldFixedLength(15)]
        [FieldTrim(TrimMode.Both)]
        public string Valor;
    }

    [FixedLengthRecord(FixedMode.AllowMoreChars)]
    public class IRProcesso
    {
        [FieldFixedLength(5)]
        public string Filler;

        [FieldFixedLength(74)]
        [FieldTrim(TrimMode.Both)]
        public string Processo;
    }

    [FixedLengthRecord(FixedMode.AllowMoreChars)]
    public class IRNaturezaRendimento
    {
        [FieldFixedLength(5)]
        public string Filler;

        [FieldFixedLength(74)]
        [FieldTrim(TrimMode.Both)]
        public string NaturezaRendimento;
    }

    [FixedLengthRecord(FixedMode.AllowMoreChars)]
    public class IRInformacoesComplementares
    {
        [FieldFixedLength(2)]
        public string Filler;

        [FieldFixedLength(77)]
        [FieldTrim(TrimMode.Both)]
        public string InformacoesComplementares;
    }

    [FixedLengthRecord(FixedMode.AllowMoreChars)]
    public class IRDadosResponsavel
    {
        [FieldFixedLength(2)]
        public string Filler;

        [FieldFixedLength(77)]
        [FieldTrim(TrimMode.Both)]
        public string DadosResponsavel;
    }

    [FixedLengthRecord(FixedMode.AllowMoreChars)]
    public class IRQuebraPagina
    {
        [FieldFixedLength(1)]
        public string Filler;

    }
}


