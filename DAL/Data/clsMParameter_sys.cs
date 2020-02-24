using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{

    public partial class clsMParameter
    {
        private string _keytype = "";
        private string _keyvalue = "";
        private string _remark = "";

        public string KeyType
        {
            get
            {
                return _keytype;
            }
            set
            {
                _keytype = value;
            }
        }

        public string KeyValue
        {
            get
            {
                return _keyvalue;
            }
            set
            {
                _keyvalue = value;
            }
        }

        public string Remark
        {
            get
            {
                return _remark;
            }
            set
            {
                _remark = value;
            }
        }
    } // clsMParameter

    public partial class clsMParameter
    {
        private static string fstrPageName = "clsMParameter";

        public static clsMParameter DtToObj(DataRow dr)
        {
            clsMParameter obj = new clsMParameter();
            try
            {
                obj.KeyType = clsCommon.ToStr(dr["KeyType"]);
                obj.KeyValue = clsCommon.ToStr(dr["KeyValue"]);
                obj.Remark = clsCommon.ToStr(dr["Remark"]);
            }
            catch (Exception ex)
            {
                clsLogger.ErrorLog(fstrPageName, ex);
            }
            return obj;
        }

        public static DataTable GetAllDataTable(string KeyType)
        {
            DataTable result = null;

            try
            {
                result = new DataTable();

                using (SqlConnection Conn = new SqlConnection(clsConst.SysDBConnString))
                {
                    Conn.Open();
                    using (SqlCommand command = new SqlCommand("Nsp_MParameter_SelectAll", Conn))
                    {
                        SqlParameter Param = new SqlParameter();
                        command.CommandType = CommandType.StoredProcedure;

                        Param = new SqlParameter();
                        Param.ParameterName = "@KeyType";
                        Param.SqlDbType = SqlDbType.NVarChar;
                        Param.Size = 100;
                        Param.Direction = ParameterDirection.Input;
                        Param.Value = clsCommon.ToStr(KeyType);
                        command.Parameters.Add(Param);

                        SqlDataReader SQLReader = command.ExecuteReader();
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

        private static List<clsMParameter> GetListByPK(string KeyType)
        {
            List<clsMParameter> result = new List<clsMParameter>();
            try
            {
                DataTable dt = new DataTable();
                dt = GetDataTableByPK(KeyType);
                if (dt.Rows.Count == 0)
                    result = null;
                else
                    for (int index = 0; index <= dt.Rows.Count - 1; index++)
                    {
                        clsMParameter obj;
                        obj = DtToObj(dt.Rows[index]);
                        result.Add(obj);
                    }
            }
            catch (Exception ex)
            {
                result = null;
                clsLogger.ErrorLog(fstrPageName, ex);
            }
            return result;
        }

        public static clsMParameter GetDataObjByPK(string KeyType)
        {
            List<clsMParameter> list = new List<clsMParameter>();
            try
            {
                list = GetListByPK(KeyType);
            }
            catch (Exception ex)
            {
                clsLogger.ErrorLog(fstrPageName, ex);
                return null;
            }
            if (list != null)
                return list[0];
            else
                return null;
        }

        public static DataTable GetDataTableByPK(string KeyType)
        {
            DataTable result = null;

            try
            {
                result = new DataTable();

                using (SqlConnection Conn = new SqlConnection(clsConst.SysDBConnString))
                {
                    Conn.Open();
                    using (SqlCommand command = new SqlCommand("Nsp_MParameter_SelectByPK", Conn))
                    {
                        SqlParameter Param = new SqlParameter();
                        command.CommandType = CommandType.StoredProcedure;

                        Param = new SqlParameter();
                        Param.ParameterName = "@KeyType";
                        Param.SqlDbType = SqlDbType.NVarChar;
                        Param.Size = 100;
                        Param.Direction = ParameterDirection.Input;
                        Param.Value = clsCommon.ToStr(KeyType);
                        command.Parameters.Add(Param);

                        SqlDataReader SQLReader = command.ExecuteReader();
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

        public static bool Delete(clsMParameter obj)
        {
            try
            {
                using (SqlConnection Conn = new SqlConnection(clsConst.SysDBConnString))
                {
                    Conn.Open();
                    using (SqlCommand command = new SqlCommand("Nsp_MParameter_Delete", Conn))
                    {
                        SqlParameter Param = new SqlParameter();
                        command.CommandType = CommandType.StoredProcedure;
                        Param = new SqlParameter();
                        Param.ParameterName = "@KeyType";
                        Param.SqlDbType = SqlDbType.NVarChar;
                        Param.Size = 100;
                        Param.Direction = ParameterDirection.Input;
                        Param.Value = clsCommon.ToStr(obj.KeyType);
                        command.Parameters.Add(Param);

                        command.ExecuteNonQuery();
                        command.Dispose();
                    }
                }

                return true;
            }
            catch (SqlException ex)
            {


                clsLogger.ErrorLog(fstrPageName, ex);
                return false;
            }
        }

        public static bool Insert(clsMParameter obj)
        {
            try
            {
                using (SqlConnection Conn = new SqlConnection(clsConst.SysDBConnString))
                {
                    Conn.Open();
                    using (SqlCommand command = new SqlCommand("Nsp_MParameter_Insert", Conn))
                    {
                        SqlParameter Param = new SqlParameter();
                        command.CommandType = CommandType.StoredProcedure;
                        Param = new SqlParameter();
                        Param.ParameterName = "@KeyType";
                        Param.SqlDbType = SqlDbType.NVarChar;
                        Param.Size = 100;
                        Param.Direction = ParameterDirection.Input;
                        Param.Value = clsCommon.ToStr(obj.KeyType);
                        command.Parameters.Add(Param);

                        Param = new SqlParameter();
                        Param.ParameterName = "@KeyValue";
                        Param.SqlDbType = SqlDbType.NVarChar;
                        Param.Size = 4000;
                        Param.Direction = ParameterDirection.Input;
                        Param.Value = clsCommon.ToStr(obj.KeyValue);
                        command.Parameters.Add(Param);

                        Param = new SqlParameter();
                        Param.ParameterName = "@Remark";
                        Param.SqlDbType = SqlDbType.NVarChar;
                        Param.Size = 500;
                        Param.Direction = ParameterDirection.Input;
                        Param.Value = clsCommon.ToStr(obj.Remark);
                        command.Parameters.Add(Param);

                        command.ExecuteNonQuery();
                        command.Dispose();
                    }
                }

                return true;
            }
            catch (SqlException ex)
            {

                clsLogger.ErrorLog(fstrPageName, ex);
                return false;
            }
        }

        public static bool Update(clsMParameter obj)
        {
            try
            {
                using (SqlConnection Conn = new SqlConnection(clsConst.SysDBConnString))
                {
                    Conn.Open();
                    using (SqlCommand command = new SqlCommand("Nsp_MParameter_Update", Conn))
                    {
                        SqlParameter Param = new SqlParameter();
                        command.CommandType = CommandType.StoredProcedure;
                        Param = new SqlParameter();
                        Param.ParameterName = "@KeyType";
                        Param.SqlDbType = SqlDbType.NVarChar;
                        Param.Size = 100;
                        Param.Direction = ParameterDirection.Input;
                        Param.Value = clsCommon.ToStr(obj.KeyType);
                        command.Parameters.Add(Param);

                        Param = new SqlParameter();
                        Param.ParameterName = "@KeyValue";
                        Param.SqlDbType = SqlDbType.NVarChar;
                        Param.Size = 4000;
                        Param.Direction = ParameterDirection.Input;
                        Param.Value = clsCommon.ToStr(obj.KeyValue);
                        command.Parameters.Add(Param);

                        Param = new SqlParameter();
                        Param.ParameterName = "@Remark";
                        Param.SqlDbType = SqlDbType.NVarChar;
                        Param.Size = 500;
                        Param.Direction = ParameterDirection.Input;
                        Param.Value = clsCommon.ToStr(obj.Remark);
                        command.Parameters.Add(Param);

                        command.ExecuteNonQuery();
                        command.Dispose();
                    }
                }

                return true;
            }
            catch (SqlException ex)
            {

                clsLogger.ErrorLog(fstrPageName, ex);
                return false;
            }
        }

        public static string GetColumn_KeyValue_ByPK(string KeyType)
        {
            string result = "";
            try
            {
                clsMParameter obj = new clsMParameter();
                obj = GetDataObjByPK(KeyType);
                if (obj != null)
                    result = obj.KeyValue.Trim();
                obj = null;
            }
            catch (Exception ex)
            {
                clsLogger.ErrorLog(fstrPageName, ex);
            }
            return result;
        }

        public static string GetColumn_Remark_ByPK(string KeyType)
        {
            string result = "";
            try
            {
                clsMParameter obj = new clsMParameter();
                obj = GetDataObjByPK(KeyType);
                if (obj != null)
                    result = obj.Remark.Trim();
                obj = null;
            }
            catch (Exception ex)
            {
                clsLogger.ErrorLog(fstrPageName, ex);
            }
            return result;
        }
    }


}

