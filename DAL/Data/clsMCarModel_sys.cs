
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{

    public partial class clsMCarModel
    {
        private string _modelcode = "";
        private string _modelname = "";

        public string ModelCode
        {
            get
            {
                return _modelcode;
            }
            set
            {
                _modelcode = value;
            }
        }

        public string ModelName
        {
            get
            {
                return _modelname;
            }
            set
            {
                _modelname = value;
            }
        }
    } // clsMCarModel

    public partial class clsMCarModel
    {
        private static string fstrPageName = "clsMCarModel";

        public static clsMCarModel DtToObj(DataRow dr)
        {
            clsMCarModel obj = new clsMCarModel();
            try
            {
                obj.ModelCode = clsCommon.ToStr(dr["ModelCode"]);
                obj.ModelName = clsCommon.ToStr(dr["ModelName"]);
            }
            catch (Exception ex)
            {
                clsLogger.ErrorLog(fstrPageName, ex);
            }
            return obj;
        }

        public static DataTable GetAllDataTable(string ModelCode)
        {
            DataTable result = null;

            try
            {
                result = new DataTable();

                using (SqlConnection Conn = new SqlConnection(clsConst.SysDBConnString))
                {
                    Conn.Open();
                    using (SqlCommand command = new SqlCommand("Nsp_MCarModel_SelectAll", Conn))
                    {
                        SqlParameter Param = new SqlParameter();
                        command.CommandType = CommandType.StoredProcedure;

                        Param = new SqlParameter();
                        Param.ParameterName = "@ModelCode";
                        Param.SqlDbType = SqlDbType.NVarChar;
                        Param.Size = 50;
                        Param.Direction = ParameterDirection.Input;
                        Param.Value = clsCommon.ToStr(ModelCode);
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

        private static List<clsMCarModel> GetListByPK(string ModelCode)
        {
            List<clsMCarModel> result = new List<clsMCarModel>();
            try
            {
                DataTable dt = new DataTable();
                dt = GetDataTableByPK(ModelCode);
                if (dt.Rows.Count == 0)
                    result = null;
                else
                    for (int index = 0; index <= dt.Rows.Count - 1; index++)
                    {
                        clsMCarModel obj;
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

        public static clsMCarModel GetDataObjByPK(string ModelCode)
        {
            List<clsMCarModel> list = new List<clsMCarModel>();
            try
            {
                list = GetListByPK(ModelCode);
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

        public static DataTable GetDataTableByPK(string ModelCode)
        {
            DataTable result = null;

            try
            {
                result = new DataTable();

                using (SqlConnection Conn = new SqlConnection(clsConst.SysDBConnString))
                {
                    Conn.Open();
                    using (SqlCommand command = new SqlCommand("Nsp_MCarModel_SelectByPK", Conn))
                    {
                        SqlParameter Param = new SqlParameter();
                        command.CommandType = CommandType.StoredProcedure;

                        Param = new SqlParameter();
                        Param.ParameterName = "@ModelCode";
                        Param.SqlDbType = SqlDbType.NVarChar;
                        Param.Size = 50;
                        Param.Direction = ParameterDirection.Input;
                        Param.Value = clsCommon.ToStr(ModelCode);
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

        public static bool Delete(clsMCarModel obj)
        {
            try
            {
                using (SqlConnection Conn = new SqlConnection(clsConst.SysDBConnString))
                {
                    Conn.Open();
                    using (SqlCommand command = new SqlCommand("Nsp_MCarModel_Delete", Conn))
                    {
                        SqlParameter Param = new SqlParameter();
                        command.CommandType = CommandType.StoredProcedure;
                        Param = new SqlParameter();
                        Param.ParameterName = "@ModelCode";
                        Param.SqlDbType = SqlDbType.NVarChar;
                        Param.Size = 50;
                        Param.Direction = ParameterDirection.Input;
                        Param.Value = clsCommon.ToStr(obj.ModelCode);
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

        public static bool Insert(clsMCarModel obj)
        {
            try
            {
                using (SqlConnection Conn = new SqlConnection(clsConst.SysDBConnString))
                {
                    Conn.Open();
                    using (SqlCommand command = new SqlCommand("Nsp_MCarModel_Insert", Conn))
                    {
                        SqlParameter Param = new SqlParameter();
                        command.CommandType = CommandType.StoredProcedure;
                        Param = new SqlParameter();
                        Param.ParameterName = "@ModelCode";
                        Param.SqlDbType = SqlDbType.NVarChar;
                        Param.Size = 50;
                        Param.Direction = ParameterDirection.Input;
                        Param.Value = clsCommon.ToStr(obj.ModelCode);
                        command.Parameters.Add(Param);

                        Param = new SqlParameter();
                        Param.ParameterName = "@ModelName";
                        Param.SqlDbType = SqlDbType.NVarChar;
                        Param.Size = 200;
                        Param.Direction = ParameterDirection.Input;
                        Param.Value = clsCommon.ToStr(obj.ModelName);
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

        public static bool Update(clsMCarModel obj)
        {
            try
            {
                using (SqlConnection Conn = new SqlConnection(clsConst.SysDBConnString))
                {
                    Conn.Open();
                    using (SqlCommand command = new SqlCommand("Nsp_MCarModel_Update", Conn))
                    {
                        SqlParameter Param = new SqlParameter();
                        command.CommandType = CommandType.StoredProcedure;
                        Param = new SqlParameter();
                        Param.ParameterName = "@ModelCode";
                        Param.SqlDbType = SqlDbType.NVarChar;
                        Param.Size = 50;
                        Param.Direction = ParameterDirection.Input;
                        Param.Value = clsCommon.ToStr(obj.ModelCode);
                        command.Parameters.Add(Param);

                        Param = new SqlParameter();
                        Param.ParameterName = "@ModelName";
                        Param.SqlDbType = SqlDbType.NVarChar;
                        Param.Size = 200;
                        Param.Direction = ParameterDirection.Input;
                        Param.Value = clsCommon.ToStr(obj.ModelName);
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

        public static string GetColumn_ModelName_ByPK(string ModelCode)
        {
            string result = "";
            try
            {
                clsMCarModel obj = new clsMCarModel();
                obj = GetDataObjByPK(ModelCode);
                if (obj != null)
                    result = obj.ModelName.Trim();
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


