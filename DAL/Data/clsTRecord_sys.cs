using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    public partial class clsTRecord
    {
        private int _recordid = 0;
        private int _companyid = 0;
        private string _transactionno = "";
        private string _carplate = "";
        private string _visittype = "";
        private double _chargeamount = 0;
        private int _status = 0;
        private string _remarks = "";
        private string _createddate = "";
        private string _lastupdateby = "";
        private string _lastupdatedate = "";

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

        public int CompanyId
        {
            get
            {
                return _companyid;
            }
            set
            {
                _companyid = value;
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

        public string CarPlate
        {
            get
            {
                return _carplate;
            }
            set
            {
                _carplate = value;
            }
        }

        public string VisitType
        {
            get
            {
                return _visittype;
            }
            set
            {
                _visittype = value;
            }
        }

        public double ChargeAmount
        {
            get
            {
                return _chargeamount;
            }
            set
            {
                _chargeamount = value;
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
    } // clsTRecord

    public partial class clsTRecord
    {
        private static string fstrPageName = "clsTRecord";

        public static clsTRecord DtToObj(DataRow dr)
        {
            clsTRecord obj = new clsTRecord();
            try
            {
                obj.RecordId = clsCommon.ToInt(dr["RecordId"]);
                obj.CompanyId = clsCommon.ToInt(dr["CompanyId"]);
                obj.TransactionNo = clsCommon.ToStr(dr["TransactionNo"]);
                obj.CarPlate = clsCommon.ToStr(dr["CarPlate"]);
                obj.VisitType = clsCommon.ToStr(dr["VisitType"]);
                obj.ChargeAmount = clsCommon.ToDbl(dr["ChargeAmount"]);
                obj.Status = clsCommon.ToInt(dr["Status"]);
                obj.Remarks = clsCommon.ToStr(dr["Remarks"]);
                obj.CreatedDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                obj.LastUpdateBy = clsCommon.ToStr(dr["LastUpdateBy"]);
                obj.LastUpdateDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            }
            catch (Exception ex)
            {
                clsLogger.ErrorLog(fstrPageName, ex);
            }
            return obj;
        }

        public static DataTable GetAllDataTable(int RecordId)
        {
            DataTable result = null;

            try
            {
                result = new DataTable();

                using (SqlConnection Conn = new SqlConnection(clsConst.SysDBConnString))
                {
                    Conn.Open();
                    using (SqlCommand command = new SqlCommand("Nsp_TRecord_SelectAll", Conn))
                    {
                        SqlParameter Param = new SqlParameter();
                        command.CommandType = CommandType.StoredProcedure;

                        Param = new SqlParameter();
                        Param.ParameterName = "@RecordId";
                        Param.SqlDbType = SqlDbType.Int;
                        Param.Direction = ParameterDirection.Input;
                        Param.Value = clsCommon.ToInt(RecordId);
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

        private static List<clsTRecord> GetListByPK(int RecordId)
        {
            List<clsTRecord> result = new List<clsTRecord>();
            try
            {
                DataTable dt = new DataTable();
                dt = GetDataTableByPK(RecordId);
                if (dt.Rows.Count == 0)
                    result = null;
                else
                    for (int index = 0; index <= dt.Rows.Count - 1; index++)
                    {
                        clsTRecord obj;
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

        public static clsTRecord GetDataObjByPK(int RecordId)
        {
            List<clsTRecord> list = new List<clsTRecord>();
            try
            {
                list = GetListByPK(RecordId);
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

        public static DataTable GetDataTableByPK(int RecordId)
        {
            DataTable result = null;

            try
            {
                result = new DataTable();

                using (SqlConnection Conn = new SqlConnection(clsConst.SysDBConnString))
                {
                    Conn.Open();
                    using (SqlCommand command = new SqlCommand("Nsp_TRecord_SelectByPK", Conn))
                    {
                        SqlParameter Param = new SqlParameter();
                        command.CommandType = CommandType.StoredProcedure;

                        Param = new SqlParameter();
                        Param.ParameterName = "@RecordId";
                        Param.SqlDbType = SqlDbType.Int;
                        Param.Direction = ParameterDirection.Input;
                        Param.Value = clsCommon.ToInt(RecordId);
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

        public static bool Delete(clsTRecord obj)
        {
            try
            {
                using (SqlConnection Conn = new SqlConnection(clsConst.SysDBConnString))
                {
                    Conn.Open();
                    using (SqlCommand command = new SqlCommand("Nsp_TRecord_Delete", Conn))
                    {
                        SqlParameter Param = new SqlParameter();
                        command.CommandType = CommandType.StoredProcedure;
                        Param = new SqlParameter();
                        Param.ParameterName = "@RecordId";
                        Param.SqlDbType = SqlDbType.Int;
                        Param.Direction = ParameterDirection.Input;
                        Param.Value = clsCommon.ToInt(obj.RecordId);
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

        public static bool Insert(clsTRecord obj)
        {
            try
            {
                using (SqlConnection Conn = new SqlConnection(clsConst.SysDBConnString))
                {
                    Conn.Open();
                    using (SqlCommand command = new SqlCommand("Nsp_TRecord_Insert", Conn))
                    {
                        SqlParameter Param = new SqlParameter();
                        command.CommandType = CommandType.StoredProcedure;
                        Param = new SqlParameter();
                        Param.ParameterName = "@CompanyId";
                        Param.SqlDbType = SqlDbType.Int;
                        Param.Direction = ParameterDirection.Input;
                        Param.Value = clsCommon.ToInt(obj.CompanyId);
                        command.Parameters.Add(Param);

                        Param = new SqlParameter();
                        Param.ParameterName = "@TransactionNo";
                        Param.SqlDbType = SqlDbType.NVarChar;
                        Param.Size = 200;
                        Param.Direction = ParameterDirection.Input;
                        Param.Value = clsCommon.ToStr(obj.TransactionNo);
                        command.Parameters.Add(Param);

                        Param = new SqlParameter();
                        Param.ParameterName = "@CarPlate";
                        Param.SqlDbType = SqlDbType.NVarChar;
                        Param.Size = 50;
                        Param.Direction = ParameterDirection.Input;
                        Param.Value = clsCommon.ToStr(obj.CarPlate);
                        command.Parameters.Add(Param);

                        Param = new SqlParameter();
                        Param.ParameterName = "@VisitType";
                        Param.SqlDbType = SqlDbType.NVarChar;
                        Param.Size = 50;
                        Param.Direction = ParameterDirection.Input;
                        Param.Value = clsCommon.ToStr(obj.VisitType);
                        command.Parameters.Add(Param);

                        Param = new SqlParameter();
                        Param.ParameterName = "@ChargeAmount";
                        Param.SqlDbType = SqlDbType.Decimal;
                        Param.Precision = 18;
                        Param.Scale = 4;
                        Param.Direction = ParameterDirection.Input;
                        Param.Value = clsCommon.ToDbl(obj.ChargeAmount);
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

                    return true;
                }
            }
            catch (SqlException ex)
            {

                clsLogger.ErrorLog(fstrPageName, ex);
                return false;
            }
        }

        public static bool Update(clsTRecord obj)
        {
            try
            {
                using (SqlConnection Conn = new SqlConnection(clsConst.SysDBConnString))
                {
                    Conn.Open();
                    using (SqlCommand command = new SqlCommand("Nsp_TRecord_Update", Conn))
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
                        Param.ParameterName = "@CompanyId";
                        Param.SqlDbType = SqlDbType.Int;
                        Param.Direction = ParameterDirection.Input;
                        Param.Value = clsCommon.ToInt(obj.CompanyId);
                        command.Parameters.Add(Param);

                        Param = new SqlParameter();
                        Param.ParameterName = "@TransactionNo";
                        Param.SqlDbType = SqlDbType.NVarChar;
                        Param.Size = 200;
                        Param.Direction = ParameterDirection.Input;
                        Param.Value = clsCommon.ToStr(obj.TransactionNo);
                        command.Parameters.Add(Param);

                        Param = new SqlParameter();
                        Param.ParameterName = "@CarPlate";
                        Param.SqlDbType = SqlDbType.NVarChar;
                        Param.Size = 50;
                        Param.Direction = ParameterDirection.Input;
                        Param.Value = clsCommon.ToStr(obj.CarPlate);
                        command.Parameters.Add(Param);

                        Param = new SqlParameter();
                        Param.ParameterName = "@VisitType";
                        Param.SqlDbType = SqlDbType.NVarChar;
                        Param.Size = 50;
                        Param.Direction = ParameterDirection.Input;
                        Param.Value = clsCommon.ToStr(obj.VisitType);
                        command.Parameters.Add(Param);

                        Param = new SqlParameter();
                        Param.ParameterName = "@ChargeAmount";
                        Param.SqlDbType = SqlDbType.Decimal;
                        Param.Precision = 18;
                        Param.Scale = 4;
                        Param.Direction = ParameterDirection.Input;
                        Param.Value = clsCommon.ToDbl(obj.ChargeAmount);
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

                    return true;
                }
            }
            catch (SqlException ex)
            {

                clsLogger.ErrorLog(fstrPageName, ex);
                return false;
            }
        }

        public static int GetColumn_CompanyId_ByPK(int RecordId)
        {
            int result = 0;
            try
            {
                clsTRecord obj = new clsTRecord();
                obj = GetDataObjByPK(RecordId);
                if (obj != null)
                    result = obj.CompanyId;
                obj = null;
            }
            catch (Exception ex)
            {
                clsLogger.ErrorLog(fstrPageName, ex);
            }
            return result;
        }

        public static string GetColumn_TransactionNo_ByPK(int RecordId)
        {
            string result = "";
            try
            {
                clsTRecord obj = new clsTRecord();
                obj = GetDataObjByPK(RecordId);
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

        public static string GetColumn_CarPlate_ByPK(int RecordId)
        {
            string result = "";
            try
            {
                clsTRecord obj = new clsTRecord();
                obj = GetDataObjByPK(RecordId);
                if (obj != null)
                    result = obj.CarPlate.Trim();
                obj = null;
            }
            catch (Exception ex)
            {
                clsLogger.ErrorLog(fstrPageName, ex);
            }
            return result;
        }

        public static string GetColumn_VisitType_ByPK(int RecordId)
        {
            string result = "";
            try
            {
                clsTRecord obj = new clsTRecord();
                obj = GetDataObjByPK(RecordId);
                if (obj != null)
                    result = obj.VisitType.Trim();
                obj = null;
            }
            catch (Exception ex)
            {
                clsLogger.ErrorLog(fstrPageName, ex);
            }
            return result;
        }

        public static double GetColumn_ChargeAmount_ByPK(int RecordId)
        {
            double result = 0;
            try
            {
                clsTRecord obj = new clsTRecord();
                obj = GetDataObjByPK(RecordId);
                if (obj != null)
                    result = obj.ChargeAmount;
                obj = null;
            }
            catch (Exception ex)
            {
                clsLogger.ErrorLog(fstrPageName, ex);
            }
            return result;
        }

        public static int GetColumn_Status_ByPK(int RecordId)
        {
            int result = 0;
            try
            {
                clsTRecord obj = new clsTRecord();
                obj = GetDataObjByPK(RecordId);
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

        public static string GetColumn_Remarks_ByPK(int RecordId)
        {
            string result = "";
            try
            {
                clsTRecord obj = new clsTRecord();
                obj = GetDataObjByPK(RecordId);
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

        public static string GetColumn_CreatedDate_ByPK(int RecordId)
        {
            string result = "";
            try
            {
                clsTRecord obj = new clsTRecord();
                obj = GetDataObjByPK(RecordId);
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

        public static string GetColumn_LastUpdateBy_ByPK(int RecordId)
        {
            string result = "";
            try
            {
                clsTRecord obj = new clsTRecord();
                obj = GetDataObjByPK(RecordId);
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

        public static string GetColumn_LastUpdateDate_ByPK(int RecordId)
        {
            string result = "";
            try
            {
                clsTRecord obj = new clsTRecord();
                obj = GetDataObjByPK(RecordId);
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