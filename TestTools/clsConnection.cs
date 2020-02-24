using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;  // for class Encoding
using System.IO;

namespace TestTools
{
    public class clsConnection
    {
        public static void CareEntry(string carplate, string gate)
        {
            try
            {

            string data = "{\"AppVersion\":\"1.0.10\",\"ApplicationCode\":\"APP\",\"CompanyId\":\"1\",\"Signature\":\"cac1090c91998110600541a7c0e44b21de6f11cc6de10e1c525722bdc29aba74\",\"CarPlate\":\"[CARPLATE]\", \"GateId\":\"[GATE]\",\"Timestamp\":\"2019-07-25 18:45:54\"}";
            data = data.Replace("[CARPLATE]", carplate);
            data = data.Replace("[GATE]", gate);

            var request = (HttpWebRequest)WebRequest.Create("http://vending.dgb.com.my:33880/sandbox_carparkws/API.asmx/ParkingEntry");

            var content = Encoding.ASCII.GetBytes(data);

            request.Method = "POST";
            request.ContentType = "text/plain";
            request.ContentLength = data.Length;

            using (var stream = request.GetRequestStream())
            {
                stream.Write(content, 0, data.Length);
            }

            var response = (HttpWebResponse)request.GetResponse(); 
            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd(); 
            }
            catch (Exception ex)
            { 
            }
        }
    }
}
