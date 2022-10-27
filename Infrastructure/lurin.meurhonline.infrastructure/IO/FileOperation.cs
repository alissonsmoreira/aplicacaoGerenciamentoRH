using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Net.Configuration;
using System.IO;
using System.Reflection;
using System.Drawing;
using System.Drawing.Imaging;
using lurin.meurhonline.domain.model;


namespace lurin.meurhonline.infrastructure.IO
{
    public class FileOperation
    {
     
        public static string SalvarDocumentoImagem(string caminhoImagem, string imageBase64, string documentoNome)
        {
            try
            {
                if (!Directory.Exists(caminhoImagem))
                {
                    Directory.CreateDirectory(caminhoImagem);
                }

                string[] strings = imageBase64.Split(',');
                string extension = string.Empty;

                switch (strings[0])
                {
                    case "data:image/jpeg;base64":
                        extension = ".jpeg";
                        break;
                    case "data:image/png;base64":
                        extension = ".png";
                        break;
                    case "data:image/bmp;base64":
                        extension = ".bmp";
                        break;
                    default://should write cases for more images types
                        extension = ".jpg";
                        break;
                }

                imageBase64 = strings[1];

                var fileName = string.Concat(documentoNome, extension);
                var fileFullPath = Path.Combine(caminhoImagem, fileName);
                var image = Image.FromStream(new MemoryStream(Convert.FromBase64String(imageBase64)));
                image.Save(fileFullPath);

                return fileName;
            }
            catch (Exception ex)
            {
                throw ex;
            }          
        }

        public static string SalvarDocumentoPdf(string caminhoImagem, string imageBase64, string documentoNome)
        {
            try
            {
                if (!Directory.Exists(caminhoImagem))
                {
                    Directory.CreateDirectory(caminhoImagem);
                }

                string[] strings = imageBase64.Split(',');
                string extension = ".pdf";

                imageBase64 = strings[1];

                var fileName = string.Concat(documentoNome, extension);
                var fileFullPath = Path.Combine(caminhoImagem, fileName);

                byte[] imagenBytes = Convert.FromBase64String(imageBase64);

                File.WriteAllBytes(fileFullPath, imagenBytes);

                return fileName;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public static void ExcluirDocumentoImagem(string caminhoImagem, string documentoNome)
        {
            try
            {
                if (File.Exists(Path.Combine(caminhoImagem, documentoNome)))
                {
                    File.Delete(Path.Combine(caminhoImagem, documentoNome));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static string CarregarDocumentoBase64 (string caminhoImagem, string documentoNome)
        {
            try
            {
                string imagebase64 = string.Empty;
                var arquivoFullPath = Path.Combine(caminhoImagem, documentoNome);

                if (File.Exists(arquivoFullPath))
                {
                    byte[] imagem = System.IO.File.ReadAllBytes(arquivoFullPath);
                    imagebase64 = Convert.ToBase64String(imagem);

                    string extension = Path.GetExtension(arquivoFullPath).Replace(".", string.Empty);
                    string dataType = string.Empty;

                    switch (extension)
                    {
                        case "jpeg":
                            dataType = "data:image/jpeg;base64";
                            break;
                        case "pdf":
                            dataType = "data:application/pdf;base64";
                            break;
                        case "png":
                            dataType = "data:image/png;base64";
                            break;
                        default://should write cases for more images types
                            dataType = "data:image/png;base64";
                            break;
                    }

                    imagebase64 = string.Concat(dataType, imagebase64);
                }

                return imagebase64;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
