using BACENModel;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace BACENPersistence
{
    public class BancoDAO : IBancoDAO
    {
     
        public bool PlanSave(DataTable table)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["BancoDB"].ConnectionString))
            {
                connection.Open();
                using (SqlBulkCopy bulkCopy = new SqlBulkCopy(connection))
                {
                    foreach (DataColumn c in table.Columns)
                        bulkCopy.ColumnMappings.Add(c.ColumnName, c.ColumnName);

                    bulkCopy.DestinationTableName = "BanksPlan";
                    //try
                    //{
                    bulkCopy.WriteToServer(table);
                    //}
                }
            }


                return true;
        }

        public List<Bank> PlanDistribute(string arq)
        {
            List<Bank> bancos = new List<Bank>();
            
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["BancoDB"].ConnectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("SP_DistributiveBanksPlan", conn);

                cmd.CommandType = CommandType.StoredProcedure;

                // 3. add parameter to command, which will be passed to the stored procedure
                cmd.Parameters.Add(new SqlParameter("@Arquivo", arq));

                // execute the command
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {

                    while (rdr.Read())
                    {
                        bancos.Add(new Bank {
                            Codigo = int.Parse(rdr["CodBank"].ToString()),
                            Name = rdr["Name"].ToString(),
                            ISPB = rdr["ISPB"].ToString(),
                            Status = int.Parse(rdr["StatusCIP"].ToString()),
                    });
                }

                }
            }
            return bancos;
        }

            
    }
}
