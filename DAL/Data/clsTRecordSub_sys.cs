


using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    public partial class clsTRecordSub
    {
        private int _logid = 0;
        private int _recordid = 0;
        private int _typeid = 0;
        private int _gateid = 0;
        private string _lastupdatedate = "";

        public int logid
        {
            get
            {
                return _logid;
            }
            set
            {
                _logid = value;
            }
        }

        public int RecordId
        {
            get
            {
                return _recordid;
            }
            set
            {
                _recordid = value;
            }
        }

        public int TypeId
        {
            get
            {
                return _typeid;
            }
            set
            {
                _typeid = value;
            }
        }

        public int GateId
        {
            get
            {
                return _gateid;
            }
            set
            {
                _gateid = value;
            }
        }

        public string LastUpdateDate
        {
            get
            {
                return _lastupdatedate;
            }
            set
            {
                _lastupdatedate = value;
            }
        }
    } // clsTRecordSub

    public partial class clsTRecordSub
    {
        private static string fstrPageName = "clsTRecordSub";

        public static clsTRecordSub DtToObj(DataRow dr)
        {
            clsTRecordSub obj = new clsTRecordSub();
            try
            {
                obj.logid = clsCommon.ToInt(dr["logid"]);
                obj.RecordId = clsCommon.ToInt(dr["RecordId"]);
                obj.TypeId = clsCommon.ToInt(dr["TypeId"]);
                obj.GateId = clsCommon.ToInt(dr["GateId"]);
                obj.LastUpdateDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            }
            catch (Exception ex)
            {
                clsLogger.ErrorLog(fstrPageName, ex);
            }
            return obj;
        }

        public static DataTable GetAllDataTable(int logid)
        {
            DataTable result = null;

            try
            {
                result = new DataTable();

                using (SqlConnection Conn = new SqlConnection(clsConst.SysDBConnString))
                {
                    Conn.Open();
                    using (SqlCommand command = new SqlCommand("Nsp_TRecordSub_SelectAll", Conn))
                    {
                        SqlParameter Param = new SqlParameter();
                        command.CommandType = CommandType.StoredProcedure;

                        Param = new SqlParameter();
                        Param.ParameterName = "@logid";
                        Param.SqlDbType = SqlDbType.Int;
                        Param.Direction = ParameterDirection.Input;
                        Param.Value = clsCommon.ToInt(logid);
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

        private static List<clsTRecordSub> GetListByPK(int logid)
        {
            List<clsTRecordSub> result = new List<clsTRecordSub>();
            try
            {
                DataTable dt = new DataTable();
                dt = GetDataTableByPK(logid);
                if (dt.Rows.Count == 0)
                    result = null;
                else
                    for (int index = 0; index <= dt.Rows.Count - 1; index++)
                    {
                        clsTRecordSub obj;
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

        public static clsTRecordSub GetDataObjByPK(int logid)
        {
            List<clsTRecordSub> list = new List<clsTRecordSub>();
            try
            {
                list = GetListByPK(logid);
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

        public static DataTable GetDataTableByPK(int logid)
        {
            DataTable result = null;

            try
            {
                result = new DataTable();

                using (SqlConnection Conn = new SqlConnection(clsConst.SysDBConnString))
                {
                    Conn.Open();
                    using (SqlCommand command = new SqlCommand("Nsp_TRecordSub_SelectByPK", Conn))
                    {
                        SqlParameter Param = new SqlParameter();
                        command.CommandType = CommandType.StoredProcedure;

                        Param = new SqlParameter();
                        Param.ParameterName = "@logid";
                        Param.SqlDbType = SqlDbType.Int;
                        Param.Direction = ParameterDirection.Input;
                        Param.Value = clsCommon.ToInt(logid);
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

        public static bool Delete(clsTRecordSub obj)
        {
            try
            {
                using (SqlConnection Conn = new SqlConnection(clsConst.SysDBConnString))
                {
                    Conn.Open();
                    using (SqlCommand command = new SqlCommand("Nsp_TRecordSub_Delete", Conn))
                    {
                        SqlParameter Param = new SqlParameter();
                        command.CommandType = CommandType.StoredProcedure;
                        Param = new SqlParameter();
                        Param.ParameterName = "@logid";
                        Param.SqlDbType = SqlDbType.Int;
                        Param.Direction = ParameterDirection.Input;
                        Param.Value = clsCommon.ToInt(obj.logid);
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

        public static bool Insert(clsTRecordSub obj)
        {
            try
            {
                using (SqlConnection Conn = new SqlConnection(clsConst.SysDBConnString))
                {
                    Conn.Open();
                    using (SqlCommand command = new SqlCommand("Nsp_TRecordSub_Insert", Conn))
                    {
                        SqlParameter Param = new SqlParameter();
                        command.CommandType = CommandType.StoredProcedure;
                        Param = new SqlParameter();
                        Param.ParameterName = "@RecordId";
                        Param.SqlDbType = SqlDbType.Int;
                        Param.Direction = ParameterDirection.Input;
                        Param.Value = clsCommon.ToInt(obj.RecordId);
                        command.Parameters.Add(Param);

                        Param = new SqlParameter();
                        Param.ParameterName = "@TypeId";
                        Param.SqlDbType = SqlDbType.Int;
                        Param.Direction = ParameterDirection.Input;
                        Param.Value = clsCommon.ToInt(obj.TypeId);
                        command.Parameters.Add(Param);

                        Param = new SqlParameter();
                        Param.ParameterName = "@GateId";
                        Param.SqlDbType = SqlDbType.Int;
                        Param.Direction = ParameterDirection.Input;
                        Param.Value = clsCommon.ToInt(obj.GateId);
                        command.Parameters.Add(Param);

                        Param = new SqlParameter();
                        Param.ParameterName = "@LastUpdateDate";
                        Param.SqlDbType = SqlDbType.NVarChar;
                        Param.Size = 50;
                        Param.Direction = ParameterDirection.Input;
                        Param.Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
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

        public static bool Update(clsTRecordSub obj)
        {
            try
            {
                using (SqlConnection Conn = new SqlConnection(clsConst.SysDBConnString))
                {
                    Conn.Open();
                    using (SqlCommand command = new SqlCommand("Nsp_TRecordSub_Update", Conn))
                    {
                        SqlParameter Param = new SqlParameter();
                        command.CommandType = CommandType.StoredProcedure;
                        Param = new SqlParameter();
                        Param.ParameterName = "@logid";
                        Param.SqlDbType = SqlDbType.Int;
                        Param.Direction = ParameterDirection.Input;
                        Param.Value = clsCommon.ToInt(obj.logid);
                        command.Parameters.Add(Param);

                        Param = new SqlParameter();
                        Param.ParameterName = "@RecordId";
                        Param.SqlDbType = SqlDbType.Int;
                        Param.Direction = ParameterDirection.Input;
                        Param.Value = clsCommon.ToInt(obj.RecordId);
                        command.Parameters.Add(Param);

                        Param = new SqlParameter();
                        Param.ParameterName = "@TypeId";
                        Param.SqlDbType = SqlDbType.Int;
                        Param.Direction = ParameterDirection.Input;
                        Param.Value = clsCommon.ToInt(obj.TypeId);
                        command.Parameters.Add(Param);

                        Param = new SqlParameter();
                        Param.ParameterName = "@GateId";
                        Param.SqlDbType = SqlDbType.Int;
                        Param.Direction = ParameterDirection.Input;
                        Param.Value = clsCommon.ToInt(obj.GateId);
                        command.Parameters.Add(Param);

                        Param = new SqlParameter();
                        Param.ParameterName = "@LastUpdateDate";
                        Param.SqlDbType = SqlDbType.NVarChar;
                        Param.Size = 50;
                        Param.Direction = ParameterDirection.Input;
                        Param.Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
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

        public static int GetColumn_RecordId_ByPK(int logid)
        {
            int result = 0;
            try
            {
                clsTRecordSub obj = new clsTRecordSub();
                obj = GetDataObjByPK(logid);
                if (obj != null)
                    result = obj.RecordId;
                obj = null;
            }
            catch (Exception ex)
            {
                clsLogger.ErrorLog(fstrPageName, ex);
            }
            return result;
        }

        public static int GetColumn_TypeId_ByPK(int logid)
        {
            int result = 0;
            try
            {
                clsTRecordSub obj = new clsTRecordSub();
                obj = GetDataObjByPK(logid);
                if (obj != null)
                    result = obj.TypeId;
                obj = null;
            }
            catch (Exception ex)
            {
                clsLogger.ErrorLog(fstrPageName, ex);
            }
            return result;
        }

        public static int GetColumn_GateId_ByPK(int logid)
        {
            int result = 0;
            try
            {
                clsTRecordSub obj = new clsTRecordSub();
                obj = GetDataObjByPK(logid);
                if (obj != null)
                    result = obj.GateId;
                obj = null;
            }
            catch (Exception ex)
            {
                clsLogger.ErrorLog(fstrPageName, ex);
            }
            return result;
        }

        public static string GetColumn_LastUpdateDate_ByPK(int logid)
        {
            string result = "";
            try
            {
                clsTRecordSub obj = new clsTRecordSub();
                obj = GetDataObjByPK(logid);
                if (obj != null)
                    result = obj.LastUpdateDate.Trim();
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