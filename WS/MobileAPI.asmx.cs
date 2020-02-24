using DAL;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WS
{
    /// <summary>
    /// Summary description for API
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class MobileAPI : System.Web.Services.WebService
    {
        string fstrPageName = "MobileAPI";
        string Result = "";
        string ResponseCode = "";
        JObject jobj;
        string ApplicationCode = "";
        string ApplicationKey = "";
        string Signature = "";
        string MessageSignature = "";
        string Timestamp = "";
        string Messaging = "";
        string CreatedBy = "API";

        [WebMethod]
        public void Login()
        {
            Result = "";
            ResponseCode = clsConst.const_ResponseCode_SystemError;
            jobj = new JObject();
            try
            {
                using (System.IO.StreamReader SR = new System.IO.StreamReader(HttpContext.Current.Request.InputStream))
                {
                    Messaging = SR.ReadToEnd();
                }

                if (Application_System_Verification())
                {
                    DataTable ldtResult = new DataTable();
                    string Username = clsFuncs.GetJsonNode(Messaging, "Username");
                    string Password = clsFuncs.GetJsonNode(Messaging, "Password");

                    ldtResult = clsTOwner.GetDataTableByUsernamePassword(Username, Password);

                    if (clsFuncs.DataTableIsNotNothing(ldtResult) == false)
                    {
                        ResponseCode = clsConst.const_Response_Code_Username_Not_Found;
                        jobj.Add(clsConst.const_Key_Field_ResponseCode, ResponseCode);
                        Result = ConvertJsonObjectToString();
                        Context.Response.Write(Result);
                        return;
                    }
                    else
                    {
                        if (ldtResult.Rows[0]["Password"].ToString() == Password)
                        {
                            ResponseCode = clsConst.const_ResponseCode_LoginSuccessful;
                            jobj.Add("OwnerAccountCode", ldtResult.Rows[0]["OwnerAccountCode"].ToString());
                            jobj.Add("OwnerFirstName", ldtResult.Rows[0]["OwnerFirstName"].ToString());
                            jobj.Add("OwnerLastName", ldtResult.Rows[0]["OwnerLastName"].ToString());
                            jobj.Add("Status", ldtResult.Rows[0]["Status"].ToString());
                            jobj.Add("GroupType", clsMGroup.GetColumn_GroupType_ByGroupCode(Int32.Parse(ldtResult.Rows[0]["GroupCode"].ToString())));

                        }

                    }

                    ldtResult = null;
                }
            }
            catch (Exception ex)
            {
                clsLogger.ErrorLog(fstrPageName + "Login", ex);
            }

            jobj.Add(clsConst.const_Key_Field_ResponseCode, ResponseCode);

            Result = ConvertJsonObjectToString();
            Context.Response.Write(Result);
        }

        [WebMethod]
        public void SignUp()
        {
            Result = "";
            ResponseCode = clsConst.const_ResponseCode_SystemError; //99
            jobj = new JObject();

            clsTOwner obj_TOwner = new clsTOwner();
            try
            {
                using (System.IO.StreamReader SR = new System.IO.StreamReader(HttpContext.Current.Request.InputStream))
                {
                    Messaging = SR.ReadToEnd();
                }

                if (Application_System_Verification())
                {
                    DataTable ldtResult = new DataTable();
                    obj_TOwner.OwnerId = 2;
                    obj_TOwner.OwnerAccountCode = clsCodeGen.OwnerAccountCode(clsFuncs.GetJsonNode(Messaging, "GroupType"), clsFuncs.GetJsonNode(Messaging, "MobileNo"));
                    obj_TOwner.OwnerFirstName = clsFuncs.GetJsonNode(Messaging, "FirstName");
                    obj_TOwner.OwnerLastName = clsFuncs.GetJsonNode(Messaging, "LastName");
                    obj_TOwner.Gender = clsFuncs.GetJsonNode(Messaging, "Gender");
                    obj_TOwner.MobileNo = clsFuncs.GetJsonNode(Messaging, "MobileNo");
                    obj_TOwner.Email = clsFuncs.GetJsonNode(Messaging, "Email");
                    obj_TOwner.Address = clsFuncs.GetJsonNode(Messaging, "Address");//
                    obj_TOwner.Username = clsFuncs.GetJsonNode(Messaging, "Email");
                    obj_TOwner.Password = clsFuncs.GetJsonNode(Messaging, "Password");//
                    obj_TOwner.Status = 1;
                    obj_TOwner.IMEI = clsFuncs.GetJsonNode(Messaging, "IMEI");//
                    obj_TOwner.CreatedDate = clsFuncs.GetJsonNode(Messaging, "TimeStamp");
                    obj_TOwner.Signature = clsFuncs.GetJsonNode(Messaging, "Signature");
                    obj_TOwner.GroupCode = clsMGroup.GetColumn_GroupCode_ByGroupType(clsFuncs.GetJsonNode(Messaging, "GroupType"));

                    if (clsTOwner.Update(obj_TOwner))
                    {
                        ResponseCode = clsConst.const_ResponseCode_Successful;
                    }

                    ldtResult = null;
                }
            }
            catch (Exception ex)
            {
                clsLogger.ErrorLog(fstrPageName + "Login", ex);
            }

            jobj.Add(clsConst.const_Key_Field_ResponseCode, ResponseCode);
            Result = ConvertJsonObjectToString();
            Context.Response.Write(Result);
        }

        [WebMethod()]
        public void InquiryParkingFee()
        {
            clsLogger.Info("Inquiry");
            Result = "";
            ResponseCode = clsConst.const_ResponseCode_SystemError;
            jobj = new JObject();
            try
            {
                using (System.IO.StreamReader SR = new System.IO.StreamReader(HttpContext.Current.Request.InputStream))
                {
                    Messaging = SR.ReadToEnd();
                }

                if (Application_System_Verification())
                {
                    DataTable ldtResult = new DataTable();
                    //string Username = clsFuncs.GetJsonNode(Messaging, "Username");
                    //string Password = clsFuncs.GetJsonNode(Messaging, "Password");

                    //string CompanyCode = clsFuncs.GetJsonNode(Messaging, "CompanyCode"); 
                    string CarPlate = clsFuncs.GetJsonNode(Messaging, "CarPlate");
                    DataTable dt = clsTRecord.GetDataTable_By_Carplate_ForParkingHours(CarPlate, 1);


                    if (clsFuncs.DataTableIsNotNothing(dt))
                    {

                        int Hours = clsCommon.ToInt(dt.Rows[0]["H"].ToString());
                        jobj.Add("Hours", Hours);
                        jobj.Add("Amount", ParkingFee(Hours));
                        ResponseCode = clsConst.const_ResponseCode_Successful;
                        ldtResult = null;
                    }
                }
            }
            catch (Exception ex)
            {
                clsLogger.ErrorLog(fstrPageName + "InquiryParkingFee", ex);
            }

            jobj.Add(clsConst.const_Key_Field_ResponseCode, ResponseCode);
            Result = ConvertJsonObjectToString();
            Context.Response.Write(Result);
        }

        [WebMethod()]
        public void PaymentParkingFee()
        {
            Result = "";
            ResponseCode = clsConst.const_ResponseCode_SystemError;
            jobj = new JObject();
            try
            {
                using (System.IO.StreamReader SR = new System.IO.StreamReader(HttpContext.Current.Request.InputStream))
                {
                    Messaging = SR.ReadToEnd();
                }

                if (Application_System_Verification())
                {
                    DataTable ldtResult = new DataTable();
                    //string Username = clsFuncs.GetJsonNode(Messaging, "Username");
                    //string Password = clsFuncs.GetJsonNode(Messaging, "Password");

                    //string CompanyCode = clsFuncs.GetJsonNode(Messaging, "CompanyCode"); 
                    string CarPlate = clsFuncs.GetJsonNode(Messaging, "CarPlate");
                    string TransactionAmount = clsFuncs.GetJsonNode(Messaging, "TransactionAmount");
                    string RefNo = clsFuncs.GetJsonNode(Messaging, "RefNo");
                    DataTable dt = clsTRecord.GetDataTable_By_Carplate_ForParkingHours(CarPlate, 1);


                    if (clsFuncs.DataTableIsNotNothing(dt))
                    {

                        int Hours = clsCommon.ToInt(dt.Rows[0]["H"].ToString());
                        string TransactionNo = clsFuncs.GetUnixTimestamp();
                        double FeeAmount = ParkingFee(Hours);
                        if (FeeAmount == clsCommon.ToDbl(TransactionAmount))
                        {
                            clsTTransaction obj = new clsTTransaction();
                            obj.RecordId = clsCommon.ToInt(dt.Rows[0]["RecordId"]);
                            obj.LastUpdateBy = "MobileAPI";
                            obj.Remarks = "";
                            obj.Status = 1;
                            obj.TransactionAmount = FeeAmount;
                            obj.TransactionNo = TransactionNo;
                            obj.UserId = 0;
                            obj.VehicleId = 0;
                            if (clsTTransaction.Insert_Custom_Payment(obj))
                            {
                                ResponseCode = clsConst.const_ResponseCode_Successful;
                                jobj.Add("TransactionNo", TransactionNo);
                            }
                        } 
                        ldtResult = null;
                    }
                }
            }
            catch (Exception ex)
            {
                clsLogger.ErrorLog(fstrPageName + "PaymentParkingFee", ex);
            }

            jobj.Add(clsConst.const_Key_Field_ResponseCode, ResponseCode);
            Result = ConvertJsonObjectToString();
            Context.Response.Write(Result);
        }



        private double ParkingFee(int H)
        {
            try
            {
                double result = 0;
                result = H * 2;
                return result;
            }
            catch (Exception ex)
            {
                clsLogger.ErrorLog(fstrPageName + "ParkingFee", ex);

            }
            return 0;
        }

        #region Common Function
        private bool Application_System_Verification()
        {
            ResponseCode = clsConst.const_ResponseCode_SystemError;

            try
            {
                string SecretKey = "";
                clsLogger.Info(Messaging);
                return true;
                //ApplicationCode = clsFuncs.GetJsonNode(Messaging, "ApplicationCode");
                //Signature = clsFuncs.GetJsonNode(Messaging, "Signature");
                //Timestamp = clsCommon.ToDateTime(clsFuncs.GetJsonNode(Messaging, "Timestamp")).ToString(clsConst.constDate_SQLDateFmt);

                //MessageSignature = ApplicationCode + ApplicationKey + Timestamp;
                //DataTable dt = new DataTable();
                //dt = clsTApplication.GetDataTableByPK(ApplicationCode);
                //if (clsFuncs.DataTableIsNotNothing(dt))
                //{
                //    SecretKey = dt.Rows[0]["SecretKey"].ToString();
                //    if (clsSecurity.ValidateSignature(Signature, MessageSignature, SecretKey) || 1 == 1)
                //    {
                //        return true;
                //    }
                //    else
                //    {
                //        ResponseCode = clsConst.const_Response_Code_API_SignatureVerification_Fail;
                //    }
                //}
            }
            catch (Exception ex)
            {
                clsLogger.ErrorLog(fstrPageName + "Application_Verification", ex);
            }

            return false;
        }

        public string GetResponseMessageByResponseCode()
        {
            string Message = "";
            try
            {
                Message = clsMResponseCode.GetColumn_ResponseMessage_ByPK(ResponseCode);

            }
            catch (Exception ex)
            {
                clsLogger.ErrorLog(fstrPageName + "GetResponseMessageByResponseCode", ex);
            }
            return Message;
        }

        private string ConvertJsonObjectToString()
        {
            string Message = "";
            try
            {
                //jobj.Add("ResponseMessage", GetResponseMessageByResponseCode());
                Message = JsonConvert.SerializeObject(jobj);

            }
            catch (Exception ex)
            {
                clsLogger.ErrorLog(fstrPageName + "ConvertJsonObjectToString", ex);
            }

            return Message;
        }

        #endregion
    }
}
