using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

using lurin.meurhonline.domain.model;

namespace lurin.meurhonline.infrastructure.persistence.mapper
{
    public class CargoPlanoUnidadeMap : EntityTypeConfiguration<CargoPlanoUnidadeModel>
    {
        public CargoPlanoUnidadeMap()
        {
            ToTable("CargoPlanoUnidade");
            HasKey(pu => new { pu.CargoPlanoId, pu.CargoUnidadeId});
            
        }
    }
}
