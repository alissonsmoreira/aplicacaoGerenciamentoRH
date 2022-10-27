using FileHelpers;
using lurin.meurhonline.domain.Interface;
using lurin.meurhonline.domain.model;
using System;
using System.Collections.Generic;
using System.Text;
using lurin.meurhonline.domain.importacao.layout.divergencia;
using lurin.meurhonline.domain.model.enumerator;
using System.Globalization;

namespace lurin.meurhonline.domain
{

    public class DivergenciaDomain : IDivergenciaDomain<DivergenciaModel>
    {
        private string codEstabelecimento;
        private DateTime dataDia;
        private int numLinha = 0;
        private int pulaLinha = 0;
        private bool detalhe = false;

        private List<DivergenciaModel> listaDivergencia = new List<DivergenciaModel>();
        private DivergenciaModel model = new DivergenciaModel();
        
        public IList<DivergenciaModel> ImportarDivergencia(DivergenciaModel divergencia)
        {
            var engine = new MultiRecordEngine(typeof(LinhaEstabelecimento),
                                               typeof(LinhaColaborador),
                                               typeof(Detalhe));

            engine.RecordSelector = new RecordTypeSelector(CustomSelector);

            byte[] data = Convert.FromBase64String(divergencia.DocumentoBase64);
            string decodedString = Encoding.GetEncoding(1252).GetString(data);
            var res = engine.ReadString(decodedString);

            var i = 0;
            foreach (var rec in res)
            {
                if (rec.GetType().Name == "LinhaEstabelecimento")
                {
                    LinhaEstabelecimento linha = (LinhaEstabelecimento)rec;
                    codEstabelecimento = linha.Estabelecimento;
                }
                else if (rec.GetType().Name == "LinhaColaborador")
                {
                    if (!String.IsNullOrWhiteSpace(model.Matricula))
                    {
                        listaDivergencia.Add(model);
                        model = new DivergenciaModel();
                    }
                    LinhaColaborador linha = (LinhaColaborador)rec;
                    model.Estabelecimento = codEstabelecimento;
                    model.Matricula = linha.Matricula;
                    model.Nome = linha.Nome;
                }
                else if (rec.GetType().Name == "Detalhe")
                {
                    Detalhe linha = (Detalhe)rec;

                    int dia;
                    if (!String.IsNullOrWhiteSpace(linha.Dia))
                    {                        
                        bool isNumerical = int.TryParse(linha.Dia.Replace("/", ""), out dia);

                        if (isNumerical)
                            dataDia = Convert.ToDateTime(linha.Dia);
                    }
                    
                    model.Detalhes.Add(new DivergenciaDetalheModel()
                    {
                        DiaSemana = linha.DiaSemana,
                        Dia = dataDia,
                        Horario1 = linha.Horario1,
                        Horario2 = linha.Horario2,
                        Horario3 = linha.Horario3,
                        Horario4 = linha.Horario4,
                        InicioJornada = linha.InicioJornada,
                        FimJornada = linha.FimJornada,
                        DiferencaHoras = linha.DiferencaHoras,
                        Descricao = linha.Descricao,
                        SolicitacaoStatusId = (int)SolicitacaoStatusEnum.EM_ANALISE
                    });
                }

                i++;
            }

            listaDivergencia.Add(model);
            return listaDivergencia;
        }

        private Type CustomSelector(MultiRecordEngine engine, string recordLine)
        {
            if (pulaLinha > 0)
            {
                pulaLinha--;
                return null;
            }
            else if (engine.LineNumber == 6)
                return typeof(LinhaEstabelecimento);
            else if (engine.LineNumber >= 11)
            {
                numLinha++;

                if (recordLine.Contains("Período: "))
                {
                    //vai para proxima pagina
                    numLinha = 1;
                    pulaLinha = 16;
                    return null;
                }

                if (detalhe)
                {
                    if (String.IsNullOrEmpty(recordLine))
                    {
                        detalhe = false;
                        return null;
                    }
                    else if (recordLine.Length > 63 && String.IsNullOrWhiteSpace(recordLine.Substring(0, 63)))
                    {
                        return null;
                    }
                    else
                    {
                        return typeof(Detalhe);
                    }
                }
                else if (string.IsNullOrEmpty(recordLine))
                {
                    detalhe = true;
                    return typeof(Detalhe);
                }
                else if (String.IsNullOrWhiteSpace(recordLine.Substring(0, 3)))
                {
                    if (String.IsNullOrWhiteSpace(recordLine.Substring(0, 12)))
                    {
                        return null;
                    }
                    else
                    {
                        return typeof(LinhaColaborador);
                    }
                }
                else
                {
                    detalhe = true;
                    return typeof(Detalhe);
                }
            }
            else
                return null;
        }

    }
}
