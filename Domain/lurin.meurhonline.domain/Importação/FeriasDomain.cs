using FileHelpers;
using lurin.meurhonline.domain.Interface;
using lurin.meurhonline.domain.model;
using System;
using System.Collections.Generic;
using System.Text;
using lurin.meurhonline.domain.importacao.layout.Ferias;

namespace lurin.meurhonline.domain
{

    public class FeriasDomain : IFeriasDomain<FeriasModel>
    {
        private int numLinha = 0;
        private int pulaLinha = 0;
        private IList<FeriasModel> listaFeriasModel = new List<FeriasModel>();
        private FeriasModel model = new FeriasModel();
        private FeriasPeriodoModel periodo = new FeriasPeriodoModel();
        private string codEstabelecimento;

        public IList<FeriasModel> ImportarFerias(FeriasModel ferias)
        {
            var engine = new MultiRecordEngine(typeof(Estabelecimento),
                                               typeof(Detalhe));

            engine.RecordSelector = new RecordTypeSelector(CustomSelector);

            byte[] data = Convert.FromBase64String(ferias.DocumentoBase64);
            string decodedString = Encoding.GetEncoding(1252).GetString(data);
            var res = engine.ReadString(decodedString);

            foreach (var rec in res)
            {
                if (rec.GetType().Name == "Estabelecimento")
                {
                    Estabelecimento linha = (Estabelecimento)rec;
                    codEstabelecimento = linha.codEstabelecimento;
                }
                else if (rec.GetType().Name == "Detalhe")
                {
                    Detalhe linha = (Detalhe)rec;

                    if (!String.IsNullOrWhiteSpace(linha.Matricula))
                    {
                        if (!String.IsNullOrWhiteSpace(model.Matricula))
                        {
                            listaFeriasModel.Add(model);
                            model = new FeriasModel();
                        }
                        model.Estabelecimento = codEstabelecimento;
                        model.Matricula = linha.Matricula;
                    }
                    if (!String.IsNullOrWhiteSpace(linha.InicioPeriodo))
                    {
                        periodo = new FeriasPeriodoModel()
                        {
                            InicioPeriodo = linha.InicioPeriodo,
                            FimPeriodo = linha.FimPeriodo,
                            Situacao = linha.Situacao,
                            DiasDireito = linha.DiasDireito,
                            DiasConcedidos = linha.DiasConcedido,
                            DiasProgramados = linha.DiasProgramado,
                            Saldo = linha.Saldo
                        };
                        model.Periodo.Add(periodo);
                    }

                    if (!String.IsNullOrWhiteSpace(linha.InicioFerias))
                    {
                        periodo.Concessao.Add(new FeriasConcessaoModel()
                        {
                            InicioFerias = linha.InicioFerias,
                            DiasGozo = linha.DiasGozo,
                            DiasAbono = linha.DiasAbono,
                            DiasLicenca = linha.DiasLicenca
                        });
                    }
                }
            }
            listaFeriasModel.Add(model);
            return listaFeriasModel;
        }

        private Type CustomSelector(MultiRecordEngine engine, string recordLine)
        {
            numLinha++;
            if (pulaLinha > 0)
            {
                pulaLinha--;
                return null;
            }
            else if (numLinha == 5)
            {
                return typeof(Estabelecimento);
            }
            else if (recordLine.Length < 10)
            {
                return null;
            }
            else if (numLinha >= 10 && recordLine.StartsWith("--------------------------------------------------------------------------------"))
            {
                pulaLinha = 9;
                return null;
            }
            else if (numLinha >= 10)
            {
                return typeof(Detalhe);
            }
            else
                return null;
        }

        private void AdicionarRegistro()
        {
            if (!String.IsNullOrEmpty(model.Matricula))
            {
                listaFeriasModel.Add(model);
                model = new FeriasModel();
            }
        }
    }
}
