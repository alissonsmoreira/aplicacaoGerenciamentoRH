using FileHelpers;
using lurin.meurhonline.domain.Interface;
using lurin.meurhonline.domain.model;
using System;
using System.Collections.Generic;
using System.Text;
using lurin.meurhonline.domain.importacao.layout.ReciboFerias;

namespace lurin.meurhonline.domain
{

    public class ReciboFeriasDomain : IReciboFeriasDomain<ReciboFeriasModel>
    {
        private int numLinha = 0;
        private int pulaLinha = 0;
        private bool vencimentos = false;
        private bool descontos = false;
        private bool texto = false;
        private bool localData = false;
        private bool novaPagina = false;
        private bool desprezar = false;

        private IList<ReciboFeriasModel> listaReciboFeriasModel = new List<ReciboFeriasModel>();
        private ReciboFeriasModel model = new ReciboFeriasModel();
        private List<ReciboFeriasVencimentoModel> listaReciboFeriasVencimentoModel = new List<ReciboFeriasVencimentoModel>();
        private List<ReciboFeriasDescontoModel> listaReciboFeriasDescontoModel = new List<ReciboFeriasDescontoModel>();
        
        public IList<ReciboFeriasModel> ImportarReciboFerias(ReciboFeriasModel reciboFerias)
        {
            var engine = new MultiRecordEngine(typeof(LinhaEstabelecimento),
                                               typeof(LinhaColaborador),
                                               typeof(PeriodoAquisitivo),
                                               typeof(PeriodoGozo),
                                               typeof(PeriodoAbono),
                                               typeof(PeriodoLicenca),
                                               typeof(Vencimento),
                                               typeof(TotalVencimento),
                                               typeof(Desconto),
                                               typeof(TotalDesconto),
                                               typeof(Liquido),
                                               typeof(TextoFinal),
                                               typeof(LocalDataFinal));

            engine.RecordSelector = new RecordTypeSelector(CustomSelector);

            byte[] data = Convert.FromBase64String(reciboFerias.DocumentoBase64);
            string decodedString = Encoding.GetEncoding(1252).GetString(data);
            var res = engine.ReadString(decodedString);

            foreach (var rec in res)
            {
                if (rec.GetType().Name == "LinhaEstabelecimento")
                {
                    LinhaEstabelecimento linha = (LinhaEstabelecimento)rec;
                    model.Estabelecimento = linha.Estabelecimento;
                }
                else if (rec.GetType().Name == "LinhaColaborador")
                {
                    LinhaColaborador linha = (LinhaColaborador)rec;
                    model.CPF = linha.CPF;
                }
                else if (rec.GetType().Name == "PeriodoAquisitivo")
                {
                    PeriodoAquisitivo linha = (PeriodoAquisitivo)rec;
                    model.InicioPeriodoAquisitivo = linha.InicioPeriodo;
                    model.FImPeriodoAquisitivo = linha.FimPeriodo;
                }
                else if (rec.GetType().Name == "PeriodoGozo")
                {
                    PeriodoGozo linha = (PeriodoGozo)rec;
                    model.InicioPeriodoGozo = linha.InicioPeriodo;
                    model.FimPeriodoGozo = linha.FimPeriodo;
                    model.DiasGozo = linha.DiasGozo;
                }
                else if (rec.GetType().Name == "PeriodoAbono")
                {
                    PeriodoAbono linha = (PeriodoAbono)rec;
                    model.InicioPeriodoAbono = linha.InicioPeriodo;
                    model.FimPeriodoAbono = linha.FimPeriodo;
                }
                else if (rec.GetType().Name == "PeriodoLicenca")
                {
                    PeriodoLicenca linha = (PeriodoLicenca)rec;
                    model.InicioPeriodoLicenca = linha.InicioPeriodo;
                    model.FimPeriodoLicenca = linha.FimPeriodo;
                }
                else if (rec.GetType().Name == "Vencimento")
                {
                    Vencimento linha = (Vencimento)rec;
                    listaReciboFeriasVencimentoModel.Add(new ReciboFeriasVencimentoModel()
                    {
                        Evento = linha.Evento,
                        Descricao = linha.Descricao,
                        BaseCalculo = linha.BaseCalculo,
                        Valor = linha.Valor
                    });
                }
                else if (rec.GetType().Name == "TotalVencimento")
                {
                    TotalVencimento linha = (TotalVencimento)rec;
                    model.TotalVencimento = linha.ValorVencimento;
                }
                else if (rec.GetType().Name == "Desconto")
                {
                    Desconto linha = (Desconto)rec;
                    listaReciboFeriasDescontoModel.Add(new ReciboFeriasDescontoModel()
                    {
                        Evento = linha.Evento,
                        Descricao = linha.Descricao,
                        BaseCalculo = linha.BaseCalculo,
                        Valor = linha.Valor
                    });
                }
                else if (rec.GetType().Name == "TotalDesconto")
                {
                    TotalDesconto linha = (TotalDesconto)rec;
                    model.TotalDescontos = linha.ValorDesconto;
                }
                else if (rec.GetType().Name == "Liquido")
                {
                    Liquido linha = (Liquido)rec;
                    model.TotalLiquido = linha.ValorLiquido;
                }
                else if (rec.GetType().Name == "TextoFinal")
                {
                    TextoFinal linha = (TextoFinal)rec;
                    model.Texto += linha.Texto + " \n";
                }
                else if (rec.GetType().Name == "LocalDataFinal")
                {
                    LocalDataFinal linha = (LocalDataFinal)rec;
                    model.LocalData = linha.LocalData;
                    AdicionaRegistro();
                }
            }

            return listaReciboFeriasModel;
        }

