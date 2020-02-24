
namespace DAL
{
    public class clsConst
    {
        public static int ServiceId_Voucher = 9;


        public static int TransactionType_Normal =1;
        public static int TransactionType_Buy1Free1 = 2;
        public static int TransactionType_BuyForFree =3;
        public static int TransactionType_Mystery = 4;
        public static int TransactionType_FreeGift = 5;
        public static int TransactionType_Redeem = 6;
        public static int TransactionType_Puzzle = 7;
        public static int TransactionType_PuzzleRedeem = 8;
        //'Staging
        //public static string SysDBConnString = "data source=DESKTOP-FCQ5819\\SQLEXPRESS;initial catalog=vms;user id=sa; password=sql";

        //public static string SysDBConnString = "data source=DESKTOP-31BQ3O5\\SQLEXPRESS;initial catalog=vms;user id=sa; password=sql";
        // live
        //public static bool const_Live = true;
        //public static string SysDBConnString = "data source=DESKTOP-HOU9836\\VMS;initial catalog=vms;user id=vms; password=Nomoneynotalk88";
        // staging
        public static bool const_Live = true;
        //public static string SysDBConnString = "data source=DESKTOP-HOU9836\\VMS;initial catalog=test_vms;user id=Staging_vms; password=Nomoneynotalk88";
        //public static string SysDBConnString = "data source=vending.dgb.com.my\\VMS,33890;initial catalog=Staging_vms;user id=vms; password=Nomoneynotalk88";
        //public static string SysDBConnString = "data source=DESKTOP-HOU9836\\VMS;initial catalog=test_vms;user id=Staging_vms; password=Nomoneynotalk88";
        public static string SysDBConnString = "data source=47.254.234.86;initial catalog=carpark;user id=sa; password=Nomoneynotalk88!";

        //public static string SysDBConnString = "data source=DESKTOP-FCQ5819\\SQLEXPRESS;initial catalog=carpark;user id=sa; password=sql";   //public static bool const_Live = false;
        // Test Environment
        //public static string SysDBConnString = "data source=vending.dgb.com.my\\vms,33890;initial catalog=test_vms;user id=vms; password=Nomoneynotalk88";

        //public static string SysDBConnString = "data source=DESKTOP-HOU9836\\VMS;initial catalog=test_vms;user id=vms; password=Nomoneynotalk88";
        public static string SessionExpired = "logout.aspx";
        public const double constTrx_MinAmount = 0.0;
        public const double constTrx_MaxAmount = 99999999999.99; 
        public const string constDate_DateFmt = "yyyy-MM-dd";
        public const string constDate_DateCulture = "en-CA";
        public const string constDate_DateTimeFmt = "yyyy-MM-dd HH:mm:ss";
        public static string const_DateTime_Format_001 = "yyyy-MM-dd hh:mm:ss";
        public const string constDate_DateTimeFmt_Agent = "MM/dd/yyyy HH:mm:ss tt";
        public const string constDate_SQLDateFmt = "yyyy-MM-dd HH:mm:ss";
        public const string constDate_MinDate = "1900-01-01";
        public const string constDate_MaxDate = "9999-12-31";

        public const int const_Terminal_log_Request = 1;
        public const int const_Terminal_log_Response = 2;

        public const string const_Content_Type_Text = "application/text";

        public const int constPassword_MinLength = 6;
        public const string constSystemDefault_Language = "System";
        public const string constSessionID_LanguageCode = "languagecode";
        public const int constSQLCommandTimeout = 6000000;
        public const string constEmpty_GUID = "00000000-0000-0000-0000-000000000000";

        #region FunctionCode
        public const string const_FunctionCode_LoadStock = "1000";
        public const string const_FunctionCode_VerifyVoucher = "2000";
        public const string const_FunctionCode_RequestCycle = "4000";
        public const string const_FunctionCode_Inquiry = "4001";
        public const string const_FunctionCode_Restock = "4002";
        public const string const_FunctionCode_Delivery = "4003";
        public const string const_FunctionCode_ReloadProduct = "4004";
        public const string const_FunctionCode_Reboot= "4005";
        public const string const_FunctionCode_UpdateApp = "4006";
        public const string const_FunctionCode_ResultFeedback = "5000";
        #endregion

        public const int const_Transaction_Closed = 1;

        public const int const_SelectAll = -1;

        #region "Status" 
        public const int const_Status_Active = 1;
        public const int const_Status_Successful = 1;
        public const int const_Status_Pending = 2;
        public const int const_Status_InProgress = 3;
        public const int const_Status_Refund = 7;
        public const int const_Status_Suspense = 4;
        public const int const_Status_Fail = 5;
        public const int const_Status_Rejected = 6;
        public const int const_Status_Error = 9;
        #endregion

        #region "Available Status"
        public const int const_Available_Active = 1;
        public const int const_Available_Busy = 2;
        public const int const_Available_Error = 9;
        #endregion

        #region "Response Code"
        public const string const_ResponseCode_Successful = "00";
        public const string const_ResponseCode_Posted = "01";
        public const string const_ResponseCode_API_Duplicate_Transaction = "11";
        public const string const_ResponseCode_API_SignatureVerification_Fail = "10";
        public const string const_ResponseCode_GenerateCode_Error = "97";
        public const string const_ResponseCode_Invalid_Application_Data = "98";
        public const string const_ResponseCode_SystemError = "99";
        public const string const_Response_Code_API_Application_No_Found = "001001";
        public const string const_Response_Code_API_SignatureVerification_Fail = "001002";

        public const string const_Response_Code_Username_Not_Found = "000001";
        public const string const_Response_Code_Password_Invalid = "000002";
        public const string const_Response_Code_Passcode_Invalid = "000003";
        public const string const_Response_Code_Service_Not_Found = "000004";
        public const string const_Response_Code_Invalid_Wallet_Code= "000005";
        public const string const_Response_Code_Invalid_Merchant = "000006";
        public const string const_Response_Code_Invalid_Machine = "000007";
        public const string const_Response_Code_Invalid_BatchNo= "000008";


        public const string const_ResponseCode_Transaction_Fail_To_Connect = "500";
        public const string const_ResponseCode_Transaction_Incorrect_Signature = "501";
        public const string const_ResponseCode_Transaction_Request_Timed_Out = "502";
        public const string const_ResponseCode_Transaction_Mis_match_Incoming_Parameters = "503";
        public const string const_ResponseCode_Transaction_Account_Not_Found = "504";
        public const string const_ResponseCode_Transaction_Branch_Not_Found = "505";
        public const string const_ResponseCode_Transaction_Not_Found = "506";
        public const string const_ResponseCode_Transaction_QR_Not_Found = "507";
        public const string const_ResponseCode_Transaction_Cancel = "508";
        public const string const_ResponseCode_Transaction_Waiting= "509";
        public const string const_ResponseCode_Transaction_Void_Within24= "510";
        public const string const_ResponseCode_Transaction_Void_Fail = "511";

       
        #endregion

        #region "Key Field"

        public const string const_Key_Field_ResponseCode = "ResponseCode";
        #endregion


        #region "MessageType"
        public const int const_MessageType_Transaction_Request = 1;
        public const int const_MessageType_Transaction_Response = 2;
        public const int const_MessageType_Cancellation_Request = 3;
        public const int const_MessageType_Cancellation_Response = 4;

        #endregion

    }
}
