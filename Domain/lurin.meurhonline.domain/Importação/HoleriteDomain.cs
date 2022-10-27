using System.Collections.Generic;

using lurin.meurhonline.domain.model;
using lurin.meurhonline.domain.interfaces;
using lurin.meurhonline.infrastructure.persistence.interfaces;
using FileHelpers;
using System;
using System.Text;
using lurin.meurhonline.domain.layout.importacao.Holerite;
using System.Collections.ObjectModel;
using ExcelDataReader;
using System.Data;
using System.IO;
using Microsoft.Office.Interop.Excel;
using System.Reflection;
using System.Web;
using System.Runtime.InteropServices;
using System.Linq;

namespace lurin.meurhonline.domain
{
    public class HoleriteDomain : IHoleriteDomain<HoleriteModel>
    {
        public object[] objHolerite = null;
        private int _numLinha = 0;
        private const int XLS_MAX_COLUMN = 28;
        private const int XLS_MAX_BLANK_LINE = 3;
        private int estadoInterpretador = 0;
        private int indiceAnterior = 0;

        public HoleriteDomain(IUnitOfWork unitOfWork)
        { }

        public bool DecodeArquivoTxtHolerite(HoleriteModel holeriteModel)
        {
            byte[] data = Convert.FromBase64String(holeriteModel.DocumentoBase64);
            string decodedString = Encoding.GetEncoding(1252).GetString(data);
            bool bReturn = false;

            var engine = new MultiRecordEngine(typeof(HoleriteLinha3),
                typeof(HoleriteLinha7a23),
                typeof(HoleriteLinha24),
                typeof(HoleriteLinha26),
                typeof(HoleriteLinha28));

            engine.RecordSelector = new RecordTypeSelector(CustomSelector);

            objHolerite = engine.ReadString(decodedString);

            if (objHolerite != null)
            {
                bReturn = true;
            }

            return bReturn;
        }

        public bool DecodeArquivoXlsHolerite(HoleriteModel holeriteModel)
        {
            bool bReturn = false;

            objHolerite = ConverterArquivoExcel(holeriteModel.DocumentoBase64);

            if (objHolerite.Length > 0)
            {
                bReturn = true;
            }

            return bReturn;
        }

