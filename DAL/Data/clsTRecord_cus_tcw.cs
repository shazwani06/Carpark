using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public partial class clsTRecord
    {
        // Get Parking Hour by Car Plate No
        public static DataTable GetDataTable_By_Carplate_ForParkingHours(string CarPlate, int CompanyId)
        {
            DataTable result = null; 
            try
            {
                result = new DataTable(); 
                using (SqlConnection Conn = new SqlConnection(clsConst.SysDBConnString))
                {
                    Conn.Open(); using (SqlCommand command = new SqlCommand("[NSP_TRecord_SelectBy_CarPlate_ForCalculation]", Conn))
                    {
                        SqlParameter Param = new System.Data.SqlClient.SqlParameter();
                        command.CommandType = CommandType.StoredProcedure;

                        Param = new System.Data.SqlClient.SqlParameter();
                        Param.ParameterName = "@CarPlate";
                        Param.SqlDbType = SqlDbType.NVarChar;
                        Param.Direction = ParameterDirection.Input;
                        Param.Value = CarPlate;
                        command.Parameters.Add(Param);

                        Param = new System.Data.SqlClient.SqlParameter();
                        Param.ParameterName = "@CompanyId";
                        Param.SqlDbType = SqlDbType.Int;
                        Param.Direction = ParameterDirection.Input;
                        Param.Value = CompanyId;
                        command.Parameters.Add(Param);
                        System.Data.SqlClient.SqlDataReader SQLReader = command.ExecuteReader();
                        result.Load(SQLReader);
                        SQLReader.Close();
                        SQLReader = null;
                    }
                }
            }
            catch (SqlException ex)
            {
                clsLogger.ErrorLog(fstrPageName, ex);
            }
            return result;
        }


        public static DataTable GetDataTable_By_ForCustomInsert(string CarPlate, int CompanyId)
        {
            DataTable result = null;

            try
            {
                result = new DataTable();

                using (SqlConnection Conn = new SqlConnection(clsConst.SysDBConnString))
                {
                    Conn.Open(); using (SqlCommand command = new SqlCommand("[NSP_TRecord_SelectBy_CarPlate_For_Custom_Insert]", Conn))
                    {
                        System.Data.SqlClient.SqlParameter Param = new System.Data.SqlClient.SqlParameter();
                        command.CommandType = CommandType.StoredProcedure;

                        Param = new System.Data.SqlClient.SqlParameter();
                        Param.ParameterName = "@CarPlate";
                        Param.SqlDbType = SqlDbType.NVarChar;
                        Param.Direction = ParameterDirection.Input;
                        Param.Value = CarPlate;
                        command.Parameters.Add(Param);

                        Param = new System.Data.SqlClient.SqlParameter();
                        Param.ParameterName = "@CompanyId";
                        Param.SqlDbType = SqlDbType.Int;
                        Param.Direction = ParameterDirection.Input;
                        Param.Value = CompanyId;
                        command.Parameters.Add(Param);
                        System.Data.SqlClient.SqlDataReader SQLReader = command.ExecuteReader();
                        result.Load(SQLReader);
                        SQLReader.Close();
                        SQLReader = null;
                    }
                }
            }
            catch (SqlException ex)
            {
                clsLogger.ErrorLog(fstrPageName, ex);
            }
            return result;
        }

        public static DataTable Insert_Custom_001(int RecordId, int CompanyId, string TransactionNo, string CarPlate, string VisitType, string CreatedBy, int GateId, double ChargeAmount)
        {
            DataTable result = null;

            try
            {
                result = new DataTable();

                using (SqlConnection Conn = new SqlConnection(clsConst.SysDBConnString))
                {
                    Conn.Open(); using (SqlCommand command = new SqlCommand("[NSP_TRecord_Insert_Custom]", Conn))
                    {
                        System.Data.SqlClient.SqlParameter Param = new System.Data.SqlClient.SqlParameter();
                        command.CommandType = CommandType.StoredProcedure;

                        Param = new System.Data.SqlClient.SqlParameter();
                        Param.ParameterName = "@RecordId";
                        Param.SqlDbType = SqlDbType.Int;
                        Param.Direction = ParameterDirection.Input;
                        Param.Value = RecordId;
                        command.Parameters.Add(Param);

                        Param = new System.Data.SqlClient.SqlParameter();
                        Param.ParameterName = "@CompanyId";
                        Param.SqlDbType = SqlDbType.Int;
                        Param.Direction = ParameterDirection.Input;
                        Param.Value = CompanyId;
                        command.Parameters.Add(Param);

                        Param = new System.Data.SqlClient.SqlParameter();
                        Param.ParameterName = "@TransactionNo";
                        Param.SqlDbType = SqlDbType.NVarChar;
                        Param.Direction = ParameterDirection.Input;
                        Param.Value = TransactionNo;
                        command.Parameters.Add(Param);

                                                Param = new System.Data.SqlClient.SqlParameter();
                        Param.ParameterName = "@CarPlate";
                        Param.SqlDbType = SqlDbType.NVarChar;
                        Param.Direction = ParameterDirection.Input;
                        Param.Value = CarPlate;
                        command.Parameters.Add(Param);
                        
                        Param = new System.Data.SqlClient.SqlParameter();
                        Param.ParameterName = "@VisitType";
                        Param.SqlDbType = SqlDbType.NVarChar;
                        Param.Direction = ParameterDirection.Input;
                        Param.Value = VisitType;
                        command.Parameters.Add(Param);
                        
                        Param = new System.Data.SqlClient.SqlParameter();
                        Param.ParameterName = "@CreatedBy";
                        Param.SqlDbType = SqlDbType.NVarChar;
                        Param.Direction = ParameterDirection.Input;
                        Param.Value = CreatedBy;
                        command.Parameters.Add(Param);

                        Param = new System.Data.SqlClient.SqlParameter();
                        Param.ParameterName = "@GateId";
                        Param.SqlDbType = SqlDbType.Int;
                        Param.Direction = ParameterDirection.Input;
                        Param.Value = GateId;
                        command.Parameters.Add(Param);

                        Param = new System.Data.SqlClient.SqlParameter();
                        Param.ParameterName = "@ChargeAmount";
                        Param.SqlDbType = SqlDbType.Decimal;
                        Param.Direction = ParameterDirection.Input;
                        Param.Value = ChargeAmount;
                        command.Parameters.Add(Param);

                        System.Data.SqlClient.SqlDataReader SQLReader = command.ExecuteReader();
                        result.Load(SQLReader);
                        SQLReader.Close();
                        SQLReader = null;
                    }
                }
            }
            catch (SqlException ex)
            {
                clsLogger.ErrorLog(fstrPageName, ex);
            }
            return result;
        }
    }
}
