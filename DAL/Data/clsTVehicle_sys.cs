
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{

    public partial class clsTVehicle
    {
        private int _vehicleid = 0;
        private string _carplate = "";
        private string _brandcode = "";
        private string _model = "";
        private string _colour = "";
        private int _userid = 0;
        private int _status = 0;
        private string _remarks = "";
        private string _createddate = "";
        private string _lastupdateby = "";
        private string _lastupdatedate = "";

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

        public string BrandCode
        {
            get
            {
                return _brandcode;
            }
            set
            {
                _brandcode = value;
            }
        }

        public string Model
        {
            get
            {
                return _model;
            }
            set
            {
                _model = value;
            }
        }

        public string Colour
        {
            get
            {
                return _colour;
            }
            set
            {
                _colour = value;
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
    } // clsTVehicle

    public partial class clsTVehicle
    {
        private static string fstrPageName = "clsTVehicle";

        public static clsTVehicle DtToObj(DataRow dr)
        {
            clsTVehicle obj = new clsTVehicle();
            try
            {
                obj.VehicleId = clsCommon.ToInt(dr["VehicleId"]);
                obj.CarPlate = clsCommon.ToStr(dr["CarPlate"]);
                obj.BrandCode = clsCommon.ToStr(dr["BrandCode"]);
                obj.Model = clsCommon.ToStr(dr["Model"]);
                obj.Colour = clsCommon.ToStr(dr["Colour"]);
                obj.UserId = clsCommon.ToInt(dr["UserId"]);
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

        public static DataTable GetAllDataTable(int VehicleId)
        {
            DataTable result = null;

            try
            {
                result = new DataTable();

                using (SqlConnection Conn = new SqlConnection(clsConst.SysDBConnString))
                {
                    Conn.Open();
                    using (SqlCommand command = new SqlCommand("Nsp_TVehicle_SelectAll", Conn))
                    {
                        SqlParameter Param = new SqlParameter();
                        command.CommandType = CommandType.StoredProcedure;

                        Param = new SqlParameter();
                        Param.ParameterName = "@VehicleId";
                        Param.SqlDbType = SqlDbType.Int;
                        Param.Direction = ParameterDirection.Input;
                        Param.Value = clsCommon.ToInt(VehicleId);
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

        private static List<clsTVehicle> GetListByPK(int VehicleId)
        {
            List<clsTVehicle> result = new List<clsTVehicle>();
            try
            {
                DataTable dt = new DataTable();
                dt = GetDataTableByPK(VehicleId);
                if (dt.Rows.Count == 0)
                    result = null;
                else
                    for (int index = 0; index <= dt.Rows.Count - 1; index++)
                    {
                        clsTVehicle obj;
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

        public static clsTVehicle GetDataObjByPK(int VehicleId)
        {
            List<clsTVehicle> list = new List<clsTVehicle>();
            try
            {
                list = GetListByPK(VehicleId);
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

        public static DataTable GetDataTableByPK(int VehicleId)
        {
            DataTable result = null;

            try
            {
                result = new DataTable();

                using (SqlConnection Conn = new SqlConnection(clsConst.SysDBConnString))
                {
                    Conn.Open();
                    using (SqlCommand command = new SqlCommand("Nsp_TVehicle_SelectByPK", Conn))
                    {
                        SqlParameter Param = new SqlParameter();
                        command.CommandType = CommandType.StoredProcedure;

                        Param = new SqlParameter();
                        Param.ParameterName = "@VehicleId";
                        Param.SqlDbType = SqlDbType.Int;
                        Param.Direction = ParameterDirection.Input;
                        Param.Value = clsCommon.ToInt(VehicleId);
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

        public static bool Delete(clsTVehicle obj)
        {
            try
            {
                using (SqlConnection Conn = new SqlConnection(clsConst.SysDBConnString))
                {
                    Conn.Open();
                    using (SqlCommand command = new SqlCommand("Nsp_TVehicle_Delete", Conn))
                    {
                        SqlParameter Param = new SqlParameter();
                        command.CommandType = CommandType.StoredProcedure;
                        Param = new SqlParameter();
                        Param.ParameterName = "@VehicleId";
                        Param.SqlDbType = SqlDbType.Int;
                        Param.Direction = ParameterDirection.Input;
                        Param.Value = clsCommon.ToInt(obj.VehicleId);
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

        public static bool Insert(clsTVehicle obj)
        {
            try
            {
                using (SqlConnection Conn = new SqlConnection(clsConst.SysDBConnString))
                {
                    Conn.Open();
                    using (SqlCommand command = new SqlCommand("Nsp_TVehicle_Insert", Conn))
                    {
                        SqlParameter Param = new SqlParameter();
                        command.CommandType = CommandType.StoredProcedure;
                        Param = new SqlParameter();
                        Param.ParameterName = "@CarPlate";
                        Param.SqlDbType = SqlDbType.NVarChar;
                        Param.Size = 10;
                        Param.Direction = ParameterDirection.Input;
                        Param.Value = clsCommon.ToStr(obj.CarPlate);
                        command.Parameters.Add(Param);

                        Param = new SqlParameter();
                        Param.ParameterName = "@BrandCode";
                        Param.SqlDbType = SqlDbType.NVarChar;
                        Param.Size = 50;
                        Param.Direction = ParameterDirection.Input;
                        Param.Value = clsCommon.ToStr(obj.BrandCode);
                        command.Parameters.Add(Param);

                        Param = new SqlParameter();
                        Param.ParameterName = "@Model";
                        Param.SqlDbType = SqlDbType.NVarChar;
                        Param.Size = 50;
                        Param.Direction = ParameterDirection.Input;
                        Param.Value = clsCommon.ToStr(obj.Model);
                        command.Parameters.Add(Param);

                        Param = new SqlParameter();
                        Param.ParameterName = "@Colour";
                        Param.SqlDbType = SqlDbType.NVarChar;
                        Param.Size = 50;
                        Param.Direction = ParameterDirection.Input;
                        Param.Value = clsCommon.ToStr(obj.Colour);
                        command.Parameters.Add(Param);

                        Param = new SqlParameter();
                        Param.ParameterName = "@UserId";
                        Param.SqlDbType = SqlDbType.Int;
                        Param.Direction = ParameterDirection.Input;
                        Param.Value = clsCommon.ToInt(obj.UserId);
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

        public static bool Update(clsTVehicle obj)
        {
            try
            {
                using (SqlConnection Conn = new SqlConnection(clsConst.SysDBConnString))
                {
                    Conn.Open();
                    using (SqlCommand command = new SqlCommand("Nsp_TVehicle_Update", Conn))
                    {
                        SqlParameter Param = new SqlParameter();
                        command.CommandType = CommandType.StoredProcedure;
                        Param = new SqlParameter();
                        Param.ParameterName = "@VehicleId";
                        Param.SqlDbType = SqlDbType.Int;
                        Param.Direction = ParameterDirection.Input;
                        Param.Value = clsCommon.ToInt(obj.VehicleId);
                        command.Parameters.Add(Param);

                        Param = new SqlParameter();
                        Param.ParameterName = "@CarPlate";
                        Param.SqlDbType = SqlDbType.NVarChar;
                        Param.Size = 10;
                        Param.Direction = ParameterDirection.Input;
                        Param.Value = clsCommon.ToStr(obj.CarPlate);
                        command.Parameters.Add(Param);

                        Param = new SqlParameter();
                        Param.ParameterName = "@BrandCode";
                        Param.SqlDbType = SqlDbType.NVarChar;
                        Param.Size = 50;
                        Param.Direction = ParameterDirection.Input;
                        Param.Value = clsCommon.ToStr(obj.BrandCode);
                        command.Parameters.Add(Param);

                        Param = new SqlParameter();
                        Param.ParameterName = "@Model";
                        Param.SqlDbType = SqlDbType.NVarChar;
                        Param.Size = 50;
                        Param.Direction = ParameterDirection.Input;
                        Param.Value = clsCommon.ToStr(obj.Model);
                        command.Parameters.Add(Param);

                        Param = new SqlParameter();
                        Param.ParameterName = "@Colour";
                        Param.SqlDbType = SqlDbType.NVarChar;
                        Param.Size = 50;
                        Param.Direction = ParameterDirection.Input;
                        Param.Value = clsCommon.ToStr(obj.Colour);
                        command.Parameters.Add(Param);

                        Param = new SqlParameter();
                        Param.ParameterName = "@UserId";
                        Param.SqlDbType = SqlDbType.Int;
                        Param.Direction = ParameterDirection.Input;
                        Param.Value = clsCommon.ToInt(obj.UserId);
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

        public static string GetColumn_CarPlate_ByPK(int VehicleId)
        {
            string result = "";
            try
            {
                clsTVehicle obj = new clsTVehicle();
                obj = GetDataObjByPK(VehicleId);
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

        public static string GetColumn_BrandCode_ByPK(int VehicleId)
        {
            string result = "";
            try
            {
                clsTVehicle obj = new clsTVehicle();
                obj = GetDataObjByPK(VehicleId);
                if (obj != null)
                    result = obj.BrandCode.Trim();
                obj = null;
            }
            catch (Exception ex)
            {
                clsLogger.ErrorLog(fstrPageName, ex);
            }
            return result;
        }

        public static string GetColumn_Model_ByPK(int VehicleId)
        {
            string result = "";
            try
            {
                clsTVehicle obj = new clsTVehicle();
                obj = GetDataObjByPK(VehicleId);
                if (obj != null)
                    result = obj.Model.Trim();
                obj = null;
            }
            catch (Exception ex)
            {
                clsLogger.ErrorLog(fstrPageName, ex);
            }
            return result;
        }

        public static string GetColumn_Colour_ByPK(int VehicleId)
        {
            string result = "";
            try
            {
                clsTVehicle obj = new clsTVehicle();
                obj = GetDataObjByPK(VehicleId);
                if (obj != null)
                    result = obj.Colour.Trim();
                obj = null;
            }
            catch (Exception ex)
            {
                clsLogger.ErrorLog(fstrPageName, ex);
            }
            return result;
        }

        public static int GetColumn_UserId_ByPK(int VehicleId)
        {
            int result = 0;
            try
            {
                clsTVehicle obj = new clsTVehicle();
                obj = GetDataObjByPK(VehicleId);
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

        public static int GetColumn_Status_ByPK(int VehicleId)
        {
            int result = 0;
            try
            {
                clsTVehicle obj = new clsTVehicle();
                obj = GetDataObjByPK(VehicleId);
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

        public static string GetColumn_Remarks_ByPK(int VehicleId)
        {
            string result = "";
            try
            {
                clsTVehicle obj = new clsTVehicle();
                obj = GetDataObjByPK(VehicleId);
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

        public static string GetColumn_CreatedDate_ByPK(int VehicleId)
        {
            string result = "";
            try
            {
                clsTVehicle obj = new clsTVehicle();
                obj = GetDataObjByPK(VehicleId);
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

        public static string GetColumn_LastUpdateBy_ByPK(int VehicleId)
        {
            string result = "";
            try
            {
                clsTVehicle obj = new clsTVehicle();
                obj = GetDataObjByPK(VehicleId);
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

        public static string GetColumn_LastUpdateDate_ByPK(int VehicleId)
        {
            string result = "";
            try
            {
                clsTVehicle obj = new clsTVehicle();
                obj = GetDataObjByPK(VehicleId);
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
