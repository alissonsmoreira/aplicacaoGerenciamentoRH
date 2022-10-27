using System;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace lurin.meurhonline.domain.model
{
    public class NotificacaoDetalheModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        [JsonIgnore]
        public string URL { get; set; }
        [JsonIgnore]
        public string API { get; set; }
        [JsonIgnore]
        public string MensagemSingular { get; set; }
        [JsonIgnore]
        public string MensagemPlural { get; set; }
        [NotMapped]
        public string Mensagem { get; set; }
        public string UsuarioPermissao { get; set; }
        public string GestorPermissao { get; set; }
        public string FuncionarioPermissao { get; set; }
        public string PreAdmissaoPermissao { get; set; }
        public string IconeClass { get; set; }
        public string ExadecimalColor { get; set; }        
        public int Order { get; set; }        
        public int MenuId { get; set; }
        [JsonIgnore]
        public int NotificacaoDetalheStatusId { get; set; }
        [NotMapped]
        public NotificacaoDetalheStatusModel NotificacaoDetalheStatus { get; set; }
    }
}
