using System.ComponentModel;

namespace lurin.meurhonline.domain.model.enumerator
{
    public enum DocumentoAdmissionalEnum
    {
        [Description("Carteira_de_Habilitação")]
        CarteiraDeHabilitação = 1,
        [Description("Comprovante_de_Residência")]
        ComprovanteDeResidencia = 2,
        [Description("RG")]
        RG = 3,
        [Description("CPF")]
        CPF = 4,
        [Description("Certidão_de_Nascimento_Casamento")]
        CertidaoNascimentoCasamento = 5,
        [Description("PIS")]
        PIS = 6
    }
}