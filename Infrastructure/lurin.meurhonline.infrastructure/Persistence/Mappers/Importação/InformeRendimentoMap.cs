using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

using lurin.meurhonline.domain.model;

namespace lurin.meurhonline.infrastructure.persistence.mapper
{
    public class InformeRendimentoMap : EntityTypeConfiguration<InformeRendimentoModel>
    {
        public InformeRendimentoMap()
        {
            ToTable("InformeRendimento");
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Ano).IsRequired();
            Property(x => x.Ministerio).IsOptional();
            Property(x => x.TipoDocumento).IsOptional();
            Property(x => x.Secretaria).IsOptional();
            Property(x => x.Documento).IsOptional();
            Property(x => x.Exercicio).IsOptional();
            Property(x => x.AnoCalendario).IsOptional();
            Property(x => x.FontePagadora).IsOptional();
            Property(x => x.EmpresaId).IsOptional();
            Property(x => x.NomeEmpresa).IsOptional();
            Property(x => x.CNPJ).IsOptional();
            Property(x => x.DadosPessoaFisica).IsOptional();
            Property(x => x.DescricaoCPF).IsOptional();
            Property(x => x.ColaboradorId).IsRequired();
            Property(x => x.CPF).IsOptional();
            Property(x => x.DescricaoNome).IsOptional();
            Property(x => x.Nome).IsOptional();
            Property(x => x.DescricaoNatureza).IsOptional();
            Property(x => x.Natureza).IsOptional();
            Property(x => x.TipoRendimento1).IsOptional();
            Property(x => x.MoedaRendimento1).IsOptional();
            Property(x => x.TipoRendimento2).IsOptional();
            Property(x => x.MoedaRendimento2).IsOptional();
            Property(x => x.TipoRendimento3).IsOptional();
            Property(x => x.MoedaRendimento3).IsOptional();
            Property(x => x.TipoRendimento4).IsOptional();
            Property(x => x.InformacoesComplementares).IsOptional();
            Property(x => x.DadosResponsavel).IsOptional();
        }
    }
}
