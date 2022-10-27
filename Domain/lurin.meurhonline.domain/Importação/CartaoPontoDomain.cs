using System.Collections.Generic;

using lurin.meurhonline.domain.model;
using lurin.meurhonline.domain.interfaces;
using lurin.meurhonline.infrastructure.persistence.interfaces;
using lurin.meurhonline.domain.layout.importacao.cartaoponto;
using FileHelpers;
using System;
using System.Text;
using System.Collections.ObjectModel;

namespace lurin.meurhonline.domain
{
    public class CartaoPontoDomain : ICartaoPontoDomain<CartaoPontoModel>
    {

        public object[] objCartaoPonto = null;
        private int _linhaDetalhe = 0;
        private int _linha = 0;
        private bool _dContinuaDetalhes = true;
        private bool _dContinuaRodape = false;
        private bool _dBancoDeHorasRealizado = false;
        private bool _dCompesacaoDiaPonte = false;

        public CartaoPontoDomain(IUnitOfWork unitOfWork)
        { }

        public bool DecodeArquivoTxtCartaoPonto(CartaoPontoModel cartaoPonto)
        {
            byte[] data = Convert.FromBase64String(cartaoPonto.DocumentoBase64);
            string decodedString = Encoding.GetEncoding(1252).GetString(data);
            bool bReturn = false;

            var engine = new MultiRecordEngine(typeof(CartaoPontoHeaderLinha5),
                typeof(CartaoPontoHeaderLinha6),
                typeof(CartaoPontoHeaderLinha8),
                typeof(CartaoPontoDetalhesLinha14),
                typeof(CartaoPontoSaldoHorasLinha1),
                typeof(CartaoPontoSaldoHorasLinha2),
                typeof(CartaoPontoSaldoHorasLinha4),
                typeof(CartaoPontoSaldoHorasLinha5),
                typeof(CartaoPontoSaldoHorasLinha10),
                typeof(CartaoPontoSaldoHorasLinha11),
                typeof(CartaoPontoSaldoHorasLinha12),
                typeof(CartaoPontoSaldoHorasLinha13),
                typeof(CartaoPontoSaldoHorasLinha14),
                typeof(CartaoPontoSaldoHorasLinha15),
                typeof(CartaoPontoSaldoHorasLinha128));

            engine.RecordSelector = new RecordTypeSelector(CustomSelector);

            objCartaoPonto = engine.ReadString(decodedString);

            if (objCartaoPonto != null)
            {
                bReturn = true;
            }

            return bReturn;
        }

