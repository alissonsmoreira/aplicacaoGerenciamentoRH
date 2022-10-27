using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

using lurin.meurhonline.domain.model;

namespace lurin.meurhonline.infrastructure.persistence.mapper
{
    public class EmpresaMap : EntityTypeConfiguration<EmpresaModel>
    {
        public EmpresaMap()
        {
            ToTable("Empresa");
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Nome).IsRequired();
            Property(x => x.CNPJ).IsRequired();
            Property(x => x.InscricaoEstadual).IsOptional();
            Property(x => x.InscricaoMunicipal).IsOptional();
            Property(x => x.Endereco).IsOptional();
            Property(x => x.Numero).IsOptional();
            Property(x => x.Bairro).IsOptional();
            Property(x => x.CEP).IsOptional();
            Property(x => x.UF).IsOptional();
            Property(x => x.Cidade).IsOptional();
            Property(x => x.TelefoneContato1).IsOptional();
            Property(x => x.EmailContato1).IsOptional();
            Property(x => x.TelefoneContato2).IsOptional();
            Property(x => x.EmailContato2).IsOptional();
            Property(x => x.TelefoneContato3).IsOptional();            
            Property(x => x.EmailContato3).IsOptional();
            Property(x => x.EmpresaTipoId).IsRequired();
            Property(x => x.EmpresaStatusId).IsRequired();
            Property(x => x.EmpresaMatrizId).IsOptional();
            Property(x => x.DataCadastro).IsRequired();            
        }
    }
}
