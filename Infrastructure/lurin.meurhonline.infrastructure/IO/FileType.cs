using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace lurin.meurhonline.infrastructure.IO
{
    public class FileType
    {
        private FileType(string value)
        {
            Value = value;
        }

        public string Value { get; set; }

        public static FileType PathDependenteDocumento
        {
            get
            {
                return new FileType(ConfigurationManager.AppSettings["PathDependenteDocumento"]);
            }
        }

        public static FileType PathColaboradorDocumento
        {
            get
            {
                return new FileType(ConfigurationManager.AppSettings["PathDependenteDocumento"]);
            }
        }

        public static FileType PathColaboradorFoto
        {
            get
            {
                return new FileType(ConfigurationManager.AppSettings["PathColaboradorFoto"]);
            }
        }

        public static FileType PathColaboradorAtestado
        {
            get
            {
                return new FileType(ConfigurationManager.AppSettings["PathColaboradorAtestado"]);
            }
        }


    }
}
