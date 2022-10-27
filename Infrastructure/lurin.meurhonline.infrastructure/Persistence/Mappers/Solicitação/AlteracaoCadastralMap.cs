using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

using lurin.meurhonline.domain.model;

namespace lurin.meurhonline.infrastructure.persistence.mapper
{
    public class AlteracaoCadastralMap : EntityTypeConfiguration<AlteracaoCadastralModel>
    {
        public AlteracaoCadastralMap()
        {
            ToTable("AlteracaoCadastral");
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.ColaboradorId).IsRequired();
            Property(x => x.Nome).IsOptional();
            Property(x => x.Numero).IsOptional();
            Property(x => x.Complemento).IsOptional();
            Property(x => x.Bairro).IsOptional();
            Property(x => x.CEP).IsOptional();
            Property(x => x.UF).IsOptional();
            Property(x => x.Cidade).IsOptional();
            Property(x => x.Pais).IsOptional();
            Property(x => x.Telefone1).IsOptional();
            Property(x => x.Telefone2).IsOptional();
            Property(x => x.Telefone3).IsOptional();
            Property(x => x.Email).IsOptional();
            Property(x => x.CategoriaHabilitacao).IsOptional();
            Property(x => x.DataVencimentoHabilitacao).IsOptional();
            Property(x => x.BancoId).IsOptional();
            Property(x => x.Agencia).IsOptional();
            Property(x => x.Conta).IsOptional();
            Property(x => x.ContaBancariaTipoId).IsOptional();
            Property(x => x.FotoNome).IsOptional();
            Property(x => x.CarteiraHabilitacaoNome).IsOptional();
            Property(x => x.ComprovanteResidenciaNome).IsOptional();
            Property(x => x.SolicitacaoStatusId).IsRequired();
            Property(x => x.DataSolicitacao).IsRequired();
            Property(x => x.DataConclusao).IsOptional();
        }
    }
}
