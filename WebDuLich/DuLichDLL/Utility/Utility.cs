using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.Web;
using System.Data;
using System.Text.RegularExpressions;
using System.Web.Security;

namespace DuLichDLL.Utility
{
    public static class Utility
    {
        #region Parameter

        public static int pageSizeDefault = 10;
        public static string DEsep = "."; // Decimal Point Seperator
        public static string THsep = ","; // Thousand Seperator
        public static string[] ViewOnly = { "View", "Report", "false", "" };
        public static string[] Partialy = { "Insert", "Update", "Replicate", "Inactivate", "Activate", "Add", "Edit" };
        public static string[] Fully = { "Delete" };
        public static string connect = string.Empty;
        public static long UserID = 1;
        

        #endregion Parameter

        #region Convert Code To Text

        // Convert: "Success_CreateOrganization" -> "Success Create Organization"
        public static string ConvertCodeToText(string code)
        {
            try
            {
                string temp = String.Empty;
                if (!string.IsNullOrEmpty(code))
                {
                    code = code.Replace("LBL_", "").Replace("BLM_SUC_", "Success").Replace("BLM_ERR_", "Error").Replace("GUI_VAL_", "").Replace("GUI_CFM_", "");

                    // Replace UpperCase "A" to " A"
                    temp = Regex.Replace(code, @"([A-Z])", " $1");
                    //Replace "_" to " "
                    //Replace "  " to " "
                    //Then TRIM()
                    temp = temp.Replace("_", " ").Replace("  ", " ").Trim();
                    return temp;
                }
                return String.Empty;
            }
            catch
            {
                return code;
            }
        }

        private static readonly string[] VietnameseSigns = new string[]
        {
            "aAeEoOuUiIdDyY",
            "áàạảãâấầậẩẫăắằặẳẵ",
            "ÁÀẠẢÃÂẤẦẬẨẪĂẮẰẶẲẴ",
            "éèẹẻẽêếềệểễ",
            "ÉÈẸẺẼÊẾỀỆỂỄ",
            "óòọỏõôốồộổỗơớờợởỡ",
            "ÓÒỌỎÕÔỐỒỘỔỖƠỚỜỢỞỠ",
            "úùụủũưứừựửữ",
            "ÚÙỤỦŨƯỨỪỰỬỮ",
            "íìịỉĩ",
            "ÍÌỊỈĨ",
            "đ",
            "Đ",
            "ýỳỵỷỹ",
            "ÝỲỴỶỸ"
        };

        public static string RemoveSign4VietnameseString(string str)
        {
            try
            {
                //RemoveSign4VietnameseString
                for (int i = 1; i < VietnameseSigns.Length; i++)
                {
                    for (int j = 0; j < VietnameseSigns[i].Length; j++)
                        str = str.Replace(VietnameseSigns[i][j], VietnameseSigns[0][i - 1]);
                }
                return str;
            }
            catch
            {
                return str;
            }
        }

        #endregion Convert Code To Text

        public static decimal MultiplyDecimal(decimal? a, decimal? b)
        {
            if (a.HasValue && b.HasValue)
                return Math.Round(a.Value * b.Value, 2);
            else
                return 0;
        }

        #region Int and Bool Convert

        public static bool IntToBool(int? temp)
        {
            if (temp == null)
                return false;
            else
            {
                if (temp.Value == 1)
                    return true;
                else
                    return false;
            }
        }

        public static int BoolToInt(bool data)
        {
            return data == true ? 1 : 0;
        }

        #endregion Int and Bool Convert

        #region String Convert

        public static decimal StringToDecimal(string str)
        {
            decimal de = 0;
            if (!string.IsNullOrEmpty(str))
            {
                if (decimal.TryParse(str, out de))
                    return de;
                else
                    return 0;
            }
            else
            {
                return 0;
            }
        }

        public static int? StringToIntN(string str)
        {
            int de = 0;
            if (!string.IsNullOrEmpty(str))
            {
                if (int.TryParse(str, out de))
                    return de;
                else
                    return 0;
            }
            else
            {
                return null;
            }
        }

        public static int StringToInt(string str)
        {
            int temp = 0;
            if (!int.TryParse(str, out temp) || string.IsNullOrEmpty(str))
                temp = 0;
            return temp;
        }

