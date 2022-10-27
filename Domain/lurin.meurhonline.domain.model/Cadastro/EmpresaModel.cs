using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace lurin.meurhonline.domain.model
{
    public class EmpresaModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CNPJ { get; set; }
        public string InscricaoEstadual { get; set; }
        public string InscricaoMunicipal { get; set; }
        public string Endereco { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string CEP { get; set; }
        public string UF { get; set; }
        public string Cidade { get; set; }
        public string TelefoneContato1 { get; set; }
        public string EmailContato1 { get; set; }
        public string TelefoneContato2 { get; set; }
        public string EmailContato2 { get; set; }
        public string TelefoneContato3 { get; set; }
        public string EmailContato3 { get; set; }
        public int EmpresaTipoId { get; set; }
        public EmpresaTipoModel EmpresaTipo { get; set; }

        public int EmpresaMatrizId { get; set; }

        [NotMapped]
        public EmpresaMatrizModel EmpresaMatriz { get; set; }

        public int EmpresaStatusId { get; set; }

        [NotMapped]
        public EmpresaStatusModel EmpresaStatus { get; set; }

        public DateTime DataCadastro { get; set; }
        public ICollection<EmpresaDocumentoAdmissionalModel> EmpresaDocumentosAdmissional { get; set; }
        public ICollection<EmpresaEmpresaFuncionalidadeModel> EmpresaEmpresaFuncionalidades { get; set; }
        public int FornecedorHolerite { get; set; }
    }
}