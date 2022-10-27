using FileHelpers;
using lurin.meurhonline.domain.Interface;
using lurin.meurhonline.domain.model;
using System;
using System.Collections.Generic;
using System.Text;
using lurin.meurhonline.domain.importacao.layout.InformeRendimento;

namespace lurin.meurhonline.domain
{

    public class InformeRendimentoDomain : IInformeRendimentoDomain<InformeRendimentoModel>
    {
        private int numLinha = 0;
        private int numLinhaSessao6 = 1;
        private int numProximaPagina = 0;
        private bool sessao3 = false;
        private bool sessao4 = false;
        private bool sessao5 = false;
        private bool sessao6 = false;
        private bool sessao7 = false;
        private bool sessao8 = false;
        private bool proximaPagina = false;
        private bool gotoProximaPagina = false;

        private IList<InformeRendimentoModel> listaInformeRendimentoModel = new List<InformeRendimentoModel>();
        private InformeRendimentoModel model = new InformeRendimentoModel();
        private List<TipoRendimentoTributaveisModel> listaRendimentoTributaveisModel = new List<TipoRendimentoTributaveisModel>();
        private List<TipoRendimentoIsentosModel> listaRendimentoIsentosModel = new List<TipoRendimentoIsentosModel>();
        private List<TipoRendimentoSujeitosTribModel> listaRendimentoSujeitosTribModel = new List<TipoRendimentoSujeitosTribModel>();
        private List<TipoRendimentoRecebModel> listaRendimentoRecebModel = new List<TipoRendimentoRecebModel>();