        public List<HoleriteModel> AdicionarHolerite(HoleriteModel holeriteModel)
        {
            List<HoleriteModel> result = new List<HoleriteModel>();
            HoleriteModel itemHolerite = new HoleriteModel();
            itemHolerite.HoleriteEventos = new Collection<HoleriteEventoModel>();
            HoleriteEventoModel itemHoleritrEvento = null;

            foreach (var item in objHolerite)
            {
                itemHolerite.DataCadastro = DateTime.Now;
                itemHolerite.EmpresaId = holeriteModel.EmpresaId;
                itemHolerite.Mes = holeriteModel.Mes;
                itemHolerite.Ano = holeriteModel.Ano;

                if (item.GetType() == typeof(HoleriteLinha3))
                {
                    HoleriteLinha3 holeriteAux = (HoleriteLinha3)item;
                    itemHolerite.Matricula = holeriteAux.Matricula;
                    itemHolerite.Nome = holeriteAux.Nome;
                }

                if (item.GetType() == typeof(HoleriteLinha7a23))
                {
                    HoleriteLinha7a23 holeriteEventoAux = (HoleriteLinha7a23)item;
                    if (!string.IsNullOrEmpty(holeriteEventoAux.Evento))
                    {
                        itemHoleritrEvento = new HoleriteEventoModel();
                        itemHoleritrEvento.DataCadastro = DateTime.Now;
                        itemHoleritrEvento.Evento = holeriteEventoAux.Evento;
                        itemHoleritrEvento.Descricao = holeriteEventoAux.Descricao;
                        itemHoleritrEvento.Quantidade = holeriteEventoAux.Quantidade;
                        itemHoleritrEvento.ValoresPositivos = holeriteEventoAux.ValoresPositivos;
                        itemHoleritrEvento.ValoresNegativos = holeriteEventoAux.ValoresNegativos;
                        itemHolerite.HoleriteEventos.Add(itemHoleritrEvento);
                    }
                }

                if (item.GetType() == typeof(HoleriteLinha24))
                {
                    HoleriteLinha24 holeriteAux = (HoleriteLinha24)item;
                    itemHolerite.TotalProventos = holeriteAux.TotalProventos;
                    itemHolerite.TotalDescontos = holeriteAux.TotalDescontos;
                }

                if (item.GetType() == typeof(HoleriteLinha26))
                {
                    HoleriteLinha26 holeriteAux = (HoleriteLinha26)item;
                    itemHolerite.Liquido = holeriteAux.Liquido;
                }

                if (item.GetType() == typeof(HoleriteLinha28))
                {
                    HoleriteLinha28 holeriteAux = (HoleriteLinha28)item;
                    itemHolerite.SalarioBase = holeriteAux.SalarioBase;
                    itemHolerite.SalarioContrINSS = holeriteAux.SalarioContrINSS;
                    itemHolerite.BaseCalcFGTS = holeriteAux.BaseCalcFGTS;
                    itemHolerite.FTGSMes = holeriteAux.FTGSMes;
                    itemHolerite.BaseCalcIRRF = holeriteAux.BaseCalcIRRF;
                    result.Add(itemHolerite);
                    itemHolerite = new HoleriteModel();
                    itemHolerite.HoleriteEventos = new Collection<HoleriteEventoModel>();
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
                case 3:
                    tpReturn = typeof(HoleriteLinha3);
                    break;
                case 7:
                case 8:
                case 9:
                case 10:
                case 11:
                case 12:
                case 13:
                case 14:
                case 15:
                case 16:
                case 17:
                case 18:
                case 19:
                case 20:
                case 21:
                case 22:
                case 23:
                    tpReturn = typeof(HoleriteLinha7a23);
                    break;
                case 24:
                    tpReturn = typeof(HoleriteLinha24);
                    break;
                case 26:
                    tpReturn = typeof(HoleriteLinha26);
                    break;
                case 28:
                    tpReturn = typeof(HoleriteLinha28);
                    break;
                case 33:
                    _numLinha = 0;
                    break;
                default:
                    tpReturn = null;
                    break;
            }

            return tpReturn;
        }

        public object[] ConverterArquivoExcel(string excelBase64)
        {
            List<object> itensRetorno = new List<object>();

            byte[] data = Convert.FromBase64String(excelBase64);

            string tempPath = $"{HttpRuntime.AppDomainAppPath}temp\\";

            if (!Directory.Exists(tempPath))
                Directory.CreateDirectory(tempPath);

            string tempFilename = $"{tempPath}{Guid.NewGuid()}.xls";

            File.WriteAllBytes(tempFilename, data);

            var app = new Application();
            var workbooks = app.Workbooks;
            var workbook = workbooks.Open(tempFilename);
            var worksheets = workbook.Worksheets;
            var workSheet = (Worksheet)worksheets.get_Item(1);

            var linha = 1;
            var linhasEmBranco = 0;
            var linhas = new List<string[]>();

            while (linhasEmBranco < XLS_MAX_BLANK_LINE)
            {
                var todasColunasEmBranco = true;
                var colunas = new string[XLS_MAX_COLUMN];

                for (var coluna = 1; coluna <= XLS_MAX_COLUMN; coluna++)
                {
                    var rangeWS = workSheet.Cells[linha, coluna];

                    if (rangeWS != null)
                    {
                        var valor = (rangeWS as Range).Value2;

                        if (valor != null)
                        {
                            todasColunasEmBranco = false;
                            colunas[coluna - 1] = valor.ToString().Replace(",", ".");
                        }
                    }
                }

                if (todasColunasEmBranco)
                {
                    linhasEmBranco++;
                }
                else
                {
                    linhas.Add(colunas);
                    linhasEmBranco = 0;
                }

                linha++;
            }

            workbook.Close(false);
            app.Application.Quit();
            app.Quit();

            while (Marshal.ReleaseComObject(worksheets) != 0) { };
            while (Marshal.ReleaseComObject(workbooks) != 0) { };
            while (Marshal.ReleaseComObject(workbook) != 0) { };
            while (Marshal.ReleaseComObject(app) != 0) { };

            app = null;
            workbook = null;
            workbooks = null;
            workSheet = null;
            worksheets = null;

            GC.Collect();
            GC.WaitForPendingFinalizers();

            foreach (var item in linhas)
            {
                var objAtual = InterpertarLinhaDoXls(item);

                if (objAtual != null)
                {
                    itensRetorno.Add(objAtual);
                }
            }

            return itensRetorno.ToArray();
        }

        private object InterpertarLinhaDoXls(string[] row)
        {
            var linhaAtual = RedutorDeLinhas(row);
                       
            if (estadoInterpretador == 0)
            {
                indiceAnterior = 0;
            } 
           
            if(estadoInterpretador == 1 && linhaAtual.Count == 2 && linhaAtual.Where(x => IsDouble(FormatarDados(x))).Count() == 2)
            {
                estadoInterpretador = 2;
            }

            if (estadoInterpretador == 0 && linhaAtual.Count == 4)
            {
               return InterpretadorMatriculaNome(linhaAtual);
            }
            else if (estadoInterpretador == 1 && linhaAtual.Count == 4)
            {
                return InterpretadorDetalhesPositivo(linhaAtual);
            }
            else if (estadoInterpretador == 2 && linhaAtual.Count == 2)
            {
                return InterpretadorProventos(linhaAtual);
            }
            else if (estadoInterpretador == 3 && linhaAtual.Count != 0)
            {
                return InterpretadorProventosLiquidos(linhaAtual);
            }
            else if (estadoInterpretador == 4 && linhaAtual.Count >= 5)
            {
                return InterpretadorResultadoCalculoImposto(linhaAtual);
            }
            else
            {
                return null;
            }
        }

        private HoleriteLinha28 InterpretadorResultadoCalculoImposto(List<string> row)
        {
            estadoInterpretador = 0;
            return new HoleriteLinha28()
            {
                SalarioBase = FormatarDados(row[0]),
                SalarioContrINSS = FormatarDados(row[1]),
                BaseCalcFGTS = FormatarDados(row[2]),
                FTGSMes = FormatarDados(row[3]),
                BaseCalcIRRF = FormatarDados(row[4]),
            };
        }

        private HoleriteLinha26 InterpretadorProventosLiquidos(List<string> row)
        {
            estadoInterpretador = 4;
            var indice = row.Count - 1;

            return new HoleriteLinha26()
            {
                Filler1 = string.Empty,
                Liquido = FormatarDados(row[indice])
            };
        }

        private HoleriteLinha24 InterpretadorProventos(List<string> row)
        {
            estadoInterpretador = 3;
            return new HoleriteLinha24()
            {
                Filler = string.Empty,
                TotalProventos = FormatarDados(row[0]),
                TotalDescontos = FormatarDados(row[1])
            };

        }
        private HoleriteLinha7a23 InterpretadorDetalhesPositivo(List<string> row)
        {
            var valores = row[3].Split('-');            
            var indice = valores[1];
            var indiceInt = Int32.Parse(indice);
            string ValoresPositivos = string.Empty;
            string ValoresNegativos = string.Empty;

            if (indiceInt > indiceAnterior && indiceAnterior != 0)
            {
                ValoresNegativos = FormatarDados(row[3]);
            }
            else 
            {
                ValoresPositivos = FormatarDados(row[3]);
                indiceAnterior = indiceInt;
            }

            return new HoleriteLinha7a23()
            {
                Evento = FormatarDados(row[0]),
                Descricao = FormatarDados(row[1]),
                Quantidade = FormatarDados(row[2]),
                ValoresPositivos = ValoresPositivos,
                ValoresNegativos = ValoresNegativos
            };
        }
        private HoleriteLinha3 InterpretadorMatriculaNome(List<string> row)
        {
            estadoInterpretador = 1;
            return new HoleriteLinha3()
            {
                Matricula = FormatarDados(row[0]),
                Nome = FormatarDados(row[1]),
                Filler1 = string.Empty
            };           
        }
        private List<string> RedutorDeLinhas(string[] row)
        {
            List<string> linhaResultante = new List<string>();

            for (var i = 0; i <= (row.Length - 1); i++)
            {
                if (row[i] != null && !string.IsNullOrEmpty(row[i]) && row[i] != " ")
                {
                    var valor = row[i] + "-" + i.ToString();
                    linhaResultante.Add(valor);
                }
            }
            return linhaResultante; 
        }
        private string FormatarDados(string valor)
        {
            var valores = valor.Split('-');
            var valorFomatado = valores[0].ToString();

            return valorFomatado;
        }
        private bool IsDouble(string value)
        {
            return double.TryParse(value, out _);
        }
    }
}