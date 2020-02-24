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
    public class API : System.Web.Services.WebService
    {
        string fstrPageName = "API";
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



        [WebMethod()]
        public void ParkingEntry()
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

                    string CompanyCode = clsFuncs.GetJsonNode(Messaging, "CompanyCode");
                    string GateId = clsFuncs.GetJsonNode(Messaging, "GateId");
                    string CarPlate = clsFuncs.GetJsonNode(Messaging, "CarPlate");
                    DataTable dtGate = clsTGateWay.GetDataTable_By_GateCode(GateId);


                    if (clsFuncs.DataTableIsNotNothing(dtGate))
                    {

                        string GateMachineNo = dtGate.Rows[0]["MachineNo"].ToString();
                        int GateType = clsCommon.ToInt(dtGate.Rows[0]["TypeId"].ToString());
                        clsTRecord obj = new clsTRecord();
                        obj.CarPlate = CarPlate;
                        obj.ChargeAmount = 0;
                        obj.CompanyId = 1;
                        obj.LastUpdateBy = CreatedBy;
                        obj.Remarks = "";
                        obj.Status = 2;
                        obj.TransactionNo = "";
                        obj.VisitType = "1";

                        if (GateType == 1)
                        {

                            ldtResult = clsTRecord.Insert_Custom_001(0, 1, clsFuncs.GetUnixTimestamp(), CarPlate,GateType.ToString(), CreatedBy, clsCommon.ToInt(GateMachineNo), 0);
                        }
                        else if(GateType == 2)
                        {
                            DataTable dt = clsTRecord.GetDataTable_By_ForCustomInsert(CarPlate, 1);
                            if (clsFuncs.DataTableIsNotNothing(dt))
                                ldtResult = clsTRecord.Insert_Custom_001(clsCommon.ToInt(dt.Rows[0]["RecordId"]), 1, clsFuncs.GetUnixTimestamp(), CarPlate, GateType.ToString(), CreatedBy, clsCommon.ToInt(GateId), 0);
                        }

                        if (clsFuncs.DataTableIsNotNothing(ldtResult) == false)
                        {
                            ResponseCode = clsConst.const_ResponseCode_SystemError;
                        }
                        else
                        {
                            ResponseCode = clsConst.const_ResponseCode_Successful;
                        }


                        ldtResult = null;
                    }
                }
            }
            catch (Exception ex)
            {
                clsLogger.ErrorLog(fstrPageName + "ParkingEntry", ex);
            }

            jobj.Add(clsConst.const_Key_Field_ResponseCode, ResponseCode);
            Result = ConvertJsonObjectToString();
            Context.Response.Write(Result);
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