        public static bool StringToBool(string str)
        {
            bool temp = false;
            if (!bool.TryParse(str.ToLower(), out temp) || string.IsNullOrEmpty(str))
                temp = false;
            return temp;
        }

        public static DateTime? StringToDateTime(string str)
        {
            DateTime dt = new DateTime();
            if (DateTime.TryParse(str, out dt))
                return dt;
            return null;
        }

        public static string FormatSpecialChar(string Str)
        {
            Str = Str.Replace("\\", "\\\\");
            Str = Str.Replace("'", "\\'");
            Str = Str.Replace(@"""", "&quot;");
            return Str;
        }

        public static string FormatSQLSpecial(string Str)
        {
            Str = Str.Trim();
            Str = Str.Replace("'", "''");
            Str = Str.Replace("--", "");
            return Str;
        }

        public static string ConvertToString(int[] ID)
        {
            try
            {
                if (ID == null)
                    return "0";
                else
                {
                    string result = String.Empty;
                    for (int i = 0; i < ID.Length; i++)
                    {
                        if (i < ID.Length - 1)
                            result = result + ID[i].ToString() + ",";
                        else
                            result = result + ID[i].ToString();
                    }
                    return result;
                }
            }
            catch
            {
                throw;
            }
        }

        public static string ConvertToString(List<int> ID)
        {
            try
            {
                if (ID.Count == 0)
                    return "0";
                else
                {
                    string result = String.Empty;
                    foreach (int i in ID)
                    {
                        result = result + i.ToString() + ",";
                    }
                    result = result.Remove(result.Length - 1);
                    return result;
                }
            }
            catch
            {
                throw;
            }
        }

        #endregion String Convert

        #region Date Convert

        public static string DateFormat(DateTime? date, string format)
        {
            if (date != null)
            {
                return String.Format("{0:" + format + "}", date);
            }
            return "";
        }

        public static string DateFormat(DateTime date, string format)
        {
            if (date != null && date.Year != 1)
            {
                return String.Format("{0:" + format + "}", date);
            }
            return "";
        }

        public static string DateFormatWithDay(DateTime date)
        {
            if (date != null && date.Year != 1)
            {
                string format = HttpContext.Current.Session["DateTimeFormat"].ToString();
                return String.Format("{0: dddd, " + format + "}", date);
            }
            return "";
        }

        public static string DateFullFormat(DateTime? date)
        {
            if (date.HasValue)
            {
                string dateFormat = HttpContext.Current.Session["DateTimeFormat"].ToString();
                string strDate = String.Format("{0:" + dateFormat + "}", date);

                string timeFormat = HttpContext.Current.Session["TimeFormat"].ToString();
                string strTime = String.Format("{0:" + timeFormat + "}", date);

                return strDate + " " + strTime;
            }
            return String.Empty;
        }

        public static string DateFormat(string date)
        {
            if (!string.IsNullOrEmpty(date))
            {
                string format = HttpContext.Current.Session["DateTimeFormat"].ToString();
                DateTime temp;
                temp = DateTime.ParseExact(date, format, System.Globalization.CultureInfo.CurrentCulture);
                return String.Format("{0:" + format + "}", temp);
            }
            return "";
        }

        public static string DateReFormat(string date)
        {
            if (!string.IsNullOrEmpty(date))
            {
                string format = HttpContext.Current.Session["DateTimeFormat"].ToString();
                DateTime temp;
                temp = DateTime.Parse(date);
                return String.Format("{0:" + format + "}", temp);
            }
            return "";
        }

        public static string DateFormat(string date, int dateAdd)
        {
            if (!string.IsNullOrEmpty(date))
            {
                string format = HttpContext.Current.Session["DateTimeFormat"].ToString();
                DateTime temp;
                temp = DateTime.ParseExact(date, format, System.Globalization.CultureInfo.CurrentCulture);
                temp = temp.AddDays(dateAdd);
                return String.Format("{0:" + format + "}", temp);
            }
            return "";
        }

        public static DateTime FirstDayOfMonth(this DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, 1);
        }

        public static DateTime LastDayOfMonth(this DateTime dateTime)
        {
            DateTime firstDayOfTheMonth = new DateTime(dateTime.Year, dateTime.Month, 1);
            return firstDayOfTheMonth.AddMonths(1).AddDays(-1);
        }

        public static DateTime StartOfWeek(this DateTime dt, DayOfWeek startOfWeek)
        {
            try
            {
                //--------Calculation Description
                //dt = Today = WesnesDay, 2011/01/19
                //StartOfWeek = DayOfWeek.Sunday
                //diff = WesnesDay - Sunday = 4
                //-> StartOfWeek = WesnesDay.AddDays(-diff) = Sunday, 2011/01/16

                int diff = dt.DayOfWeek - startOfWeek;
                if (diff < 0)
                {
                    diff += 7;
                }

                return dt.AddDays(-diff);
            }
            catch (Exception ex)
            {
                //Log here
                throw ex;
            }
        }

        public static DateTime EndOfWeek(this DateTime dt, DayOfWeek endOfWeek)
        {
            try
            {
                //--------Calculation Description
                //dt = Today = WesnesDay, 2011/01/19
                //EndOfWeek = DayOfWeek.Saturday
                //diff = Saturday - WesnesDay = 3
                //-> EndOfWeek = WesnesDay.AddDays(diff) = Saturday, 2011/01/22

                int diff = endOfWeek - dt.DayOfWeek;
                if (diff < 0)
                {
                    diff += 7;
                }

                return dt.AddDays(diff);
            }
            catch (Exception ex)
            {
                //Log here
                throw ex;
            }
        }

        public static DateTime VerifyDate(int year, int month, int day)
        {
            int days = DateTime.DaysInMonth(year, month);
            if (day > days)
                return new DateTime(year, month, days);

            return new DateTime(year, month, day);
        }

        #endregion Date Convert

        #region Object Convert

        public static int? ObjectToNInt(object o)
        {
            if (o == null)
                return null;
            int temp = 0;
            if (int.TryParse(o.ToString(), out temp))
                return temp;

            return null;
        }

        public static int ObjectToInt(object o)
        {
            if (o == null)
                return 0;
            int temp = 0;
            if (int.TryParse(o.ToString(), out temp))
                return temp;

            return 0;
        }

        public static bool ObjectToBool(object o)
        {
            if (o == null)
                return false;
            bool temp = false;
            if (bool.TryParse(o.ToString(), out temp))
                return temp;

            return false;
        }

        public static decimal ObjectToDecimal(object o)
        {
            try
            {
                if (o == null)
                    return 0;
                decimal de = 0;
                if (decimal.TryParse(o.ToString(), out de))
                    return de;

                return 0;
            }
            catch
            {
                throw;
            }
        }

        public static decimal? ObjectToDecimalN(object o)
        {
            try
            {
                if (o == null)
                    return null;
                decimal de = 0;
                if (decimal.TryParse(o.ToString(), out de))
                    return de;

                return null;
            }
            catch
            {
                throw;
            }
        }

        public static DateTime ObjectToDateTime(object o)
        {
            try
            {
                if (o == null)
                    return new DateTime();
                DateTime dt = new DateTime();
                if (DateTime.TryParse(o.ToString(), out dt))
                    return dt;
                return new DateTime();
            }
            catch
            {
                throw;
            }
        }

        public static DateTime? ObjectToNDateTime(object o)
        {
            try
            {
                if (o == null)
                    return null;
                DateTime dt = new DateTime();
                if (DateTime.TryParse(o.ToString(), out dt))
                    return dt;
                return null;
            }
            catch
            {
                throw;
            }
        }

        public static string ObjectToString(object o)
        {
            try
            {
                if (o == null)
                    return String.Empty;
                return o.ToString();
            }
            catch
            {
                throw;
            }
        }

        public static long? ObjectToNLong(object o)
        {
            if (o == null)
                return null;
            long temp = 0;
            if (long.TryParse(o.ToString(), out temp))
                return temp;

            return null;
        }

        public static long ObjectToLong(object o)
        {
            if (o == null)
                return 0;
            long temp = 0;
            if (long.TryParse(o.ToString(), out temp))
                return temp;

            return 0;
        }

        public static float ObjectToFloat(object o)
        {
            if (o == null)
                return 0;
            float temp = 0;
            if (float.TryParse(o.ToString(), out temp))
                return temp;

            return 0;
        }

        public static object ObjectToDB(object o)
        {
            if (o == null)
                return DBNull.Value;
            return o;
        }

        public static object ObjectDataRowToDB(DataRow row, string o)
        {
            if (row.Table.Columns.Contains(o))
                return row[o];
            return null;
        }


        #endregion Object Convert

        #region Validate data

        public static bool ValidateSpecialChar(string str)
        {
            if (String.IsNullOrEmpty(str))
                return true;
            Regex regex = new Regex(@"^[\w+\d+\s*'/\.-]+");
            return regex.IsMatch(str);
        }

        public static bool ValidateRangeID(int i)
        {
            if (i > 0 && i <= int.MaxValue)
                return true;
            return false;
        }

        public static bool ValidateNullData(object obj)
        {
            if (obj != null)
                return true;
            return false;
        }

        public static string ValidateNullString(string s)
        {
            if (string.IsNullOrWhiteSpace(s))
            {
                return string.Empty;
            }
            else
            {
                return s;
            }
        }

        #endregion Validate data

        #region Encrypt

        public static string StringToMD5(string s)
        {
            string temp = string.Empty;
            temp = FormsAuthentication.HashPasswordForStoringInConfigFile(s, "MD5").ToLower();
            return temp;
        }

        #endregion Encrypt

        #region Serialize

        public static string SerializeToXml(object value)
        {
            StringWriter writer = new StringWriter();
            XmlSerializer serializer = new XmlSerializer(value.GetType());
            serializer.Serialize(writer, value);
            return writer.ToString();
        }

        public static T XmlToObject<T>(string xml)
        {
            using (var xmlStream = new StringReader(xml))
            {
                var serializer = new XmlSerializer(typeof(T));
                return (T)serializer.Deserialize(XmlReader.Create(xmlStream));
            }
        }

        #endregion Serialize

        #region Clone

        public static T Clone<T>(T obj)
        {
            try
            {
                using (var ms = new MemoryStream())
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(ms, obj);
                    ms.Position = 0;

                    return (T)formatter.Deserialize(ms);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion Clone

        #region Get value by property

        public static object GetPropValue(object src, string propName)
        {
            return src.GetType().GetProperty(propName).GetValue(src, null);
        }

        #endregion Get value by property

        #region Language and Phrase
        public static Dictionary<string, Dictionary<string, string>> Dictionaries;


        public static void InsertPhrase(string phraseCode)
        {
            if (phraseCode == "" || phraseCode == String.Empty || phraseCode.Contains(" "))
                return;

            if ((!phraseCode.Contains("LBL_")) && (!phraseCode.Contains("CNT_")) && (!phraseCode.Contains("BLM_")) && (!phraseCode.Contains("GUI_VAL")) && (!phraseCode.Contains("GUI_INF")) && (!phraseCode.Contains("GUI_CFM")))
                return;

            //DataClasses1DataContext DB = new DataClasses1DataContext("Data Source=DB-1;Initial Catalog=DSC_ERP;Persist Security Info=True;User ID=dscerp;Password=db1!dscerp");
        }


        public static string Phrase(string languageCode, object phraseCode)
        {
            string phrase = Utility.ObjectToString(phraseCode);
            try
            {
                if (phraseCode == null) return String.Empty;
                if (Dictionaries == null) return String.Empty;



                languageCode = string.IsNullOrWhiteSpace(languageCode) ? "en-US" : languageCode;


               
                return Dictionaries[languageCode][phrase];//.Replace(" ", "&nbsp;");
            }
            catch
            {
                return phrase;
            }
        }


        public static string Phrase(string languageCode, string phraseCode)
        {
            try
            {
                if (phraseCode == null) return String.Empty;
                if (Dictionaries == null) return String.Empty;

                languageCode = string.IsNullOrWhiteSpace(languageCode) ? "en-US" : languageCode;


                //Utility.InsertPhrase(phraseCode);
                return Dictionaries[languageCode][phraseCode];//.Replace(" ", "&nbsp;");
            }
            catch
            {
                return phraseCode;
            }
        }


        public static string PhraseRef(string referenceGroup, string phraseCode, string languageCode)
        {
            try
            {
                if (phraseCode == null) return String.Empty;
                if (Dictionaries == null) return String.Empty;

                phraseCode = "CNT_" + referenceGroup + "_" + phraseCode;

                languageCode = string.IsNullOrWhiteSpace(languageCode) ? "en-US" : languageCode;

                Utility.InsertPhrase(phraseCode);
                return Dictionaries[languageCode][phraseCode];//.Replace(" ", "&nbsp;");
            }
            catch
            {
                return phraseCode;
            }
        }


        #endregion
    }
}
