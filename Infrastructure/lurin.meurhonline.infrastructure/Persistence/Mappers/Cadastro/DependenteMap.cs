using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

using lurin.meurhonline.domain.model;

namespace lurin.meurhonline.infrastructure.persistence.mapper
{
    public class DependenteMap : EntityTypeConfiguration<DependenteModel>
    {
        public DependenteMap()
        {
            ToTable("Dependente");
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Nome).IsRequired();
            Property(x => x.CPF).IsRequired();
            Property(x => x.Sexo).IsRequired();
            Property(x => x.DataNascimento).IsRequired();
            Property(x => x.NomeMae).IsRequired();
            Property(x => x.GrauDependencia).IsRequired();
            Property(x => x.ColaboradorId).IsRequired();
            Property(x => x.DocumentoNome).IsOptional();
            Property(x => x.DataCadastro).IsRequired();

        }
    }
}
