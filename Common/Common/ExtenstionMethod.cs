using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Common
{
    public static class ExtenstionMethod
    {
        #region DateTime
        /// <summary>
        /// Kiểm tra có phải là kiểu Datetime
        /// </summary>
        /// <param name="value">chuỗi cần kiểm tra</param>
        /// <param name="dateFormat">định dạng cần check</param>
        /// <returns></returns>
        /// vmquang 24.7.2022
        public static bool IsDateTime(this string value,string dateFormat)
        {
            return DateTime.TryParseExact(value,dateFormat,DateTimeFormatInfo.InvariantInfo,DateTimeStyles.None, out DateTime result);
        }
        /// <summary>
        /// Convert Datetime sang string.
        /// </summary>
        /// <param name="value">giá trị cần convert</param>
        /// <param name="dateFormat">định dạng cần convert, mặc định là dd/MM/YYY</param>
        /// <returns></returns>
        /// vmquang 24.7.2022
        public static string ConvertToString(this DateTime value,string dateFormat = "dd/MM/yyyy")
        {
            return value.ToString(dateFormat);
        }
        /// <summary>
        /// Thời điểm kết thúc của ngày
        /// </summary>
        /// <param name="value">giá trị cần convert</param>
        /// <returns></returns>
        /// vmquang1 24.7.2022
        public static DateTime EndOfDay(this DateTime value)
        {
            return new DateTime(value.Year, value.Month, value.Day,23,59,59,999);
        }
        /// <summary>
        /// Thời điểm bắt đầu của ngày
        /// </summary>
        /// <param name="value">giá trị cần convert</param>
        /// <returns></returns>
        /// vmquang1 24.7.2022
        public static DateTime StartOfDay(this DateTime value)
        {
            return new DateTime(value.Year, value.Month, value.Day, 0, 0, 0, 0);
        }
        /// <summary>
        /// Ngày bắt đầu của tuần
        /// </summary>
        /// <param name="value">ngày cần convert</param>
        /// <param name="startOfWeek">Ngày bắt đầu trong tuần, ngầm định thứ 2</param>
        /// <returns></returns>
        /// vmquang1 24.7.2022
        public static DateTime StartOfWeek(this DateTime value,DayOfWeek startOfWeek = DayOfWeek.Monday)
        {
            int diff = (7 + (value.DayOfWeek - startOfWeek)) % 7;
            return value.AddDays(-1*diff).Date;
        }
        /// <summary>
        /// Ngày kết thúc của tuần
        /// </summary>
        /// <param name="value">ngày cần convert</param>
        /// <param name="endOfWeek">ngày kết thúc trong tuần, ngầm định chủ nhật</param>
        /// <returns></returns>
        /// vmquang1 24.7.2022
        public static DateTime EndOfWeek(this DateTime value, DayOfWeek endOfWeek = DayOfWeek.Sunday)
        {
            int diff = (7 + (endOfWeek - value.DayOfWeek)) % 7;
            return value.AddDays(1 * diff).Date;
        }
        /// <summary>
        /// Ngày bắt đầu của tháng
        /// </summary>
        /// <param name="value">thời điểm cần lấy giá trị</param>
        /// <returns></returns>
        /// vmquang1 24.7.2022
        public static DateTime StartOfMonth(this DateTime value)
        {
            return new DateTime(value.Year, value.Month,1);
        }
        /// <summary>
        /// Ngày kết thúc của tháng.
        /// </summary>
        /// <param name="value">thời điểm cần lấy</param>
        /// <returns></returns>
        /// vmquang1 24.7.2022
        public static DateTime EndOfMonth(this DateTime value)
        {
            DateTime startOfMonth = value.StartOfMonth();
            return startOfMonth.AddMonths(1).AddDays(-1);
        }
        /// <summary>
        /// Ngày bắt đầu của năm
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        /// vmquang1 24.7.2022
        public static DateTime StartOfYear(this DateTime value)
        {
            return new DateTime(value.Year, 1, 1);
        }
        /// <summary>
        /// Ngày kết thúc của năm
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        /// vmquang1 24.7.2022
        public static DateTime EndOfYear(this DateTime value)
        {
            DateTime startOfMonth = value.StartOfYear();
            return startOfMonth.AddDays(-1);
        }
        #endregion

        #region String
        /// <summary>
        /// Convert sang Base64
        /// </summary>
        /// <param name="value">giá trị cần convert</param>
        /// <returns></returns>
        /// vmquang 24.7.2022
        public static string EncodeBase64(this string value)
        {
            if (!String.IsNullOrEmpty(value))
            {
                byte[] bytes = Encoding.UTF8.GetBytes(value);
                return Convert.ToBase64String(bytes);
            }
            return String.Empty;
        }
        /// <summary>
        /// Giải mã Base64
        /// </summary>
        /// <param name="value">nội dung cần giải mã</param>
        /// <returns></returns>
        /// vmquang1 24.7.2022
        public static string DecodeBase64(this string value)
        {
            if (!String.IsNullOrEmpty(value))
            {
                byte[] bytes = System.Convert.FromBase64String(value);
                return Encoding.UTF8.GetString(bytes);
            }
            return String.Empty;
        }
        /// <summary>
        /// Convert string sang MD5
        /// </summary>
        /// <param name="value">giá trị cần convert</param>
        /// <returns></returns>
        /// vmquang 24.7.2022
        public static string ConvertToMD5(this string value)
        {
            if (!String.IsNullOrEmpty(value))
            {
                StringBuilder hash = new StringBuilder();
                System.Security.Cryptography.MD5CryptoServiceProvider mD5CryptoServiceProvider = new System.Security.Cryptography.MD5CryptoServiceProvider();   
                byte[] bytes = mD5CryptoServiceProvider.ComputeHash(new UTF8Encoding().GetBytes(value));
                for (int i = 0; i < bytes.Length; i++)
                {
                    hash.Append(bytes[i].ToString("x2"));
                }
                return hash.ToString();
            }
            return String.Empty;
        }
        /// <summary>
        /// Kiểm tra string có phải là guid không.
        /// </summary>
        /// <param name="value">giá trị cần check</param>
        /// <returns></returns>
        /// vmquang1 24.7.2022
        public static bool IsGuidType(this string value)
        {
            return Guid.TryParse(value, out Guid result);
        }
        /// <summary>
        /// Kiểm tra có tất cả ký tự có là số
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        /// vmquang1 24.7.2022
        public static bool IsAllNumber(this string value)
        {
            if (!String.IsNullOrEmpty(value))
            {
                return value.All(char.IsNumber);
            }
            return false;
        }
        /// <summary>
        /// Kiểm tra chuỗi có ký tự đặc biệt hay không
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool HasSpecialCharacter(this string value)
        {
            Regex regex =  new Regex("[^A-Za-z0-9]");
            return regex.IsMatch(value);
        }
        #endregion

        #region List

        #endregion

        #region Dictionary
        /// <summary>
        /// Hàm thêm/update dictionary theo key.
        /// </summary>
        /// <param name="dicData">dữ liệu</param>
        /// <param name="keyName">key</param>
        /// <param name="value">value</param>
        /// vmquang1 24.7.2022
        public static void AddOrUpdateDictionary(this Dictionary<string, object> dicData, string keyName, object value)
        {
            if (!dicData.ContainsKey(keyName))
            {
                dicData.Add(keyName,value);
            }
            else
            {
                dicData[keyName] = value;
            }
        }
        #endregion

        #region Int,Double,Decimal,..
        #endregion
    }
}
