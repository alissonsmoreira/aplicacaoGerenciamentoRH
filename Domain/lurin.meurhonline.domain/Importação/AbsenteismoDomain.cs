using lurin.meurhonline.domain.Interface;
using lurin.meurhonline.domain.model;
using System;
using System.Collections.Generic;
using System.Data;
using ExcelDataReader;
using System.IO;

namespace lurin.meurhonline.domain
{

    public class AbsenteismoDomain : IAbsenteismoDomain<AbsenteismoModel>
    {
        private List<AbsenteismoModel> listaAbsenteismo = new List<AbsenteismoModel>();
        
        public IList<AbsenteismoModel> ConverterArquivoExcel(string excelBase64)
        {
            DataSet dsexcelRecords = new DataSet();
            IExcelDataReader reader = null;
            Stream fileStream = null;

            byte[] data = Convert.FromBase64String(excelBase64);
            fileStream = new MemoryStream(data, 0, data.Length);

            if (fileStream != null)
            {
                reader = ExcelReaderFactory.CreateOpenXmlReader(fileStream);

                dsexcelRecords = reader.AsDataSet();
                reader.Close();

                if (dsexcelRecords != null && dsexcelRecords.Tables.Count > 0)
                {
                    DataTable dtAbsenteismo = dsexcelRecords.Tables[0];
                    for (int i = 1; i < dtAbsenteismo.Rows.Count; i++)
                    {
                        AbsenteismoModel abs = new AbsenteismoModel()
                        {
                            Cpf = dtAbsenteismo.Rows[i][0].ToString(),
                            Nome = dtAbsenteismo.Rows[i][1].ToString(),
                            HorasTotais = dtAbsenteismo.Rows[i][2].ToString(),
                            HorasNaoTrabalhadas = dtAbsenteismo.Rows[i][3].ToString(),
                            Absenteismo = dtAbsenteismo.Rows[i][4].ToString()
                        };
                        listaAbsenteismo.Add(abs);
                    }
                }
            }

            return listaAbsenteismo;
        }
    }
}
