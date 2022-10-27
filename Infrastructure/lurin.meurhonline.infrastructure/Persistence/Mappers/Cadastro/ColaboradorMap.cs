using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

using lurin.meurhonline.domain.model;

namespace lurin.meurhonline.infrastructure.persistence.mapper
{
    public class ColaboradorMap : EntityTypeConfiguration<ColaboradorModel>
    {
        public ColaboradorMap()
        {
            ToTable("Colaborador");
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Nome).IsRequired();
            Property(x => x.CPF).IsRequired();
            Property(x => x.EmpresaId).IsRequired();
            Property(x => x.ColaboradorTipoId).IsRequired();
            Property(x => x.Sexo).IsOptional();
            Property(x => x.Endereco).IsOptional();
            Property(x => x.Numero).IsOptional();
            Property(x => x.Complemento).IsOptional();
            Property(x => x.Bairro).IsOptional();
            Property(x => x.CEP).IsOptional();
            Property(x => x.UF).IsOptional();
            Property(x => x.Cidade).IsOptional();
            Property(x => x.FotoNome).IsOptional();
            Property(x => x.DataNascimento).IsOptional();
            Property(x => x.Telefone1).IsOptional();
            Property(x => x.Telefone2).IsOptional();
            Property(x => x.Telefone3).IsOptional();
            Property(x => x.Email).IsRequired();
            Property(x => x.NomePai).IsOptional();
            Property(x => x.NomeMae).IsOptional();
            Property(x => x.MatriculaInterna).IsOptional();
            Property(x => x.MatriculaeSocial).IsOptional();
            Property(x => x.PaisNascimento).IsOptional();
            Property(x => x.UFNascimento).IsOptional();
            Property(x => x.CidadeNascimento).IsOptional();
            Property(x => x.GrauInstrucaoId).IsOptional();
            Property(x => x.EstadoCivilId).IsOptional();
            Property(x => x.ColaboradorStatusId).IsRequired();
            Property(x => x.DataCadastro).IsRequired();
        }
    }
}