        public IList<InformeRendimentoModel> ImportarInformeRendimento(InformeRendimentoModel informeRendimento)
        {
            var engine = new MultiRecordEngine(typeof(IRCabecalho2),
                                               typeof(IRCabecalho3),
                                               typeof(IRCabecalho4),
                                               typeof(IRCabecalho5),
                                               typeof(IRSessao1Linha1),
                                               typeof(IRSessao1Linha2),
                                               typeof(IRSessao2Linha1),
                                               typeof(IRSessao2Linha2),
                                               typeof(IRSessao2Linha3),
                                               typeof(IRSessao2Linha4),
                                               typeof(IRRendimentosSessaoTributaveis),
                                               typeof(IRRendimentosTributaveis),
                                               typeof(IRRendimentosSessaoIsentos),
                                               typeof(IRRendimentosIsentos),
                                               typeof(IRRendimentosSessaoSujeitoTrib),
                                               typeof(IRRendimentosSujeitoTrib),
                                               typeof(IRRendimentosSessaoReceb),
                                               typeof(IRRendimentosReceb),
                                               typeof(IRProcesso),
                                               typeof(IRNaturezaRendimento),
                                               typeof(IRInformacoesComplementares),
                                               typeof(IRDadosResponsavel),
                                               typeof(IRQuebraPagina));

            engine.RecordSelector = new RecordTypeSelector(CustomSelector);

            byte[] data = Convert.FromBase64String(informeRendimento.DocumentoBase64);
            string decodedString = Encoding.GetEncoding(1252).GetString(data);
            var res = engine.ReadString(decodedString);

            foreach (var rec in res)
            {
                if (rec.GetType().Name == "IRCabecalho2")
                {
                    IRCabecalho2 linha = (IRCabecalho2)rec;
                    model.Ministerio = linha.Ministerio;
                    model.TipoDocumento = linha.TipoDocumento;
                }
                else if (rec.GetType().Name == "IRCabecalho3")
                {
                    IRCabecalho3 linha = (IRCabecalho3)rec;
                    model.TipoDocumento += " \n" + linha.ContinuacaoTipoDocumento;
                }
                else if (rec.GetType().Name == "IRCabecalho4")
                {
                    IRCabecalho4 linha = (IRCabecalho4)rec;
                    model.Documento = linha.Documento;
                    model.Secretaria = linha.Secretaria;
                }
                else if (rec.GetType().Name == "IRCabecalho5")
                {
                    IRCabecalho5 linha = (IRCabecalho5)rec;
                    model.AnoCalendario = linha.AnoCalendario;
                    model.Exercicio = linha.Exercicio;
                }
                else if (rec.GetType().Name == "IRSessao1Linha1")
                {
                    IRSessao1Linha1 linha = (IRSessao1Linha1)rec;
                    model.FontePagadora = linha.FontePagadora;
                }
                else if (rec.GetType().Name == "IRSessao1Linha2")
                {
                    IRSessao1Linha2 linha = (IRSessao1Linha2)rec;
                    model.NomeEmpresa = linha.Empresa;
                    model.CNPJ = linha.CNPJ;
                }
                else if (rec.GetType().Name == "IRSessao2Linha1")
                {
                    IRSessao2Linha1 linha = (IRSessao2Linha1)rec;
                    model.DadosPessoaFisica = linha.DadosPessoaFisica;
                }
                else if (rec.GetType().Name == "IRSessao2Linha2")
                {
                    IRSessao2Linha2 linha = (IRSessao2Linha2)rec;
                    model.DescricaoCPF = linha.DescricaoCPF;
                    model.CPF = linha.CPF;
                }
                else if (rec.GetType().Name == "IRSessao2Linha3")
                {
                    IRSessao2Linha3 linha = (IRSessao2Linha3)rec;
                    model.DescricaoNome = linha.DescricaoNome;
                    model.Nome = linha.Nome;
                }
                else if (rec.GetType().Name == "IRSessao2Linha4")
                {
                    IRSessao2Linha4 linha = (IRSessao2Linha4)rec;
                    model.DescricaoNatureza = linha.DescricaoNatureza;
                    model.Natureza = linha.Natureza;
                }
                else if (rec.GetType().Name == "IRRendimentosSessaoTributaveis")
                {
                    IRRendimentosSessaoTributaveis linha = (IRRendimentosSessaoTributaveis)rec;
                    model.TipoRendimento1 = linha.TipoRendimento;
                    model.MoedaRendimento1 = linha.Moeda;
                }
                else if (rec.GetType().Name == "IRRendimentosTributaveis")
                {
                    IRRendimentosTributaveis linha = (IRRendimentosTributaveis)rec;
                    listaRendimentoTributaveisModel.Add(new TipoRendimentoTributaveisModel()
                    {
                        DescricaoTipoEvento = linha.TipoEvento,
                        Valor = linha.Valor
                    });
                }
                else if (rec.GetType().Name == "IRRendimentosSessaoIsentos")
                {
                    IRRendimentosSessaoIsentos linha = (IRRendimentosSessaoIsentos)rec;
                    model.TipoRendimento2 = linha.TipoRendimento;
                    model.MoedaRendimento2 = linha.Moeda;
                }
                else if (rec.GetType().Name == "IRRendimentosIsentos")
                {
                    IRRendimentosIsentos linha = (IRRendimentosIsentos)rec;
                    listaRendimentoIsentosModel.Add(new TipoRendimentoIsentosModel()
                    {
                        DescricaoTipoEvento = linha.TipoEvento,
                        Valor = linha.Valor
                    });
                }
                else if (rec.GetType().Name == "IRRendimentosSessaoSujeitoTrib")
                {
                    IRRendimentosSessaoSujeitoTrib linha = (IRRendimentosSessaoSujeitoTrib)rec;
                    model.TipoRendimento3 = linha.TipoRendimento;
                    model.MoedaRendimento3 = linha.Moeda;
                }
                else if (rec.GetType().Name == "IRRendimentosSujeitoTrib")
                {
                    IRRendimentosSujeitoTrib linha = (IRRendimentosSujeitoTrib)rec;
                    listaRendimentoSujeitosTribModel.Add(new TipoRendimentoSujeitosTribModel()
                    {
                        DescricaoTipoEvento = linha.TipoEvento,
                        Valor = linha.Valor
                    });
                }
                else if (rec.GetType().Name == "IRRendimentosSessaoReceb")
                {
                    IRRendimentosSessaoReceb linha = (IRRendimentosSessaoReceb)rec;
                    model.TipoRendimento4 = linha.TipoRendimento;
                    model.MoedaRendimento4 = linha.Moeda;
                }
                else if (rec.GetType().Name == "IRProcesso")
                {
                    IRProcesso linha = (IRProcesso)rec;
                    model.Processo = linha.Processo;
                }
                else if (rec.GetType().Name == "IRNaturezaRendimento")
                {
                    IRNaturezaRendimento linha = (IRNaturezaRendimento)rec;
                    model.NaturezaRendimento = linha.NaturezaRendimento;
                }
                else if (rec.GetType().Name == "IRRendimentosReceb")
                {
                    IRRendimentosReceb linha = (IRRendimentosReceb)rec;
                    listaRendimentoRecebModel.Add(new TipoRendimentoRecebModel()
                    {
                        DescricaoTipoEvento = linha.TipoEvento,
                        Valor = linha.Valor
                    });
                }
                else if (rec.GetType().Name == "IRInformacoesComplementares")
                {
                    IRInformacoesComplementares linha = (IRInformacoesComplementares)rec;
                    model.InformacoesComplementares += linha.InformacoesComplementares + " \n";
                }
                else if (rec.GetType().Name == "IRDadosResponsavel")
                {
                    IRDadosResponsavel linha = (IRDadosResponsavel)rec;
                    model.DadosResponsavel += linha.DadosResponsavel + " \n";
                }
                else if (rec.GetType().Name == "IRQuebraPagina")
                {
                    AdicionaRegistro();
                }
            }

            return listaInformeRendimentoModel;
        }

