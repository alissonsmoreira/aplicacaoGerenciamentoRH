using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

using lurin.meurhonline.domain.model;

namespace lurin.meurhonline.infrastructure.persistence.mapper
{
    public class BancoHorasMap : EntityTypeConfiguration<BancoHorasModel>
    {
        public BancoHorasMap()
        {
            ToTable("BancoHoras");
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.EmpresaId).IsRequired();
            Property(x => x.ColaboradorId).IsRequired();
            Property(x => x.HorasPositivas).IsRequired();
            Property(x => x.HorasNegativas).IsRequired();
            Property(x => x.HorasSaldo).IsRequired();
            Property(x => x.DataImportacao).IsRequired();
        }
    }
}