using BACENModel;
using BACENPersistence;

using System.Collections.Generic;
using System.Data;
using System.IO;

namespace BACENBusiness
{
    public class PlanilhaBusiness
    {
        public List<Bank> GetDataFromFile(string arquivo)
        {
            BancoDAO dao = new BancoDAO();
            DataTable importedData = new DataTable();
            string header = "CodBank,ISPB,StatusCIP,Name,Arquivo,Status";

            //try
            //{
                using (StreamReader sr = new StreamReader("C:\\STR\\"+arquivo))
                {
                   
                    string[] headerColumns = header.Split(',');
                    foreach (string headerColumn in headerColumns)
                    {
                        importedData.Columns.Add(headerColumn);
                    }

                int linhas = 0;
                string arq = arquivo.Substring(0, 8);
;            
                    while (!sr.EndOfStream)
                    {
                    linhas++;
                    string line;
                    if (linhas == 1) line = sr.ReadLine();
                    line = sr.ReadLine();
                    if (string.IsNullOrEmpty(line)) continue;
                        string[] fields = line.Split(',');
                        DataRow importedRow;

                    if (fields[2] != "n/a")
                    {
                        importedRow = importedData.NewRow();
                        importedRow[0] = int.Parse(fields[2].TrimStart('0')); //CodBank
                    }
                    else continue;
                        
                            
                                importedRow[1] = fields[0]; //ISPB                            
                    
                                if (fields[3] == "Não") importedRow[2] = 0; //StatusCIP
                                else importedRow[2] = 1;                               
                            
                                importedRow[3] = fields[5]; //Name
                    importedRow[4] = arq;
                    importedRow[5] = "0";
                        
                        importedData.Rows.Add(importedRow);
                    }                
                }


            //}
            //catch (System.Exception e)
            //{

            //}

            if (dao.PlanSave(importedData))
                return dao.PlanDistribute(arquivo);

            return dao.PlanDistribute(arquivo);
        }

       

    }

    
   
}