        private Type CustomSelector(MultiRecordEngine engine, string recordLine)
        {
            numLinha++;
            if (gotoProximaPagina && proximaPagina)
            {
                if (numProximaPagina < 15)
                {
                    numProximaPagina++;
                }
                else
                {
                    gotoProximaPagina = false;
                    proximaPagina = false;
                    numProximaPagina = 0;
                }
                return null;
            }
            else if (recordLine.Length <= 1)
                return null;
            else if (numLinha == 1)
                return null;
            else if (numLinha == 2)
                return typeof(IRCabecalho2);
            else if (numLinha == 3)
                return typeof(IRCabecalho3);
            else if (numLinha == 4)
                return typeof(IRCabecalho4);
            else if (numLinha == 5)
                return typeof(IRCabecalho5);
            else if (numLinha == 7)
                return typeof(IRSessao1Linha1);
            else if (numLinha == 8)
                return typeof(IRSessao1Linha2);
            else if (numLinha == 10)
                return typeof(IRSessao2Linha1);
            else if (numLinha == 11)
                return typeof(IRSessao2Linha2);
            else if (numLinha == 12)
                return typeof(IRSessao2Linha3);
            else if (numLinha == 13)
                return typeof(IRSessao2Linha4);
            else if (recordLine.Substring(2, 1) == "3" && !sessao7)
            {
                sessao3 = true;
                sessao4 = sessao5 = sessao6 = sessao7 = sessao8 = false;
                return typeof(IRRendimentosSessaoTributaveis);
            }
            else if (recordLine.Substring(2, 1) == "4" && !sessao7)
            {
                sessao4 = true;
                sessao3 = sessao5 = sessao6 = sessao7 = sessao8 = false;
                return typeof(IRRendimentosSessaoIsentos);
            }
            else if (recordLine.Substring(2, 1) == "5" && !sessao7)
            {
                sessao5 = true;
                sessao3 = sessao4 = sessao6 = sessao7 = sessao8 = false;
                return typeof(IRRendimentosSessaoSujeitoTrib);
            }
            else if (recordLine.Substring(2, 1) == "6" && !sessao7)
            {
                sessao6 = true;
                numLinhaSessao6++;
                sessao3 = sessao4 = sessao5 = sessao7 = sessao8 = false;
                return typeof(IRRendimentosSessaoReceb);
            }
            else if (recordLine.Substring(2, 1) == "7" && !sessao7)
            {
                sessao7 = true;
                numLinhaSessao6 = 1;
                sessao3 = sessao4 = sessao5 = sessao6 = sessao8 = false;
                return typeof(IRInformacoesComplementares);
            }
            else if (recordLine.Substring(2, 1) == "8" && !sessao7)
            {
                sessao8 = true;
                sessao3 = sessao4 = sessao5 = sessao6 = sessao7 = false;
                return typeof(IRDadosResponsavel);
            }
            else if (recordLine.Contains("==============================================================================") && !gotoProximaPagina)
            {
                sessao3 = sessao4 = sessao5 = sessao6 = sessao7 = sessao8 = false;
                return null;
            }
            else if ((sessao3 || sessao4 || sessao5 || sessao6) && recordLine.Contains("------------------------------------------") && !gotoProximaPagina)
            {
                return null;
            }
            else if (sessao3)
            {
                return typeof(IRRendimentosTributaveis);
            }
            else if (sessao4)
            {
                return typeof(IRRendimentosIsentos);
            }
            else if (sessao5)
            {
                return typeof(IRRendimentosSujeitoTrib);
            }
            else if (sessao6 && numLinhaSessao6 == 2)
            {
                numLinhaSessao6++;
                return typeof(IRProcesso);
            }
            else if (sessao6 && numLinhaSessao6 == 3)
            {
                numLinhaSessao6++;
                return typeof(IRNaturezaRendimento);
            }
            else if (sessao6 && numLinhaSessao6 >= 4)
            {
                numLinhaSessao6++;
                return typeof(IRRendimentosReceb);
            }
            else if (sessao7 && !gotoProximaPagina)
            {
                if (recordLine.Contains("Continua na Próxima Página..."))
                {
                    gotoProximaPagina = true;
                    return null;
                }
                else
                {
                    return typeof(IRInformacoesComplementares);
                }
            }
            else if (sessao8 && !gotoProximaPagina)
            {
                return typeof(IRDadosResponsavel);
            }

            else if (recordLine.Contains("------------------------------------------------"))
                return null;
            else if (gotoProximaPagina && recordLine.StartsWith("Aprovado pela IN RFB nº 1.682, de 28 de dezembro de 2016"))
            {
                proximaPagina = true;
                return null;
            }
            else if (recordLine.StartsWith("Aprovado pela IN RFB nº 1.682, de 28 de dezembro de 2016"))
            {
                numLinha = 0;
                return typeof(IRQuebraPagina);
            }
            else
                return null;

        }

        private void AdicionaRegistro()
        {
            if (!String.IsNullOrEmpty(model.Ministerio))
            {
                model.TipoRendimentosTributaveis = listaRendimentoTributaveisModel;
                model.TipoRendimentosIsentos = listaRendimentoIsentosModel;
                model.TipoRendimentosSujeitosTrib = listaRendimentoSujeitosTribModel;
                model.TipoRendimentosReceb = listaRendimentoRecebModel;
                listaInformeRendimentoModel.Add(model);

                model = new InformeRendimentoModel();
                listaRendimentoTributaveisModel = new List<TipoRendimentoTributaveisModel>();
                listaRendimentoIsentosModel = new List<TipoRendimentoIsentosModel>();
                listaRendimentoSujeitosTribModel = new List<TipoRendimentoSujeitosTribModel>();
                listaRendimentoRecebModel = new List<TipoRendimentoRecebModel>();
            }
        }
    }
}
