using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

using lurin.meurhonline.domain.model;

namespace lurin.meurhonline.infrastructure.persistence.mapper
{
    public class LoginMap : EntityTypeConfiguration<LoginModel>
    {
        public LoginMap()
        {
            ToTable("Login");
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Cpf).IsRequired();
            Property(x => x.Senha).IsRequired();
            Property(x => x.UsuarioColaboradorId).IsRequired();            
            Property(x => x.UsuarioColaboradorTipoId).IsRequired();
            Property(x => x.DataCadastro).IsRequired();
        }
    }
}