using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lurin.meurhonline.infrastructure.mail
{
    public class MailType
    {
        private MailType(string value)
        {
            Value = value;
        }

        public string Value { get; set; }

        public static MailType NovoUsuario
        {
            get
            {
                return new MailType("lurin.meurhonline.infrastructure.Mail.Message.TemplateEmailNovoUsuario.html");
            }
        }       
        public static MailType RecuperarSenha
        {
            get
            {
                return new MailType("lurin.meurhonline.infrastructure.Mail.Message.TemplateEmailRecuperarSenha.html");
            }
        }

        public static MailType TemplateEmailReenvio
        {
            get
            {
                return new MailType("lurin.meurhonline.infrastructure.Mail.Message.TemplateEmailReenvio.html");
            }
        }
    }
}
