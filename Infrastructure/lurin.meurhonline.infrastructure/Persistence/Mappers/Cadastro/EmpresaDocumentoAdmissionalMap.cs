using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

using lurin.meurhonline.domain.model;

namespace lurin.meurhonline.infrastructure.persistence.mapper
{
    public class EmpresaDocumentoAdmissionaleMap : EntityTypeConfiguration<EmpresaDocumentoAdmissionalModel>
    {
        public EmpresaDocumentoAdmissionaleMap()
        {
            ToTable("EmpresaDocumentoAdmissional");
            HasKey(pu => new { pu.EmpresaId, pu.DocumentoAdmissionalId});

        }
    }
}
