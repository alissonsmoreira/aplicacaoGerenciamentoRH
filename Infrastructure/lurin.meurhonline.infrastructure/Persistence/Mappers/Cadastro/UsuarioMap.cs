using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

using lurin.meurhonline.domain.model;

namespace lurin.meurhonline.infrastructure.persistence.mapper
{
    public class UsuarioMap : EntityTypeConfiguration<UsuarioModel>
    {
        public UsuarioMap()
        {
            ToTable("Usuario");
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Nome).IsRequired();
            Property(x => x.CPF ).IsRequired();
            //Property(x => x.Senha).IsRequired();
            Property(x => x.Endereco).IsOptional();
            Property(x => x.Complemento).IsOptional();
            Property(x => x.Bairro).IsOptional();
            Property(x => x.CEP).IsOptional();
            Property(x => x.UF).IsOptional();
            Property(x => x.Cidade).IsOptional();
            Property(x => x.TelefoneResidencial).IsOptional();
            Property(x => x.TelefoneCelular).IsOptional();
            Property(x => x.TelefoneCelular).IsOptional();
            Property(x => x.Email).IsRequired();
            Property(x => x.DataCadastro).IsRequired();

        }
    }
}
