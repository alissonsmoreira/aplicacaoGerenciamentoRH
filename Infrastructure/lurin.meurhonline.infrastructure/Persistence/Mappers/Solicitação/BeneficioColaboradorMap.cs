﻿using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

using lurin.meurhonline.domain.model;

namespace lurin.meurhonline.infrastructure.persistence.mapper
{
    public class BeneficioColaboradorMap : EntityTypeConfiguration<BeneficioColaboradorModel>
    {
        public BeneficioColaboradorMap()
        {
            ToTable("BeneficioColaborador");
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.ColaboradorId).IsRequired();
            Property(x => x.BeneficioId).IsRequired();
            Property(x => x.SolicitacaoStatusId).IsRequired();
            Property(x => x.DataSolicitacao).IsRequired();
            Property(x => x.DataConclusao).IsOptional();
        }
    }
}
