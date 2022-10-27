using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

using lurin.meurhonline.domain.model;

namespace lurin.meurhonline.infrastructure.persistence.mapper
{
    public class CartaoPontoDetalheMap : EntityTypeConfiguration<CartaoPontoDetalheModel>
    {
        public CartaoPontoDetalheMap()
        {
            ToTable("CartaoPontoDetalhe");
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.CartaoPontoId).IsRequired();
            Property(x => x.DataCadastro).IsRequired();

            Property(x => x.Dia).IsOptional();
            Property(x => x.DiaSemana).IsOptional();
            Property(x => x.NumeroJornada).IsOptional();
            Property(x => x.TipoDia).IsOptional();
            Property(x => x.Marcacao1).IsOptional();
            Property(x => x.TipoMarcacao1).IsOptional();
            Property(x => x.Marcacao2).IsOptional();
            Property(x => x.TipoMarcacao2).IsOptional();
            Property(x => x.Marcacao3).IsOptional();
            Property(x => x.TipoMarcacao3).IsOptional();
            Property(x => x.Marcacao4).IsOptional();
            Property(x => x.TipoMarcacao4).IsOptional();
            Property(x => x.Marcacao5).IsOptional();
            Property(x => x.TipoMarcacao5).IsOptional();
            Property(x => x.Marcacao6).IsOptional();
            Property(x => x.TipoMarcacao6).IsOptional();
            Property(x => x.Marcacao7).IsOptional();
            Property(x => x.TipoMarcacao7).IsOptional();
            Property(x => x.Marcacao8).IsOptional();
            Property(x => x.TipoMarcacao8).IsOptional();
            Property(x => x.InicioJornada).IsOptional();
            Property(x => x.TerminoJornada).IsOptional();
            Property(x => x.QuantHoras).IsOptional();
            Property(x => x.DescricaoOcorrencia).IsOptional();
        }
    }
}


