

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{

    public partial class clsTGateWay
    {
        private int _gateid = 0;
        private string _gatecode = "";
        private string _gatename = "";
        private string _location = "";
        private string _machineno = "";
        private int _typeid = 0;
        private int _status = 0;
        private string _remarks = "";
        private string _createddate = "";
        private string _lastupdateby = "";
        private string _lastupdatedate = "";

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

        public string GateCode
        {
            get
            {
                return _gatecode;
            }
            set
            {
                _gatecode = value;
            }
        }

        public string GateName
        {
            get
            {
                return _gatename;
            }
            set
            {
                _gatename = value;
            }
        }

        public string Location
        {
            get
            {
                return _location;
            }
            set
            {
                _location = value;
            }
        }

        public string MachineNo
        {
            get
            {
                return _machineno;
            }
            set
            {
                _machineno = value;
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

        public int Status
        {
            get
            {
                return _status;
            }
            set
            {
                _status = value;
            }
        }

        public string Remarks
        {
            get
            {
                return _remarks;
            }
            set
            {
                _remarks = value;
            }
        }

        public string CreatedDate
        {
            get
            {
                return _createddate;
            }
            set
            {
                _createddate = value;
            }
        }

        public string LastUpdateBy
        {
            get
            {
                return _lastupdateby;
            }
            set
            {
                _lastupdateby = value;
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
    } // clsTGateWay

    public partial class clsTGateWay
    {
        private static string fstrPageName = "clsTGateWay";

        public static clsTGateWay DtToObj(DataRow dr)
        {
            clsTGateWay obj = new clsTGateWay();
            try
            {
                obj.GateId = clsCommon.ToInt(dr["GateId"]);
                obj.GateCode = clsCommon.ToStr(dr["GateCode"]);
                obj.GateName = clsCommon.ToStr(dr["GateName"]);
                obj.Location = clsCommon.ToStr(dr["Location"]);
                obj.MachineNo = clsCommon.ToStr(dr["MachineNo"]);
                obj.TypeId = clsCommon.ToInt(dr["TypeId"]);
                obj.Status = clsCommon.ToInt(dr["Status"]);
                obj.Remarks = clsCommon.ToStr(dr["Remarks"]);
                obj.CreatedDate = clsCommon.ToDateTime(dr["CreatedDate"]).ToString("yyyy-MM-dd HH:mm:ss");
                obj.LastUpdateBy = clsCommon.ToStr(dr["LastUpdateBy"]);
                obj.LastUpdateDate = clsCommon.ToDateTime(dr["LastUpdateDate"]).ToString("yyyy-MM-dd HH:mm:ss");
            }
            catch (Exception ex)
            {
                clsLogger.ErrorLog(fstrPageName, ex);
            }
            return obj;
        }

        public static DataTable GetAllDataTable(int GateId)
        {
            DataTable result = null;

            try
            {
                result = new DataTable();

                using (SqlConnection Conn = new SqlConnection(clsConst.SysDBConnString))
                {
                    Conn.Open();
                    using (SqlCommand command = new SqlCommand("Nsp_TGateWay_SelectAll", Conn))
                    {
                        SqlParameter Param = new SqlParameter();
                        command.CommandType = CommandType.StoredProcedure;

                        Param = new SqlParameter();
                        Param.ParameterName = "@GateId";
                        Param.SqlDbType = SqlDbType.Int;
                        Param.Direction = ParameterDirection.Input;
                        Param.Value = clsCommon.ToInt(GateId);
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

        private static List<clsTGateWay> GetListByPK(int GateId)
        {
            List<clsTGateWay> result = new List<clsTGateWay>();
            try
            {
                DataTable dt = new DataTable();
                dt = GetDataTableByPK(GateId);
                if (dt.Rows.Count == 0)
                    result = null;
                else
                    for (int index = 0; index <= dt.Rows.Count - 1; index++)
                    {
                        clsTGateWay obj;
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

        public static clsTGateWay GetDataObjByPK(int GateId)
        {
            List<clsTGateWay> list = new List<clsTGateWay>();
            try
            {
                list = GetListByPK(GateId);
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

        public static DataTable GetDataTableByPK(int GateId)
        {
            DataTable result = null;

            try
            {
                result = new DataTable();

                using (SqlConnection Conn = new SqlConnection(clsConst.SysDBConnString))
                {
                    Conn.Open();
                    using (SqlCommand command = new SqlCommand("Nsp_TGateWay_SelectByPK", Conn))
                    {
                        SqlParameter Param = new SqlParameter();
                        command.CommandType = CommandType.StoredProcedure;

                        Param = new SqlParameter();
                        Param.ParameterName = "@GateId";
                        Param.SqlDbType = SqlDbType.Int;
                        Param.Direction = ParameterDirection.Input;
                        Param.Value = clsCommon.ToInt(GateId);
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

        public static bool Delete(clsTGateWay obj)
        {
            try
            {
                using (SqlConnection Conn = new SqlConnection(clsConst.SysDBConnString))
                {
                    Conn.Open();
                    using (SqlCommand command = new SqlCommand("Nsp_TGateWay_Delete", Conn))
                    {
                        SqlParameter Param = new SqlParameter();
                        command.CommandType = CommandType.StoredProcedure;
                        Param = new SqlParameter();
                        Param.ParameterName = "@GateId";
                        Param.SqlDbType = SqlDbType.Int;
                        Param.Direction = ParameterDirection.Input;
                        Param.Value = clsCommon.ToInt(obj.GateId);
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

        public static bool Insert(clsTGateWay obj)
        {
            try
            {
                using (SqlConnection Conn = new SqlConnection(clsConst.SysDBConnString))
                {
                    Conn.Open();
                    using (SqlCommand command = new SqlCommand("Nsp_TGateWay_Insert", Conn))
                    {
                        SqlParameter Param = new SqlParameter();
                        command.CommandType = CommandType.StoredProcedure;
                        Param = new SqlParameter();
                        Param.ParameterName = "@GateCode";
                        Param.SqlDbType = SqlDbType.NVarChar;
                        Param.Size = 50;
                        Param.Direction = ParameterDirection.Input;
                        Param.Value = clsCommon.ToStr(obj.GateCode);
                        command.Parameters.Add(Param);

                        Param = new SqlParameter();
                        Param.ParameterName = "@GateName";
                        Param.SqlDbType = SqlDbType.NVarChar;
                        Param.Size = 50;
                        Param.Direction = ParameterDirection.Input;
                        Param.Value = clsCommon.ToStr(obj.GateName);
                        command.Parameters.Add(Param);

                        Param = new SqlParameter();
                        Param.ParameterName = "@Location";
                        Param.SqlDbType = SqlDbType.NVarChar;
                        Param.Size = 50;
                        Param.Direction = ParameterDirection.Input;
                        Param.Value = clsCommon.ToStr(obj.Location);
                        command.Parameters.Add(Param);

                        Param = new SqlParameter();
                        Param.ParameterName = "@MachineNo";
                        Param.SqlDbType = SqlDbType.NVarChar;
                        Param.Size = 50;
                        Param.Direction = ParameterDirection.Input;
                        Param.Value = clsCommon.ToStr(obj.MachineNo);
                        command.Parameters.Add(Param);

                        Param = new SqlParameter();
                        Param.ParameterName = "@TypeId";
                        Param.SqlDbType = SqlDbType.Int;
                        Param.Direction = ParameterDirection.Input;
                        Param.Value = clsCommon.ToInt(obj.TypeId);
                        command.Parameters.Add(Param);

                        Param = new SqlParameter();
                        Param.ParameterName = "@Status";
                        Param.SqlDbType = SqlDbType.Int;
                        Param.Direction = ParameterDirection.Input;
                        Param.Value = clsCommon.ToInt(obj.Status);
                        command.Parameters.Add(Param);

                        Param = new SqlParameter();
                        Param.ParameterName = "@Remarks";
                        Param.SqlDbType = SqlDbType.NVarChar;
                        Param.Size = 50;
                        Param.Direction = ParameterDirection.Input;
                        Param.Value = clsCommon.ToStr(obj.Remarks);
                        command.Parameters.Add(Param);

                        Param = new SqlParameter();
                        Param.ParameterName = "@CreatedDate";
                        Param.SqlDbType = SqlDbType.NVarChar;
                        Param.Size = 50;
                        Param.Direction = ParameterDirection.Input;
                        Param.Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        command.Parameters.Add(Param);

                        Param = new SqlParameter();
                        Param.ParameterName = "@LastUpdateBy";
                        Param.SqlDbType = SqlDbType.NVarChar;
                        Param.Size = 50;
                        Param.Direction = ParameterDirection.Input;
                        Param.Value = clsCommon.ToStr(obj.LastUpdateBy);
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
                }

                return true;
            }
            catch (SqlException ex)
            {

                clsLogger.ErrorLog(fstrPageName, ex);
                return false;
            }
        }

        public static bool Update(clsTGateWay obj)
        {
            try
            {
                using (SqlConnection Conn = new SqlConnection(clsConst.SysDBConnString))
                {
                    Conn.Open();
                    using (SqlCommand command = new SqlCommand("Nsp_TGateWay_Update", Conn))
                    {
                        SqlParameter Param = new SqlParameter();
                        command.CommandType = CommandType.StoredProcedure;
                        Param = new SqlParameter();
                        Param.ParameterName = "@GateId";
                        Param.SqlDbType = SqlDbType.Int;
                        Param.Direction = ParameterDirection.Input;
                        Param.Value = clsCommon.ToInt(obj.GateId);
                        command.Parameters.Add(Param);

                        Param = new SqlParameter();
                        Param.ParameterName = "@GateCode";
                        Param.SqlDbType = SqlDbType.NVarChar;
                        Param.Size = 50;
                        Param.Direction = ParameterDirection.Input;
                        Param.Value = clsCommon.ToStr(obj.GateCode);
                        command.Parameters.Add(Param);

                        Param = new SqlParameter();
                        Param.ParameterName = "@GateName";
                        Param.SqlDbType = SqlDbType.NVarChar;
                        Param.Size = 50;
                        Param.Direction = ParameterDirection.Input;
                        Param.Value = clsCommon.ToStr(obj.GateName);
                        command.Parameters.Add(Param);

                        Param = new SqlParameter();
                        Param.ParameterName = "@Location";
                        Param.SqlDbType = SqlDbType.NVarChar;
                        Param.Size = 50;
                        Param.Direction = ParameterDirection.Input;
                        Param.Value = clsCommon.ToStr(obj.Location);
                        command.Parameters.Add(Param);

                        Param = new SqlParameter();
                        Param.ParameterName = "@MachineNo";
                        Param.SqlDbType = SqlDbType.NVarChar;
                        Param.Size = 50;
                        Param.Direction = ParameterDirection.Input;
                        Param.Value = clsCommon.ToStr(obj.MachineNo);
                        command.Parameters.Add(Param);

                        Param = new SqlParameter();
                        Param.ParameterName = "@TypeId";
                        Param.SqlDbType = SqlDbType.Int;
                        Param.Direction = ParameterDirection.Input;
                        Param.Value = clsCommon.ToInt(obj.TypeId);
                        command.Parameters.Add(Param);

                        Param = new SqlParameter();
                        Param.ParameterName = "@Status";
                        Param.SqlDbType = SqlDbType.Int;
                        Param.Direction = ParameterDirection.Input;
                        Param.Value = clsCommon.ToInt(obj.Status);
                        command.Parameters.Add(Param);

                        Param = new SqlParameter();
                        Param.ParameterName = "@Remarks";
                        Param.SqlDbType = SqlDbType.NVarChar;
                        Param.Size = 50;
                        Param.Direction = ParameterDirection.Input;
                        Param.Value = clsCommon.ToStr(obj.Remarks);
                        command.Parameters.Add(Param);

                        Param = new SqlParameter();
                        Param.ParameterName = "@CreatedDate";
                        Param.SqlDbType = SqlDbType.NVarChar;
                        Param.Size = 50;
                        Param.Direction = ParameterDirection.Input;
                        Param.Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        command.Parameters.Add(Param);

                        Param = new SqlParameter();
                        Param.ParameterName = "@LastUpdateBy";
                        Param.SqlDbType = SqlDbType.NVarChar;
                        Param.Size = 50;
                        Param.Direction = ParameterDirection.Input;
                        Param.Value = clsCommon.ToStr(obj.LastUpdateBy);
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
                }

                return true;
            }
            catch (SqlException ex)
            {

                clsLogger.ErrorLog(fstrPageName, ex);
                return false;
            }
        }

        public static string GetColumn_GateCode_ByPK(int GateId)
        {
            string result = "";
            try
            {
                clsTGateWay obj = new clsTGateWay();
                obj = GetDataObjByPK(GateId);
                if (obj != null)
                    result = obj.GateCode.Trim();
                obj = null;
            }
            catch (Exception ex)
            {
                clsLogger.ErrorLog(fstrPageName, ex);
            }
            return result;
        }

        public static string GetColumn_GateName_ByPK(int GateId)
        {
            string result = "";
            try
            {
                clsTGateWay obj = new clsTGateWay();
                obj = GetDataObjByPK(GateId);
                if (obj != null)
                    result = obj.GateName.Trim();
                obj = null;
            }
            catch (Exception ex)
            {
                clsLogger.ErrorLog(fstrPageName, ex);
            }
            return result;
        }

        public static string GetColumn_Location_ByPK(int GateId)
        {
            string result = "";
            try
            {
                clsTGateWay obj = new clsTGateWay();
                obj = GetDataObjByPK(GateId);
                if (obj != null)
                    result = obj.Location.Trim();
                obj = null;
            }
            catch (Exception ex)
            {
                clsLogger.ErrorLog(fstrPageName, ex);
            }
            return result;
        }

        public static string GetColumn_MachineNo_ByPK(int GateId)
        {
            string result = "";
            try
            {
                clsTGateWay obj = new clsTGateWay();
                obj = GetDataObjByPK(GateId);
                if (obj != null)
                    result = obj.MachineNo.Trim();
                obj = null;
            }
            catch (Exception ex)
            {
                clsLogger.ErrorLog(fstrPageName, ex);
            }
            return result;
        }

        public static int GetColumn_TypeId_ByPK(int GateId)
        {
            int result = 0;
            try
            {
                clsTGateWay obj = new clsTGateWay();
                obj = GetDataObjByPK(GateId);
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

        public static int GetColumn_Status_ByPK(int GateId)
        {
            int result = 0;
            try
            {
                clsTGateWay obj = new clsTGateWay();
                obj = GetDataObjByPK(GateId);
                if (obj != null)
                    result = obj.Status;
                obj = null;
            }
            catch (Exception ex)
            {
                clsLogger.ErrorLog(fstrPageName, ex);
            }
            return result;
        }

        public static string GetColumn_Remarks_ByPK(int GateId)
        {
            string result = "";
            try
            {
                clsTGateWay obj = new clsTGateWay();
                obj = GetDataObjByPK(GateId);
                if (obj != null)
                    result = obj.Remarks.Trim();
                obj = null;
            }
            catch (Exception ex)
            {
                clsLogger.ErrorLog(fstrPageName, ex);
            }
            return result;
        }

        public static string GetColumn_CreatedDate_ByPK(int GateId)
        {
            string result = "";
            try
            {
                clsTGateWay obj = new clsTGateWay();
                obj = GetDataObjByPK(GateId);
                if (obj != null)
                    result = obj.CreatedDate.Trim();
                obj = null;
            }
            catch (Exception ex)
            {
                clsLogger.ErrorLog(fstrPageName, ex);
            }
            return result;
        }

        public static string GetColumn_LastUpdateBy_ByPK(int GateId)
        {
            string result = "";
            try
            {
                clsTGateWay obj = new clsTGateWay();
                obj = GetDataObjByPK(GateId);
                if (obj != null)
                    result = obj.LastUpdateBy.Trim();
                obj = null;
            }
            catch (Exception ex)
            {
                clsLogger.ErrorLog(fstrPageName, ex);
            }
            return result;
        }

        public static string GetColumn_LastUpdateDate_ByPK(int GateId)
        {
            string result = "";
            try
            {
                clsTGateWay obj = new clsTGateWay();
                obj = GetDataObjByPK(GateId);
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