using System.Collections.Generic;

using lurin.meurhonline.domain.model;
using lurin.meurhonline.domain.interfaces;
using lurin.meurhonline.infrastructure.persistence.interfaces;
using lurin.meurhonline.domain.layout.importacao.Bancohoras;
using FileHelpers;
using System;
using System.Text;
using System.Collections.ObjectModel;

namespace lurin.meurhonline.domain
{
    public class BancoHorasDomain : IBancoHorasDomain<BancoHorasModel>
    {

        public object[] objBancoHoras = null;
        private int _linhaAtual = 1;
        private bool _dContinuaDetalhes = true;

        public BancoHorasDomain(IUnitOfWork unitOfWork)
        { }

        public bool DecodeArquivoTxtBancoHoras(BancoHorasModel BancoHoras)
        {
            byte[] data = Convert.FromBase64String(BancoHoras.DocumentoBase64);
            string decodedString = Encoding.GetEncoding(1252).GetString(data);
            bool bReturn = false;

            var engine = new MultiRecordEngine(typeof(BancoHorasLinhaDetalhe), typeof(BancoHorasCabecalho));

            engine.RecordSelector = new RecordTypeSelector(CustomSelector);

            objBancoHoras = engine.ReadString(decodedString);

            if (objBancoHoras != null)
            {
                bReturn = true;
            }

            return bReturn;
        }


        public ICollection<BancoHorasModel> AdicionarBancoHorasDetahes(BancoHorasModel bancoHoras)
        {
            ICollection<BancoHorasModel> result = new Collection<BancoHorasModel>();

            string diaAnterior = string.Empty;
            string diaSemanaAnterior = string.Empty;
            string numeroJornadaAnterior = string.Empty;
            string tipoDiaAnterior = string.Empty;

            foreach (var item in objBancoHoras)
            {
                if (item.GetType() == typeof(BancoHorasLinhaDetalhe))
                {
                    BancoHorasLinhaDetalhe bancoHorasLinhaDetalhe = (BancoHorasLinhaDetalhe)item;
                    BancoHorasModel objDetallhe = new BancoHorasModel();
                    
                    objDetallhe.EmpresaId = bancoHoras.EmpresaId;
                    objDetallhe.ColaboradorNome = bancoHorasLinhaDetalhe.ColaboradorNome;
                    objDetallhe.Matricula = bancoHorasLinhaDetalhe.Matricula;
                    objDetallhe.HorasPositivas = bancoHorasLinhaDetalhe.HorasPositivas;
                    objDetallhe.HorasNegativas = bancoHorasLinhaDetalhe.HorasNegativas;
                    objDetallhe.HorasSaldo = bancoHorasLinhaDetalhe.HoraSaldo;
                    objDetallhe.DataImportacao = DateTime.Now;
                    result.Add(objDetallhe);

                }
            }

            return result;
        }

        private Type CustomSelector(MultiRecordEngine engine, string recordLine)
        {
            Type tpReturn = null;

            if (_linhaAtual == 5)
            {
                tpReturn = typeof(BancoHorasCabecalho);
            }
            else if (_linhaAtual >= 12 && _linhaAtual <= 63 && _dContinuaDetalhes)
            {
                if (recordLine.Trim().Length == 0 )
                {
                    //_linhaAtual = 0;
                    _dContinuaDetalhes = false;
                }
                else
                {
                    tpReturn = typeof(BancoHorasLinhaDetalhe);
                }
            }
            else if (_linhaAtual >= 0 && !_dContinuaDetalhes && !recordLine.Contains("-----"))
            {
                switch (_linhaAtual)
                {

                    case 5:
                        tpReturn = typeof(BancoHorasCabecalho);
                        break;
                    default:
                        tpReturn = null;
                        break;
                }
            }

            _linhaAtual++;

            return tpReturn;
        }
    }
}
