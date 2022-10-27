﻿using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

using lurin.meurhonline.domain.model;

namespace lurin.meurhonline.infrastructure.persistence.mapper
{
    public class ReciboFeriasDescontoMap : EntityTypeConfiguration<ReciboFeriasDescontoModel>
    {
        public ReciboFeriasDescontoMap()
        {
            ToTable("ReciboFeriasDesconto");
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Evento).IsOptional();
            Property(x => x.Descricao).IsOptional();
            Property(x => x.BaseCalculo).IsOptional();
            Property(x => x.Valor).IsOptional();
            Property(x => x.ReciboFeriasId).IsRequired();
        }
    }
}