        public List<CartaoPontoModel> AdicionarCartaoPonto(CartaoPontoModel cartaoPonto)
        {
            string diaAnterior = string.Empty;
            string diaSemanaAnterior = string.Empty;
            string numeroJornadaAnterior = string.Empty;
            string tipoDiaAnterior = string.Empty;

            CartaoPontoModel cartaoPontoResult = null;
            List<CartaoPontoModel> result = new List<CartaoPontoModel>();
            CartaoPontoCabecalhoModel cartaoPontoCabecalhoResult = new CartaoPontoCabecalhoModel();
            ICollection<CartaoPontoDetalheModel> cartaoPontoDetalheResult = new Collection<CartaoPontoDetalheModel>();

            foreach (var item in objCartaoPonto)
            {
                if (cartaoPontoResult == null)
                {
                    cartaoPontoResult = new CartaoPontoModel();
                    cartaoPontoResult.Ano = cartaoPonto.Ano;
                    cartaoPontoResult.Mes = cartaoPonto.Mes;
                    cartaoPontoResult.Colaborador = cartaoPonto.Colaborador;
                    cartaoPontoResult.ColaboradorId = cartaoPonto.ColaboradorId;
                    cartaoPontoResult.DataCadastro = cartaoPonto.DataCadastro;
                    cartaoPontoResult.SolicitacaoStatusId = cartaoPonto.SolicitacaoStatusId;
                }

                if (cartaoPontoResult.CartaoPontoCabecalho == null)
                {
                    cartaoPontoResult.CartaoPontoCabecalho = new List<CartaoPontoCabecalhoModel>();
                }
                if (cartaoPontoResult.CartaoPontoDetalhe == null)
                {
                    cartaoPontoResult.CartaoPontoDetalhe = new List<CartaoPontoDetalheModel>();
                }

                if (item.GetType() == typeof(CartaoPontoHeaderLinha5))
                {
                    CartaoPontoHeaderLinha5 cartaoPontoAux = (CartaoPontoHeaderLinha5)item;
                    cartaoPontoCabecalhoResult.Estabelecimento = cartaoPontoAux.Estabelecimento;
                    cartaoPontoCabecalhoResult.DataCadastro = DateTime.Now;
                }

                if (item.GetType() == typeof(CartaoPontoHeaderLinha6))
                {
                    CartaoPontoHeaderLinha6 cartaoPontoAux = (CartaoPontoHeaderLinha6)item;
                    cartaoPontoCabecalhoResult.Matricula = cartaoPontoAux.Matricula;

                }

                if (item.GetType() == typeof(CartaoPontoHeaderLinha8))
                {
                    CartaoPontoHeaderLinha8 cartaoPontoAux = (CartaoPontoHeaderLinha8)item;
                    cartaoPontoCabecalhoResult.DataInicioPeriodo = cartaoPontoAux.DataInicioPeriodo;
                    cartaoPontoCabecalhoResult.DataTerminoPeriodo = cartaoPontoAux.DataTerminoPeriodo;
                }

                if (item.GetType() == typeof(CartaoPontoSaldoHorasLinha1))
                {
                    CartaoPontoSaldoHorasLinha1 cartaoPontoAux = (CartaoPontoSaldoHorasLinha1)item;
                    cartaoPontoCabecalhoResult.PeriodoBancoHoras = cartaoPontoAux.PeriodoBancoHoras;
                }

                if (item.GetType() == typeof(CartaoPontoSaldoHorasLinha2))
                {
                    CartaoPontoSaldoHorasLinha2 cartaoPontoAux = (CartaoPontoSaldoHorasLinha2)item;
                    cartaoPontoCabecalhoResult.HorasPositivas1 = cartaoPontoAux.HorasPositivas;
                    cartaoPontoCabecalhoResult.HorasNegativas1 = cartaoPontoAux.HorasNegativas;
                    cartaoPontoCabecalhoResult.SaldoMes1 = cartaoPontoAux.SaldoMes;
                }

                if (item.GetType() == typeof(CartaoPontoSaldoHorasLinha4))
                {
                    CartaoPontoSaldoHorasLinha4 cartaoPontoAux = (CartaoPontoSaldoHorasLinha4)item;
                    cartaoPontoCabecalhoResult.PeriodoDiaPonte = cartaoPontoAux.PeriodoDiaPonte;
                }

                if (item.GetType() == typeof(CartaoPontoSaldoHorasLinha5))
                {
                    CartaoPontoSaldoHorasLinha5 cartaoPontoAux = (CartaoPontoSaldoHorasLinha5)item;
                    cartaoPontoCabecalhoResult.HorasPositivas2 = cartaoPontoAux.HorasPositivas;
                    cartaoPontoCabecalhoResult.HorasNegativas2 = cartaoPontoAux.HorasNegativas;
                    cartaoPontoCabecalhoResult.SaldoMes2 = cartaoPontoAux.SaldoMes;
                }

                if (item.GetType() == typeof(CartaoPontoSaldoHorasLinha10))
                {
                    CartaoPontoSaldoHorasLinha10 cartaoPontoAux = (CartaoPontoSaldoHorasLinha10)item;
                    cartaoPontoCabecalhoResult.CodigoEvento1 = cartaoPontoAux.CodigoEvento;
                    cartaoPontoCabecalhoResult.DescricaoEvento1 = cartaoPontoAux.DescricaoEvento;
                    cartaoPontoCabecalhoResult.QuantidadeHoras1 = cartaoPontoAux.QuantidadeHoras;
                    cartaoPontoCabecalhoResult.HorasPositivasBancoHoras = cartaoPontoAux.HorasPositivasBancoHoras;
                    cartaoPontoCabecalhoResult.HorasPositivasDiaPonte = cartaoPontoAux.HorasPositivasDiaPonte;
                }

                if (item.GetType() == typeof(CartaoPontoSaldoHorasLinha11))
                {
                    CartaoPontoSaldoHorasLinha11 cartaoPontoAux = (CartaoPontoSaldoHorasLinha11)item;
                    cartaoPontoCabecalhoResult.CodigoEvento2 = cartaoPontoAux.CodigoEvento;
                    cartaoPontoCabecalhoResult.DescricaoEvento2 = cartaoPontoAux.DescricaoEvento;
                    cartaoPontoCabecalhoResult.QuantidadeHoras2 = cartaoPontoAux.QuantidadeHoras;
                    cartaoPontoCabecalhoResult.HorasNegativasBancoHoras = cartaoPontoAux.HorasNegativasBancoHoras;
                    cartaoPontoCabecalhoResult.HorasNegativasDiaPonte = cartaoPontoAux.HorasNegativasDiaPonte;
                }

                if (item.GetType() == typeof(CartaoPontoSaldoHorasLinha12))
                {
                    CartaoPontoSaldoHorasLinha12 cartaoPontoAux = (CartaoPontoSaldoHorasLinha12)item;
                    cartaoPontoCabecalhoResult.CodigoEvento3 = cartaoPontoAux.CodigoEvento;
                    cartaoPontoCabecalhoResult.DescricaoEvento3 = cartaoPontoAux.DescricaoEvento;
                    cartaoPontoCabecalhoResult.QuantidadeHoras3 = cartaoPontoAux.QuantidadeHoras;
                    cartaoPontoCabecalhoResult.SaldoBancoHoras = cartaoPontoAux.SaldoBancoHoras;
                    cartaoPontoCabecalhoResult.SaldoDiaPonte = cartaoPontoAux.SaldoDiaPonte;
                }

                if (item.GetType() == typeof(CartaoPontoSaldoHorasLinha13))
                {
                    CartaoPontoSaldoHorasLinha13 cartaoPontoAux = (CartaoPontoSaldoHorasLinha13)item;
                    cartaoPontoCabecalhoResult.CodigoEvento4 = cartaoPontoAux.CodigoEvento;
                    cartaoPontoCabecalhoResult.DescricaoEvento4 = cartaoPontoAux.DescricaoEvento;
                    cartaoPontoCabecalhoResult.QuantidadeHoras4 = cartaoPontoAux.QuantidadeHoras;
                    cartaoPontoCabecalhoResult.HrsPagasBancoHoras = cartaoPontoAux.HrsPagasBancoHoras;
                    cartaoPontoCabecalhoResult.HrsPagasDiaPonte = cartaoPontoAux.HrsPagasDiaPonte;
                }

                if (item.GetType() == typeof(CartaoPontoSaldoHorasLinha14))
                {
                    CartaoPontoSaldoHorasLinha14 cartaoPontoAux = (CartaoPontoSaldoHorasLinha14)item;
                    cartaoPontoCabecalhoResult.CodigoEvento5 = cartaoPontoAux.CodigoEvento;
                    cartaoPontoCabecalhoResult.DescricaoEvento5 = cartaoPontoAux.DescricaoEvento;
                    cartaoPontoCabecalhoResult.QuantidadeHoras5 = cartaoPontoAux.QuantidadeHoras;
                    cartaoPontoCabecalhoResult.HrsDescontadasBancoHoras = cartaoPontoAux.HrsDescontadasBancoHoras;
                    cartaoPontoCabecalhoResult.HrsDescontadasDiaPonte = cartaoPontoAux.HrsDescontadasDiaPonte;
                }

                if (item.GetType() == typeof(CartaoPontoSaldoHorasLinha15))
                {
                    CartaoPontoSaldoHorasLinha15 cartaoPontoAux = (CartaoPontoSaldoHorasLinha15)item;
                    cartaoPontoCabecalhoResult.CodigoEvento6 = cartaoPontoAux.CodigoEvento;
                    cartaoPontoCabecalhoResult.DescricaoEvento6 = cartaoPontoAux.DescricaoEvento;
                    cartaoPontoCabecalhoResult.QuantidadeHoras6 = cartaoPontoAux.QuantidadeHoras;
                    cartaoPontoCabecalhoResult.HrsCompensadasBancoHoras = cartaoPontoAux.HrsCompensadasBancoHoras;
                    cartaoPontoCabecalhoResult.HrsCompensadasDiaPonte = cartaoPontoAux.HrsCompensadasDiaPonte;

                    cartaoPontoResult.CartaoPontoCabecalho.Add(cartaoPontoCabecalhoResult);
                    cartaoPontoCabecalhoResult = new CartaoPontoCabecalhoModel();
                }

                if (item.GetType() == typeof(CartaoPontoDetalhesLinha14))
                {
                    CartaoPontoDetalhesLinha14 cartaoPontoAux = (CartaoPontoDetalhesLinha14)item;
                    CartaoPontoDetalheModel objDetallhe = new CartaoPontoDetalheModel();
                    objDetallhe.Dia = string.IsNullOrEmpty(cartaoPontoAux.Dia) ? diaAnterior : cartaoPontoAux.Dia;
                    objDetallhe.DiaSemana = string.IsNullOrEmpty(cartaoPontoAux.DiaSemana) ? diaSemanaAnterior : cartaoPontoAux.DiaSemana;
                    objDetallhe.NumeroJornada = string.IsNullOrEmpty(cartaoPontoAux.NumeroJornada) ? numeroJornadaAnterior : cartaoPontoAux.NumeroJornada;
                    objDetallhe.TipoDia = string.IsNullOrEmpty(cartaoPontoAux.TipoDia) ? tipoDiaAnterior : cartaoPontoAux.TipoDia;
                    objDetallhe.Marcacao1 = cartaoPontoAux.Marcacao1;
                    objDetallhe.TipoMarcacao1 = cartaoPontoAux.TipoMarcacao1;
                    objDetallhe.Marcacao2 = cartaoPontoAux.Marcacao2;
                    objDetallhe.TipoMarcacao2 = cartaoPontoAux.TipoMarcacao2;
                    objDetallhe.Marcacao3 = cartaoPontoAux.Marcacao3;
                    objDetallhe.TipoMarcacao3 = cartaoPontoAux.TipoMarcacao3;
                    objDetallhe.Marcacao4 = cartaoPontoAux.Marcacao4;
                    objDetallhe.TipoMarcacao4 = cartaoPontoAux.TipoMarcacao4;
                    objDetallhe.Marcacao5 = cartaoPontoAux.Marcacao5;
                    objDetallhe.TipoMarcacao5 = cartaoPontoAux.TipoMarcacao5;
                    objDetallhe.Marcacao6 = cartaoPontoAux.Marcacao6;
                    objDetallhe.TipoMarcacao6 = cartaoPontoAux.TipoMarcacao6;
                    objDetallhe.Marcacao7 = cartaoPontoAux.Marcacao7;
                    objDetallhe.TipoMarcacao7 = cartaoPontoAux.TipoMarcacao7;
                    objDetallhe.Marcacao8 = cartaoPontoAux.Marcacao8;
                    objDetallhe.TipoMarcacao8 = cartaoPontoAux.TipoMarcacao8;
                    objDetallhe.InicioJornada = cartaoPontoAux.InicioJornada;
                    objDetallhe.TerminoJornada = cartaoPontoAux.TerminoJornada;
                    objDetallhe.QuantHoras = cartaoPontoAux.QuantHoras;
                    objDetallhe.DescricaoOcorrencia = cartaoPontoAux.DescricaoOcorrencia;
                    objDetallhe.DataCadastro = DateTime.Now;
                    cartaoPontoResult.CartaoPontoDetalhe.Add(objDetallhe);
                    objDetallhe = null;

                    diaAnterior = cartaoPontoAux.Dia;
                    diaSemanaAnterior = cartaoPontoAux.DiaSemana;
                    numeroJornadaAnterior = cartaoPontoAux.NumeroJornada;
                    tipoDiaAnterior = cartaoPontoAux.TipoDia;
                }

                if (item.GetType() == typeof(CartaoPontoSaldoHorasLinha128))
                {
                    diaAnterior = string.Empty;
                    diaSemanaAnterior = string.Empty;
                    numeroJornadaAnterior = string.Empty;
                    tipoDiaAnterior = string.Empty;

                    result.Add(cartaoPontoResult);
                    cartaoPontoResult = null;
                }
            }

            return result;
        }

