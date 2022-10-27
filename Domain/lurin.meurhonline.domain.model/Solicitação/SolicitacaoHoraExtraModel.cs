using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace lurin.meurhonline.domain.model
{
    public class SolicitacaoHoraExtraModel
    {
        public int Id { get; set; }
        public int GestorId { get; set; }
        public ColaboradorModel Gestor { get; set; }
        public int? EmpresaId { get; set; }
        public EmpresaModel Empresa { get; set; }
        public DateTime Data { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFim { get; set; }
        public string Motivo { get; set; }
        public bool TemCafeManha { get; set; }
        public bool TemRefeicao { get; set; }
        public bool TemMarmitex { get; set; }
        public int? MarmitexId { get; set; }
        public MarmitexModel Marmitex { get; set; }
        public DateTime DataSolicitacao { get; set; }

        public ICollection<SolicitacaoHoraExtraColaboradorModel> SolicitacaoHoraExtraColaborador { get; set; }
    }
}