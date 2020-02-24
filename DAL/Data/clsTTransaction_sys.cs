using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{

    public partial class clsTTransaction
    {
        private int _transactionid = 0;
        private string _transactionno = "";
        private string _refno= "";
        private int _recordid = 0;
        private int _vehicleid = 0;
        private int _userid = 0;
        private double _transactionamount = 0;
        private int _status = 0;
        private string _remarks = "";
        private string _createddate = "";
        private string _lastupdateby = "";
        private string _lastupdatedate = "";

        public int TransactionId
        {
            get
            {
                return _transactionid;
            }
            set
            {
                _transactionid = value;
            }
        }

        public string TransactionNo
        {
            get
            {
                return _transactionno;
            }
            set
            {
                _transactionno = value;
            }
        }

        public string RefNo
        {
            get
            {
                return _refno;
            }
            set
            {
                _refno = value;
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

        public int VehicleId
        {
            get
            {
                return _vehicleid;
            }
            set
            {
                _vehicleid = value;
            }
        }

        public int UserId
        {
            get
            {
                return _userid;
            }
            set
            {
                _userid = value;
            }
        }

        public double TransactionAmount
        {
            get
            {
                return _transactionamount;
            }
            set
            {
                _transactionamount = value;
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
    } // clsTTransaction

    public partial class clsTTransaction
    {
        private static string fstrPageName = "clsTTransaction";

        public static clsTTransaction DtToObj(DataRow dr)
        {
            clsTTransaction obj = new clsTTransaction();
            try
            {
                obj.TransactionId = clsCommon.ToInt(dr["TransactionId"]);
                obj.TransactionNo = clsCommon.ToStr(dr["TransactionNo"]);
                obj.RefNo = clsCommon.ToStr(dr["RefNo"]);
                obj.RecordId = clsCommon.ToInt(dr["RecordId"]);
                obj.VehicleId = clsCommon.ToInt(dr["VehicleId"]);
                obj.UserId = clsCommon.ToInt(dr["UserId"]);
                obj.TransactionAmount = clsCommon.ToDbl(dr["TransactionAmount"]);
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

        public static DataTable GetAllDataTable(int TransactionId)
        {
            DataTable result = null;

            try
            {
                result = new DataTable();

                using (SqlConnection Conn = new SqlConnection(clsConst.SysDBConnString))
                {
                    Conn.Open();
                    using (SqlCommand command = new SqlCommand("Nsp_TTransaction_SelectAll", Conn))
                    {
                        SqlParameter Param = new SqlParameter();
                        command.CommandType = CommandType.StoredProcedure;

                        Param = new SqlParameter();
                        Param.ParameterName = "@TransactionId";
                        Param.SqlDbType = SqlDbType.Int;
                        Param.Direction = ParameterDirection.Input;
                        Param.Value = clsCommon.ToInt(TransactionId);
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

        private static List<clsTTransaction> GetListByPK(int TransactionId)
        {
            List<clsTTransaction> result = new List<clsTTransaction>();
            try
            {
                DataTable dt = new DataTable();
                dt = GetDataTableByPK(TransactionId);
                if (dt.Rows.Count == 0)
                    result = null;
                else
                    for (int index = 0; index <= dt.Rows.Count - 1; index++)
                    {
                        clsTTransaction obj;
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

        public static clsTTransaction GetDataObjByPK(int TransactionId)
        {
            List<clsTTransaction> list = new List<clsTTransaction>();
            try
            {
                list = GetListByPK(TransactionId);
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

        public static DataTable GetDataTableByPK(int TransactionId)
        {
            DataTable result = null;

            try
            {
                result = new DataTable();

                using (SqlConnection Conn = new SqlConnection(clsConst.SysDBConnString))
                {
                    Conn.Open();
                    using (SqlCommand command = new SqlCommand("Nsp_TTransaction_SelectByPK", Conn))
                    {
                        SqlParameter Param = new SqlParameter();
                        command.CommandType = CommandType.StoredProcedure;

                        Param = new SqlParameter();
                        Param.ParameterName = "@TransactionId";
                        Param.SqlDbType = SqlDbType.Int;
                        Param.Direction = ParameterDirection.Input;
                        Param.Value = clsCommon.ToInt(TransactionId);
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

        public static bool Delete(clsTTransaction obj)
        {
            try
            {
                using (SqlConnection Conn = new SqlConnection(clsConst.SysDBConnString))
                {
                    Conn.Open();
                    using (SqlCommand command = new SqlCommand("Nsp_TTransaction_Delete", Conn))
                    {
                        SqlParameter Param = new SqlParameter();
                        command.CommandType = CommandType.StoredProcedure;
                        Param = new SqlParameter();
                        Param.ParameterName = "@TransactionId";
                        Param.SqlDbType = SqlDbType.Int;
                        Param.Direction = ParameterDirection.Input;
                        Param.Value = clsCommon.ToInt(obj.TransactionId);
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

        public static bool Insert(clsTTransaction obj)
        {
            try
            {
                using (SqlConnection Conn = new SqlConnection(clsConst.SysDBConnString))
                {
                    Conn.Open();
                    using (SqlCommand command = new SqlCommand("Nsp_TTransaction_Insert", Conn))
                    {
                        SqlParameter Param = new SqlParameter();
                        command.CommandType = CommandType.StoredProcedure;
                        Param = new SqlParameter();
                        Param.ParameterName = "@TransactionNo";
                        Param.SqlDbType = SqlDbType.NVarChar;
                        Param.Size = 50;
                        Param.Direction = ParameterDirection.Input;
                        Param.Value = clsCommon.ToStr(obj.TransactionNo);
                        command.Parameters.Add(Param);

                        Param = new SqlParameter();
                        Param.ParameterName = "@RecordId";
                        Param.SqlDbType = SqlDbType.Int;
                        Param.Direction = ParameterDirection.Input;
                        Param.Value = clsCommon.ToInt(obj.RecordId);
                        command.Parameters.Add(Param);

                        Param = new SqlParameter();
                        Param.ParameterName = "@VehicleId";
                        Param.SqlDbType = SqlDbType.Int;
                        Param.Direction = ParameterDirection.Input;
                        Param.Value = clsCommon.ToInt(obj.VehicleId);
                        command.Parameters.Add(Param);

                        Param = new SqlParameter();
                        Param.ParameterName = "@UserId";
                        Param.SqlDbType = SqlDbType.Int;
                        Param.Direction = ParameterDirection.Input;
                        Param.Value = clsCommon.ToInt(obj.UserId);
                        command.Parameters.Add(Param);

                        Param = new SqlParameter();
                        Param.ParameterName = "@TransactionAmount";
                        Param.SqlDbType = SqlDbType.Decimal;
                        Param.Precision = 18;
                        Param.Scale = 4;
                        Param.Direction = ParameterDirection.Input;
                        Param.Value = clsCommon.ToDbl(obj.TransactionAmount);
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

        public static bool Update(clsTTransaction obj)
        {
            try
            {
                using (SqlConnection Conn = new SqlConnection(clsConst.SysDBConnString))
                {
                    Conn.Open();
                    using (SqlCommand command = new SqlCommand("Nsp_TTransaction_Update", Conn))
                    {
                        SqlParameter Param = new SqlParameter();
                        command.CommandType = CommandType.StoredProcedure;
                        Param = new SqlParameter();
                        Param.ParameterName = "@TransactionId";
                        Param.SqlDbType = SqlDbType.Int;
                        Param.Direction = ParameterDirection.Input;
                        Param.Value = clsCommon.ToInt(obj.TransactionId);
                        command.Parameters.Add(Param);

                        Param = new SqlParameter();
                        Param.ParameterName = "@TransactionNo";
                        Param.SqlDbType = SqlDbType.NVarChar;
                        Param.Size = 50;
                        Param.Direction = ParameterDirection.Input;
                        Param.Value = clsCommon.ToStr(obj.TransactionNo);
                        command.Parameters.Add(Param);

                        Param = new SqlParameter();
                        Param.ParameterName = "@RecordId";
                        Param.SqlDbType = SqlDbType.Int;
                        Param.Direction = ParameterDirection.Input;
                        Param.Value = clsCommon.ToInt(obj.RecordId);
                        command.Parameters.Add(Param);

                        Param = new SqlParameter();
                        Param.ParameterName = "@VehicleId";
                        Param.SqlDbType = SqlDbType.Int;
                        Param.Direction = ParameterDirection.Input;
                        Param.Value = clsCommon.ToInt(obj.VehicleId);
                        command.Parameters.Add(Param);

                        Param = new SqlParameter();
                        Param.ParameterName = "@UserId";
                        Param.SqlDbType = SqlDbType.Int;
                        Param.Direction = ParameterDirection.Input;
                        Param.Value = clsCommon.ToInt(obj.UserId);
                        command.Parameters.Add(Param);

                        Param = new SqlParameter();
                        Param.ParameterName = "@TransactionAmount";
                        Param.SqlDbType = SqlDbType.Decimal;
                        Param.Precision = 18;
                        Param.Scale = 4;
                        Param.Direction = ParameterDirection.Input;
                        Param.Value = clsCommon.ToDbl(obj.TransactionAmount);
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

        public static string GetColumn_TransactionNo_ByPK(int TransactionId)
        {
            string result = "";
            try
            {
                clsTTransaction obj = new clsTTransaction();
                obj = GetDataObjByPK(TransactionId);
                if (obj != null)
                    result = obj.TransactionNo.Trim();
                obj = null;
            }
            catch (Exception ex)
            {
                clsLogger.ErrorLog(fstrPageName, ex);
            }
            return result;
        }

        public static int GetColumn_RecordId_ByPK(int TransactionId)
        {
            int result = 0;
            try
            {
                clsTTransaction obj = new clsTTransaction();
                obj = GetDataObjByPK(TransactionId);
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

        public static int GetColumn_VehicleId_ByPK(int TransactionId)
        {
            int result = 0;
            try
            {
                clsTTransaction obj = new clsTTransaction();
                obj = GetDataObjByPK(TransactionId);
                if (obj != null)
                    result = obj.VehicleId;
                obj = null;
            }
            catch (Exception ex)
            {
                clsLogger.ErrorLog(fstrPageName, ex);
            }
            return result;
        }

        public static int GetColumn_UserId_ByPK(int TransactionId)
        {
            int result = 0;
            try
            {
                clsTTransaction obj = new clsTTransaction();
                obj = GetDataObjByPK(TransactionId);
                if (obj != null)
                    result = obj.UserId;
                obj = null;
            }
            catch (Exception ex)
            {
                clsLogger.ErrorLog(fstrPageName, ex);
            }
            return result;
        }

        public static double GetColumn_TransactionAmount_ByPK(int TransactionId)
        {
            double result = 0;
            try
            {
                clsTTransaction obj = new clsTTransaction();
                obj = GetDataObjByPK(TransactionId);
                if (obj != null)
                    result = obj.TransactionAmount;
                obj = null;
            }
            catch (Exception ex)
            {
                clsLogger.ErrorLog(fstrPageName, ex);
            }
            return result;
        }

        public static int GetColumn_Status_ByPK(int TransactionId)
        {
            int result = 0;
            try
            {
                clsTTransaction obj = new clsTTransaction();
                obj = GetDataObjByPK(TransactionId);
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

        public static string GetColumn_Remarks_ByPK(int TransactionId)
        {
            string result = "";
            try
            {
                clsTTransaction obj = new clsTTransaction();
                obj = GetDataObjByPK(TransactionId);
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

        public static string GetColumn_CreatedDate_ByPK(int TransactionId)
        {
            string result = "";
            try
            {
                clsTTransaction obj = new clsTTransaction();
                obj = GetDataObjByPK(TransactionId);
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

        public static string GetColumn_LastUpdateBy_ByPK(int TransactionId)
        {
            string result = "";
            try
            {
                clsTTransaction obj = new clsTTransaction();
                obj = GetDataObjByPK(TransactionId);
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

        public static string GetColumn_LastUpdateDate_ByPK(int TransactionId)
        {
            string result = "";
            try
            {
                clsTTransaction obj = new clsTTransaction();
                obj = GetDataObjByPK(TransactionId);
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
