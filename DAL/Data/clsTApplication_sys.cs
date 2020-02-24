using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL 
{
    public partial class clsTApplication
    {

        private string _applicationcode = "";

        private string _applicationname = "";

        private string _secretkey = "";

        public string ApplicationCode
        {
            get
            {
                return _applicationcode;
            }
            set
            {
                _applicationcode = value;
            }
        }

        public string ApplicationName
        {
            get
            {
                return _applicationname;
            }
            set
            {
                _applicationname = value;
            }
        }

        public string SecretKey
        {
            get
            {
                return _secretkey;
            }
            set
            {
                _secretkey = value;
            }
        }
    }
    public partial class clsTApplication
    {

        private static string fstrPageName = "clsTApplication";

        public static clsTApplication DtToObj(DataRow dr)
        {
            clsTApplication obj = new clsTApplication();
            try
            {
                obj.ApplicationCode = clsCommon.ToStr(dr["ApplicationCode"]);
                obj.ApplicationName = clsCommon.ToStr(dr["ApplicationName"]);
                obj.SecretKey = clsCommon.ToStr(dr["SecretKey"]);
            }
            catch (Exception ex)
            {
                clsLogger.ErrorLog(fstrPageName, ex);
            }

            return obj;
        }
         
        public static DataTable GetAllDataTable(string ApplicationCode)
        {
            DataTable result = null;
            try
            {
                using (SqlConnection Conn = new SqlConnection(clsConst.SysDBConnString))
                {
                    Conn.Open();
                    result = new DataTable();
                    using (SqlCommand command = new SqlCommand("Nsp_TApplication_SelectAll", Conn))
                    {
                        SqlParameter Param = new SqlParameter();
                        command.CommandType = CommandType.StoredProcedure;
                        Param = new SqlParameter();
                        Param.ParameterName = "@ApplicationCode";
                        Param.SqlDbType = SqlDbType.NVarChar;
                        Param.Size = 50;
                        Param.Direction = ParameterDirection.Input;
                        Param.Value = clsCommon.ToStr(ApplicationCode);
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

        private static List<clsTApplication> GetListByPK(string ApplicationCode)
        {
            List<clsTApplication> result = new List<clsTApplication>();
            try
            {
                DataTable dt = new DataTable();
                dt = GetDataTableByPK(ApplicationCode);
                if (dt.Rows.Count == 0)
                {
                    result = null;
                }
                else
                {
                    for (int index = 0; index <= dt.Rows.Count - 1; index++)
                    {
                        clsTApplication obj;
                        obj = DtToObj(dt.Rows[index]);
                        result.Add(obj);
                    }
                }
            }
            catch (Exception ex)
            {
                result = null;
                clsLogger.ErrorLog(fstrPageName, ex);
            }

            return result;
        }

        public static clsTApplication GetDataObjByPK(string ApplicationCode)
        {
            List<clsTApplication> list = new List<clsTApplication>();
            try
            {
                list = GetListByPK(ApplicationCode);
            }
            catch (Exception ex)
            {
                clsLogger.ErrorLog(fstrPageName, ex);
                return null;
            }

            if (list != null)
            {
                return list[0];
            }
            else
            {
                return null;
            }
        }

        public static DataTable GetDataTableByPK(string ApplicationCode)
        {
            DataTable result = null;
            try
            {
                using (SqlConnection Conn = new SqlConnection(clsConst.SysDBConnString))
                {
                    Conn.Open();
                    result = new DataTable();
                    using (SqlCommand command = new SqlCommand("Nsp_TApplication_SelectByPK", Conn))
                    {
                        SqlParameter Param = new SqlParameter();
                        command.CommandType = CommandType.StoredProcedure;
                        Param = new SqlParameter();
                        Param.ParameterName = "@ApplicationCode";
                        Param.SqlDbType = SqlDbType.NVarChar;
                        Param.Size = 50;
                        Param.Direction = ParameterDirection.Input;
                        Param.Value = clsCommon.ToStr(ApplicationCode);
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

        public static bool Delete(clsTApplication obj)
        {
            try
            {
                using (SqlConnection Conn = new SqlConnection(clsConst.SysDBConnString))
                {
                    Conn.Open();
                    using (SqlCommand command = new SqlCommand("Nsp_TApplication_Delete", Conn))
                    {
                        SqlParameter Param = new SqlParameter();
                        command.CommandType = CommandType.StoredProcedure;
                        Param = new SqlParameter();
                        Param.ParameterName = "@ApplicationCode";
                        Param.SqlDbType = SqlDbType.NVarChar;
                        Param.Size = 50;
                        Param.Direction = ParameterDirection.Input;
                        Param.Value = clsCommon.ToStr(obj.ApplicationCode);
                        command.Parameters.Add(Param);
                        command.ExecuteNonQuery();
                        command.Dispose();
                    }

                    return true;
                }
            }
            catch (SqlException ex)
            {
                clsLogger.ErrorLog(fstrPageName, ex);
                return false;
            }
        }

        public static bool Insert(clsTApplication obj)
        {
            try
            {
                using (SqlConnection Conn = new SqlConnection(clsConst.SysDBConnString))
                {
                    Conn.Open();
                    using (SqlCommand command = new SqlCommand("Nsp_TApplication_Insert", Conn))
                    {
                        SqlParameter Param = new SqlParameter();
                        command.CommandType = CommandType.StoredProcedure;
                        Param = new SqlParameter();
                        Param.ParameterName = "@ApplicationCode";
                        Param.SqlDbType = SqlDbType.NVarChar;
                        Param.Size = 50;
                        Param.Direction = ParameterDirection.Input;
                        Param.Value = clsCommon.ToStr(obj.ApplicationCode);
                        command.Parameters.Add(Param);
                        Param = new SqlParameter();
                        Param.ParameterName = "@ApplicationName";
                        Param.SqlDbType = SqlDbType.NVarChar;
                        Param.Size = 200;
                        Param.Direction = ParameterDirection.Input;
                        Param.Value = clsCommon.ToStr(obj.ApplicationName);
                        command.Parameters.Add(Param);
                        Param = new SqlParameter();
                        Param.ParameterName = "@SecretKey";
                        Param.SqlDbType = SqlDbType.NVarChar;
                        Param.Size = 200;
                        Param.Direction = ParameterDirection.Input;
                        Param.Value = clsCommon.ToStr(obj.SecretKey);
                        command.Parameters.Add(Param);
                        command.ExecuteNonQuery();
                        command.Dispose();
                    }

                    return true;
                }
            }
            catch (SqlException ex)
            {
                clsLogger.ErrorLog(fstrPageName, ex);
                return false;
            }
        }

        public static bool Update(clsTApplication obj)
        {
            try
            {
                using (SqlConnection Conn = new SqlConnection(clsConst.SysDBConnString))
                {
                    Conn.Open();
                    using (SqlCommand command = new SqlCommand("Nsp_TApplication_Update", Conn))
                    {
                        SqlParameter Param = new SqlParameter();
                        command.CommandType = CommandType.StoredProcedure;
                        Param = new SqlParameter();
                        Param.ParameterName = "@ApplicationCode";
                        Param.SqlDbType = SqlDbType.NVarChar;
                        Param.Size = 50;
                        Param.Direction = ParameterDirection.Input;
                        Param.Value = clsCommon.ToStr(obj.ApplicationCode);
                        command.Parameters.Add(Param);
                        Param = new SqlParameter();
                        Param.ParameterName = "@ApplicationName";
                        Param.SqlDbType = SqlDbType.NVarChar;
                        Param.Size = 200;
                        Param.Direction = ParameterDirection.Input;
                        Param.Value = clsCommon.ToStr(obj.ApplicationName);
                        command.Parameters.Add(Param);
                        Param = new SqlParameter();
                        Param.ParameterName = "@SecretKey";
                        Param.SqlDbType = SqlDbType.NVarChar;
                        Param.Size = 200;
                        Param.Direction = ParameterDirection.Input;
                        Param.Value = clsCommon.ToStr(obj.SecretKey);
                        command.Parameters.Add(Param);
                        command.ExecuteNonQuery();
                        command.Dispose();
                    }

                    return true;
                }
            }
            catch (SqlException ex)
            {

                clsLogger.ErrorLog(fstrPageName, ex);
                return false;
            }
        }

        public static string GetColumn_ApplicationName_ByPK(string ApplicationCode)
        {
            string result = "";
            try
            {
                clsTApplication obj = new clsTApplication();
                obj = GetDataObjByPK(ApplicationCode);
                if (obj != null)
                {
                    result = obj.ApplicationName.Trim();
                }

                obj = null;
            }
            catch (Exception ex)
            {
                clsLogger.ErrorLog(fstrPageName, ex);
            }

            return result;
        }

        public static string GetColumn_SecretKey_ByPK(string ApplicationCode)
        {
            string result = "";
            try
            {
                clsTApplication obj = new clsTApplication();
                obj = GetDataObjByPK(ApplicationCode);
                if (obj != null)
                {
                    result = obj.SecretKey.Trim();
                }

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
