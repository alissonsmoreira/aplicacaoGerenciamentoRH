using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace lurin.meurhonline.domain.model
{    
    public class MenuModel
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string SubTitulo { get; set; }
        public string SubTituloNivel1 { get; set; }
        public string UsuarioPermissao { get; set; }
        public string GestorPermissao { get; set; }
        public string FuncionarioPermissao { get; set; }
        public string PreAdmissaoPermissao { get; set; }
        public int Order { get; set; }
        public int MenuStatusId { get; set; }
        
        [NotMapped]
        public MenuStatusModel MenuStatus { get; set; }
    }
}