        private Type CustomSelector(MultiRecordEngine engine, string recordLine)
        {
            numLinha++;
            if (pulaLinha > 0)
            {
                pulaLinha--;
                if (novaPagina && pulaLinha == 0)
                {
                    numLinha = 1;
                    novaPagina = false;
                }
                return null;
            }
            else if (desprezar && recordLine.Contains("------------------------------------------"))
            {
                desprezar = false;
                return null;
            }
            else if (desprezar)
                return null;

            else if (recordLine.Length <= 1)
                return null;
            else if (numLinha == 2)
                return typeof(LinhaEstabelecimento);
            if (recordLine.Length <= 9)
                return null;
            else if (numLinha == 10)
                return typeof(LinhaColaborador);
            else if (numLinha <= 19)
                return null;
            else if (numLinha == 20)
                return typeof(PeriodoAquisitivo);
            else if (numLinha == 21)
                return typeof(PeriodoGozo);
            else if (numLinha == 22)
                return typeof(PeriodoAbono);
            else if (numLinha == 23)
            {
                vencimentos = true;
                return typeof(PeriodoLicenca);
            }
            else if (numLinha <= 27)
                return null;
            else if (numLinha >= 28 && vencimentos && Char.IsLetter(recordLine[6]))
            {
                vencimentos = false;
                descontos = true;
                pulaLinha = 1;
                return typeof(TotalVencimento);
            }
            else if (numLinha >= 28 && descontos && Char.IsLetter(recordLine[6]))
            {
                vencimentos = false;
                descontos = false;
                pulaLinha = 1;
                return typeof(TotalDesconto);
            }
            else if (numLinha >= 28 && vencimentos)
                return typeof(Vencimento);
            else if (numLinha >= 28 && descontos)
                return typeof(Desconto);
            else if (numLinha >= 28 && !vencimentos && !descontos && !texto && !localData)
            {
                desprezar = true;
                texto = true;
                return typeof(Liquido);
            }
            else if (texto && recordLine.Contains("-----------------------------"))
            {
                texto = false;
                localData = true;
                return null;
            }
            else if (texto)
            {
                return typeof(TextoFinal);
            }
            else if (localData)
            {
                pulaLinha = 7;
                localData = false;
                novaPagina = true;
                return typeof(LocalDataFinal);
            }
            else
                return null;

        }

        private void AdicionaRegistro()
        {
            if (!String.IsNullOrEmpty(model.Estabelecimento))
            {
                model.Vencimentos = listaReciboFeriasVencimentoModel;
                model.Descontos = listaReciboFeriasDescontoModel;
                listaReciboFeriasModel.Add(model);

                model = new ReciboFeriasModel();
                listaReciboFeriasVencimentoModel = new List<ReciboFeriasVencimentoModel>();
                listaReciboFeriasDescontoModel = new List<ReciboFeriasDescontoModel>();
            }
        }
    }
}
