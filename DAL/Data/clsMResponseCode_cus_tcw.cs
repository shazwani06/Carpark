using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public partial class clsMResponseCode
    {
       static string fstrPageName = "clsMResponseCode";
        public static string GetColumn_ResponseMessage_ByPK(string ResponseCode)
        {
            string result = "";
            try
            {
                DataTable dt = new DataTable();
                dt = GetDataTable_ByPK(ResponseCode);
                if (clsFuncs.DataTableIsNotNothing(dt))
                {
                    return dt.Rows[0]["ResponseMessage"].ToString();
                }
            }
            catch (Exception ex)
            {
                clsLogger.ErrorLog(fstrPageName, ex);
            }

            return result;
        }


        public static DataTable GetDataTable_ByPK(string ResponseCode)
        {
            DataTable Result = new DataTable();
            try
            {
                {
                    using (SqlConnection Conn = new SqlConnection(clsConst.SysDBConnString))
                    {
                        Conn.Open();
                        using (SqlCommand command = new SqlCommand("NSP_MResponseCode_SelectByPK", Conn))
                        {
                            SqlParameter Param = new SqlParameter();
                            command.CommandType = CommandType.StoredProcedure;

                            Param = new SqlParameter();
                            Param.ParameterName = "@ResponseCode";
                            Param.SqlDbType = SqlDbType.NVarChar;
                            Param.Direction = ParameterDirection.Input;
                            Param.Value = clsCommon.ToStr(ResponseCode);
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
