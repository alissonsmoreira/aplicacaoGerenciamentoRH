using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

using lurin.meurhonline.domain.model;

namespace lurin.meurhonline.infrastructure.persistence.mapper
{
    public class BancoHorasLogMap : EntityTypeConfiguration<BancoHorasLogModel>
    {
        public BancoHorasLogMap()
        {
            ToTable("BancoHorasLog");
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.EmpresaId).IsRequired();
            Property(x => x.ColaboradorNome).IsRequired();
            Property(x => x.Matricula).IsRequired();
            Property(x => x.Erro).IsRequired();
            Property(x => x.DataImportacao).IsRequired();
        }
    }
}