        private Type CustomSelector(MultiRecordEngine engine, string recordLine)
        {
            Type tpReturn = null;
            _linha++;
            _linhaDetalhe++;

            if (_linha == 5)
            {
                tpReturn = typeof(CartaoPontoHeaderLinha5);
            }
            else if (_linha == 6)
            {
                tpReturn = typeof(CartaoPontoHeaderLinha6);
            }
            else if (_linha == 8)
            {
                tpReturn = typeof(CartaoPontoHeaderLinha8);
            }
            else if (_linhaDetalhe >= 14 && _dContinuaDetalhes)
            {
                if (recordLine.Contains("-----"))
                {
                    _linhaDetalhe = 0;
                    _dContinuaDetalhes = false;
                    _dContinuaRodape = true;
                }
                else
                {
                    tpReturn = typeof(CartaoPontoDetalhesLinha14);
                }
            }
            else if (_dContinuaRodape)
            {
                if (recordLine.Contains("BANCO DE HORAS REALIZADO NO PERIODO:"))
                {
                    tpReturn = typeof(CartaoPontoSaldoHorasLinha1);
                    _dBancoDeHorasRealizado = true;
                }
                else if (_dBancoDeHorasRealizado)
                {
                    tpReturn = typeof(CartaoPontoSaldoHorasLinha2);
                    _dBancoDeHorasRealizado = false;
                }
                else if (recordLine.Contains("COMPENSAÇÃO DIA PONTE REALIZADA NO PERIODO:"))
                {
                    tpReturn = typeof(CartaoPontoSaldoHorasLinha4);
                    _dCompesacaoDiaPonte = true;
                }
                else if (_dCompesacaoDiaPonte)
                {
                    tpReturn = typeof(CartaoPontoSaldoHorasLinha5);
                    _dCompesacaoDiaPonte = false;
                }
                else if (recordLine.Contains("HRS. POSITIVAS:"))
                {
                    tpReturn = typeof(CartaoPontoSaldoHorasLinha10);
                }
                else if (recordLine.Contains("HRS. NEGATIVAS:"))
                {
                    tpReturn = typeof(CartaoPontoSaldoHorasLinha11);
                }
                else if (recordLine.Contains("SALDO         :"))
                {
                    tpReturn = typeof(CartaoPontoSaldoHorasLinha12);
                }
                else if (recordLine.Contains("PAGAS         :"))
                {
                    tpReturn = typeof(CartaoPontoSaldoHorasLinha13);
                }
                else if (recordLine.Contains("DESCONTADAS   :"))
                {
                    tpReturn = typeof(CartaoPontoSaldoHorasLinha14);
                }
                else if (recordLine.Contains("COMPENSADAS   :"))
                {
                    tpReturn = typeof(CartaoPontoSaldoHorasLinha15);
                    _dContinuaRodape = false;
                }
            }
            else if (_linha == 128)
            {
                tpReturn = typeof(CartaoPontoSaldoHorasLinha128);
                _dContinuaDetalhes = true;
                _dContinuaRodape = false;
                _dBancoDeHorasRealizado = false;
                _dCompesacaoDiaPonte = false;
                _linhaDetalhe = 0;
                _linha = 0;
            }
            return tpReturn;
        }
    }
}