using System;

namespace DAL
{
    public class clsCommon
    {

        public static bool IsNotNothing(object obj)
        {
            bool result = false;

            try
            {
                if (obj == null)
                {
                    return false;
                }

                result = true;

            }
            catch (Exception ex)
            {
                return false;

            }

            return result;
        }

        public static string ToStr(object obj)
        {
            string result = "";

            try
            {
                if (obj == null)
                {
                    return "";
                }
                result = Convert.ToString(obj);
            }
            catch (Exception ex)
            {
                result = "";
            }
            return result;
        }

        public static Guid ToGUID(object obj)
        {
            Guid result = Guid.Empty;
            string tempString = obj.ToString();

            try
            {
                result = new System.Guid(tempString);
            }
            catch (Exception ex)
            {
                result = Guid.Empty;
            }
            return result;
        }
        public static double ToDbl(object obj)
        {
            double result = 0;
            try
            {
                if (obj != null)
                {
                    result = Convert.ToDouble(obj);
                }

            }
            catch (Exception ex)
            {
                return 0;
            }

            return result;
        }

        public static string ToDecimal0(object obj)
        {
            string result = null;

            try
            {
                result = String.Format(obj.ToString(), "#,##0");
            }
            catch (Exception ex)
            {
                result = "0";
            }

            return result;
        }

        public static string ToDecimal1(object obj)
        {
            string result = null;

            try
            {
                result = String.Format(obj.ToString(), "#,##0.0");
            }
            catch (Exception ex)
            {
                result = "0.0";
            }

            return result;
        }

        public static string ToDecimal2(object obj)
        {
            string result = null;

            try
            {
                result = Convert.ToDecimal(obj).ToString("n2");
            }
            catch (Exception ex)
            {
                result = "0.00";
            }

            return result;
        }

        public static string ToDecimal2S(object obj)
        {
            string result = null;

            try
            {
                result = String.Format(obj.ToString(), "#,##0.00");
                result = result.Replace(",", "");
            }
            catch (Exception ex)
            {
                result = "0.00";
            }

            return result;
        }

        public static string ToDecimal3(object obj)
        {
            string result = null;

            try
            {
                result = String.Format(obj.ToString(), "#,##0.000");
            }
            catch (Exception ex)
            {
                result = "0.000";
            }

            return result;
        }

        public static string ToDecimal4(object obj)
        {
            string result = null;

            try
            {
                result = String.Format(obj.ToString(), "#,##0.0000");
            }
            catch (Exception ex)
            {
                result = "0.0000";
            }

            return result;
        }

        public static long ToLong(object obj)
        {
            long result = 0;
            try
            {
                result = Convert.ToInt64(obj);
            }
            catch (Exception ex)
            {
                return 0;
            }

            return result;
        }
        public static int ToInt(object obj)
        {
            int result = 0;
            try
            {
                result = Convert.ToInt32(obj);
            }
            catch (Exception ex)
            {
                return 0;
            }

            return result;
        }


        public static DateTime ToDateTime( object obj)
        {
            try
            {
                return Convert.ToDateTime(obj.ToString());
            }
            catch (Exception ex)
            {
                return Convert.ToDateTime("1900-01-01");
            }

        }

        public static DateTime GetMinDateTime()
        {
            try
            {
                return Convert.ToDateTime("1900-01-01");
            }
            catch (Exception ex)
            {
                return DateTime.Now ;
            }
             
        }

    }
}
