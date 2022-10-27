using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

using lurin.meurhonline.domain.model;

namespace lurin.meurhonline.infrastructure.persistence.mapper
{
    public class ColaboradorDocumentacaoMap : EntityTypeConfiguration<ColaboradorDocumentacaoModel>
    {
        public ColaboradorDocumentacaoMap()
        {
            ToTable("ColaboradorDocumentacao");
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.ColaboradorId).IsRequired();
            Property(x => x.RG).IsRequired();

            Property(x => x.OrgaoEmissorRG).IsOptional();
            Property(x => x.UFEmissaoRG).IsOptional();
            Property(x => x.DataEmissaoRG).IsOptional();
            Property(x => x.RIC).IsOptional();
            Property(x => x.UFEmissaoRIC).IsOptional();
            Property(x => x.CidadeEmissaoRIC).IsOptional();
            Property(x => x.OrgaoEmissorRIC).IsOptional();
            Property(x => x.DataExpedicaoRIC).IsOptional();
            Property(x => x.CartaoNacionalSaude).IsOptional();
            Property(x => x.NumeroReservista).IsOptional();
            Property(x => x.TituloEleitor).IsOptional();
            Property(x => x.ZonaEleitoral).IsOptional();
            Property(x => x.SecaoEleitoral).IsOptional();
            Property(x => x.UFEleitoral).IsRequired();
            Property(x => x.CidadeEleitoral).IsOptional();
            Property(x => x.CarteiraHabilitacao).IsOptional();
            Property(x => x.CategoriaHabilitacao).IsOptional();
            Property(x => x.DataVencimentoHabilitacao).IsOptional();
            Property(x => x.NumeroCTPS).IsOptional();
            Property(x => x.SerieCTPS).IsOptional();
            Property(x => x.UFCTPS).IsOptional();
            Property(x => x.DataEmissaoCTPS).IsOptional();
            Property(x => x.PISNITNIS).IsOptional();
            Property(x => x.DataEmissaoPISNITNIS).IsOptional();
            Property(x => x.DataCadastro).IsRequired();
        }
    }
}
