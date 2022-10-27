using System.Collections.Generic;

using lurin.meurhonline.domain.model;
using lurin.meurhonline.domain.interfaces;
using lurin.meurhonline.infrastructure.persistence.interfaces;
using FileHelpers;
using System;
using System.Text;
using lurin.meurhonline.domain.layout.importacao.AvisoFerias;

namespace lurin.meurhonline.domain
{
    public class AvisoFeriasDomain : IAvisoFeriasDomain<AvisoFeriasModel>
    {
        public object[] objAvisoFerias = null;
        private int _numLinha = 0;

        public AvisoFeriasDomain(IUnitOfWork unitOfWork)
        { }

        public bool DecodeArquivoTxtAvisoFerias(AvisoFeriasModel avisoFerias)
        {
            byte[] data = Convert.FromBase64String(avisoFerias.DocumentoBase64);
            string decodedString = Encoding.GetEncoding(1252).GetString(data);
            bool bReturn = false;

            var engine = new MultiRecordEngine(typeof(AvisoFeriasLinha2),
                typeof(AvisoFeriasLinha9),
                typeof(AvisoFeriasLinha14a20),
                typeof(AvisoFeriasLinha22));

            engine.RecordSelector = new RecordTypeSelector(CustomSelector);

            objAvisoFerias = engine.ReadString(decodedString);

            if (objAvisoFerias != null)
            {
                bReturn = true;
            }

            return bReturn;
        }

        public List<AvisoFeriasModel> AdicionarAvisoFerias(AvisoFeriasModel AvisoFeriasModel)
        {
            List<AvisoFeriasModel> result = new List<AvisoFeriasModel>();
            AvisoFeriasModel itemAvisoFerias = new AvisoFeriasModel();
            bool primieraLinhatexto = true;

            foreach (var item in objAvisoFerias)
            {
                itemAvisoFerias.DataCadastro = DateTime.Now;
                itemAvisoFerias.Ano = AvisoFeriasModel.Ano;

                if (item.GetType() == typeof(AvisoFeriasLinha2))
                {
                    AvisoFeriasLinha2 avisoFeriasAux = (AvisoFeriasLinha2)item;
                    itemAvisoFerias.Estabelecimento = avisoFeriasAux.Estabelecimento;
                    itemAvisoFerias.CPNJ = avisoFeriasAux.CNPJ;
                }

                if (item.GetType() == typeof(AvisoFeriasLinha9))
                {
                    AvisoFeriasLinha9 avisoFeriasAux = (AvisoFeriasLinha9)item;
                    itemAvisoFerias.CPF = avisoFeriasAux.CPF;
                    itemAvisoFerias.Nome = avisoFeriasAux.Nome;
                }

                if (item.GetType() == typeof(AvisoFeriasLinha14a20))
                {
                    AvisoFeriasLinha14a20 avisoFeriasAux = (AvisoFeriasLinha14a20)item;
                    itemAvisoFerias.Texto += primieraLinhatexto ? avisoFeriasAux.Texto : avisoFeriasAux.Texto +" \n";
                    primieraLinhatexto = false;
                }

                if (item.GetType() == typeof(AvisoFeriasLinha22))
                {
                    AvisoFeriasLinha22 avisoFeriasAux = (AvisoFeriasLinha22)item;
                    itemAvisoFerias.LocalData = avisoFeriasAux.LocalData;
                    result.Add(itemAvisoFerias);
                    itemAvisoFerias = new AvisoFeriasModel();
                }
            }

            return result;
        }

        private Type CustomSelector(MultiRecordEngine engine, string recordLine)
        {
            Type tpReturn = null;
            _numLinha++;

            switch (_numLinha)
            {
                case 2:
                    tpReturn = typeof(AvisoFeriasLinha2);
                    break;
                case 9:
                    tpReturn = typeof(AvisoFeriasLinha9);
                    break;
                case 14:
                case 15:
                case 16:
                case 17:
                case 18:
                case 19:
                case 20:
                    tpReturn = typeof(AvisoFeriasLinha14a20);
                    break;
                case 22:
                    tpReturn = typeof(AvisoFeriasLinha22);
                    break;
                case 30:
                    _numLinha = 0;
                    break;
                default:
                    tpReturn = null;
                    break;
            } 

            return tpReturn;
        }
    }
}