using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL 
{
    public partial class clsTGateWay
    {

        public static DataTable GetDataTable_By_GateCode(string GateCode)
        {
            DataTable Result = new DataTable();
            try
            {
                {
                    using (SqlConnection Conn = new SqlConnection(clsConst.SysDBConnString))
                    {
                        Conn.Open();
                        using (SqlCommand command = new SqlCommand("[NSP_TGateWay_SelectBy_GateCode]", Conn))
                        {
                            SqlParameter Param = new SqlParameter();
                            command.CommandType = CommandType.StoredProcedure;

                            Param = new SqlParameter();
                            Param.ParameterName = "@GateCode";
                            Param.SqlDbType = SqlDbType.NVarChar;
                            Param.Direction = ParameterDirection.Input;
                            Param.Value = clsCommon.ToStr(GateCode);
                            command.Parameters.Add(Param);

                            SqlDataReader SQLReader = command.ExecuteReader();

                            Result.Load(SQLReader);

                            SQLReader.Close();
                            SQLReader = null;
                        }
                        return Result;
                    }
                }
            }
            catch (Exception ex)
            {
                clsLogger.ErrorLog("GetDataTable_ByPK", ex);
            }
            return null;
        }
    }
}
