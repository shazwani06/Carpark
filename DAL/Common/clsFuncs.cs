using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Data;
using System.IO;

namespace DAL
{
    public class clsFuncs
    {
        public static bool DataTableIsNotNothing(DataTable dt)
        {
            try
            {
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                clsLogger.ErrorLog("DataTableIsNotNothing", ex);
            }
            return false;
        }

        public static string GetUnixTimestamp()
        {
            string result = "";

            try
            {
                result = (DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0)).TotalSeconds.ToString();
                result = (result.Replace(".", "")).Substring(0, 10);
            }
            catch (Exception ex)
            {
                result = "0.000";
            }

            return result;
        }


        public static string ConvertObjToJSon(object obj)
        {
            try
            {
                string s = "";
                s = JsonConvert.SerializeObject(obj).Replace("\\", "");
                return s;
            }
            catch (Exception ex)
            {
                clsLogger.ErrorLog("ConvertobjToJSon: ", ex);
            }
            return "";
        }

        public static string GetJsonNode(string sMessage, string NodeName)
        {
            string result = "";

            try
            {
                JObject json = new JObject();
                json = JObject.Parse(sMessage);
                result = json[NodeName].ToString();
            }
            catch (Exception ex)
            {
                //logger.Error("GetJsonNode", ex)
            }
            return result;
        }

        public static string GetJsonNodeFromJobj(JObject jobj, string NodeName)
        {
            string result = "";
            try
            {
                result = jobj[NodeName].ToString();
            }
            catch (Exception ex)
            {
                clsLogger.ErrorLog("GetJsonNodeFromJobj-" + NodeName, ex);
            }
            return result;
        }
        public static JArray ConvertJSonToJObj(string Message)
        {
            try
            {
                //JObject jobj = new JObject();
                //jobj = JObject.Parse(Message);
                JArray a = JArray.Parse(Message);
                return a;
                //foreach (JObject o in a.Children<JObject>())
                //{
                //    foreach (JProperty p in o.Properties())
                //    {
                //        string name = p.Name;
                //        string value = (string)p.Value; 
                //    }
                //}
                //object obj;
                //obj = JsonConvert.DeserializeObject(Message);
                //return (JObject)JToken.FromObject(obj); 
            }
            catch (Exception ex)
            {
                clsLogger.ErrorLog("ConvertJSonToJObj", ex);
            }

            return null;
        }
        public static string ConvertDataTableToJSon(DataTable ldtResult)
        {
            try
            {
                string s = "";
                s = JsonConvert.SerializeObject(ldtResult);
                //s = JsonConvert.SerializeObject(ldtResult).Replace("\\\"", ""); 
                //s = s.Replace("\\","");
                return s;
            }
            catch (Exception ex)
            {
                clsLogger.ErrorLog("ConvertDataTableToJSon", ex);
            }
            return "";
        }

        //public static bool Get_Doc_No(string TableName, string Prefix, int Len, ref string DocNo)
        //{
        //    DocNo = "";
        //    try
        //    {
        //        string Template = "0000000000000000"; 
        //        int Value = 0;
        //        if (Get_Last_No(TableName, ref Value))
        //        {
        //            Template = Template + Value.ToString();
        //            DocNo = Prefix + Template.Substring(Template.Length - Len, Len);
        //            return true;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        clsLogger.ErrorLog("Get_Doc_No", ex);
        //    }
        //    return false;
        //}

        //public static bool Get_Last_No(string TableName, ref int Value)
        //{
        //    //Return Guid.NewGuid.ToString)(
        //    //Return clsCodeGen.GetCreditCardNumbers({"1100"}, 16, 1).First()
        //    Value = 0;

        //    try
        //    {
        //        DataTable ldtResult = default(DataTable);
        //        ldtResult = clsMLastId.Get_LastNo(TableName);
        //        if (clsFuncs.DataTableIsNotNothing(ldtResult))
        //        {
        //            Value = (clsCommon.ToInt(ldtResult.Rows[0]["LastNo"]));
        //            if (Value > 0)
        //            {
        //                return true;
        //            }
        //            else
        //            {
        //                return false;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        clsLogger.ErrorLog("Get_Last_No", ex);
        //    }
        //    return false;

        //}
        public static string ConvertDatatableToCSV(DataTable dt, string strFilePath)
        {
            try
            {
                StreamWriter sw = new StreamWriter(strFilePath, false);
                //headers  
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    sw.Write(dt.Columns[i]);
                    if (i < dt.Columns.Count - 1)
                    {
                        sw.Write(",");
                    }
                }
                sw.Write(sw.NewLine);
                foreach (DataRow dr in dt.Rows)
                {
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        if (!Convert.IsDBNull(dr[i]))
                        {
                            string value = dr[i].ToString();
                            if (value.Contains(","))
                            {
                                value = String.Format("\"{0}\"", value);
                                sw.Write(value);
                            }
                            else
                            {
                                sw.Write(dr[i].ToString());
                            }
                        }
                        if (i < dt.Columns.Count - 1)
                        {
                            sw.Write(",");
                        }
                    }
                    sw.Write(sw.NewLine);
                }
                sw.Close();

            }
            catch (Exception)
            {

                throw;
            }
            return "";
        }
    }
}
