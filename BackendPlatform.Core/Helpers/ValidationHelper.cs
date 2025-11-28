using System.Text.RegularExpressions;

namespace BackendPlatform.Core.Helpers
{
    public static class ValidationHelper
    {
        #region 相關靜態 Regex 物件
        // 不要使用 Regex 的靜態方法, 直接建立對應的靜態物件重複使用
        private static readonly Regex _regexIsNumericOrLetter = new Regex(RegularExp.NumericOrLetter, RegexOptions.Compiled);
        private static readonly Regex _regexIsNumeric = new Regex(RegularExp.Numeric, RegexOptions.Compiled);
        //private static readonly Regex _regexIsDate = new Regex(RegularExp.Date, RegexOptions.Compiled);
        private static readonly Regex _regexIsDateTime = new Regex(RegularExp.DateTime, RegexOptions.Compiled);
        private static readonly Regex _regexIsIP = new Regex(RegularExp.IP, RegexOptions.Compiled);
        private static readonly Regex _regexSpecialCharacters = new Regex(RegularExp.SpecialCharacters, RegexOptions.Compiled);
        private static readonly Regex _regexIsNumericOrLetterOrUnderline = new Regex(RegularExp.NumericOrLetterOrUnderline, RegexOptions.Compiled);
        #endregion

        #region 目前有使用到的方法
        /// <summary>
        /// 驗證由數字和26個英文字母組成的字串
        /// </summary>
        /// <param name="input">要驗證的字串</param>
        /// <returns>驗證通過返回true</returns>
        public static bool IsNumericOrLetter(string input)
        {
            return _regexIsNumericOrLetter.IsMatch(input);
        }

        /// <summary>
        /// 驗證由數字、26個英文字母或者底線組成的字串
        /// </summary>
        /// <param name="input">要驗證的字串</param>
        /// <returns>驗證通過返回true</returns>
        public static bool IsNumericOrLetterOrUnderline(string input)
        {
            return _regexIsNumericOrLetterOrUnderline.IsMatch(input);
        }

        /// <summary>
        /// 驗證由數位組成的字串
        /// </summary>
        /// <param name="input">要驗證的字串</param>
        /// <returns>驗證通過返回true</returns>
        public static bool IsNumeric(string input)
        {
            return _regexIsNumeric.IsMatch(input);
        }

        ///// <summary>
        ///// 驗證由數位組成的字串 (ReadOnlySpan<char> 版本)
        ///// </summary>
        ///// <param name="input"></param>
        ///// <returns></returns>
        //public static bool IsNumeric(ReadOnlySpan<char> input)
        //{
        //    return int.TryParse(input, out _);
        //}

        ///// <summary>
        ///// 驗證日期（YYYY-MM-DD）
        ///// </summary>
        ///// <param name="input">要驗證的字串</param>
        ///// <returns>驗證通過返回true</returns>
        //public static bool IsDate(string input)
        //{
        //    return DateTime.TryParse(input, out _);
        //}

        /// <summary>
        /// 驗證日期和時間（YYYY-MM-DD HH:MM:SS）
        /// </summary>
        /// <param name="input">要驗證的字串</param>
        /// <returns>驗證通過返回true</returns>
        public static bool IsDateTime(string input)
        {
            return _regexIsDateTime.IsMatch(input);
        }

        ///// <summary>
        ///// 驗證日期和時間（YYYY-MM-DD HH:MM:SS.FFF）
        ///// </summary>
        ///// <param name="input">要驗證的字串</param>
        ///// <returns></returns>
        //public static bool IsDateTimeWithMS(string input)
        //{
        //    string[] parts = input.Split('.');
        //    return (parts.Length == 2 && IsDateTime(parts[0]) && parts[1].Length == 3 && IsNumeric(parts[1]));
        //}

        /// <summary>
        /// 驗證IP
        /// </summary>
        /// <param name="input">要驗證的字串</param>
        /// <returns>驗證通過返回true</returns>
        public static bool IsIP(string input)
        {
            return true;
            //return _regexIsIP.IsMatch(input);
        }

        /// <summary>
        /// 驗證特殊字元
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool ContainSpecialCharacters(string input)
        {
            return _regexSpecialCharacters.IsMatch(input);
        }
        #endregion

        #region 未使用到的方法先註解
        ///// <summary>
        ///// 判斷字串是否與指定正則運算式匹配
        ///// </summary>
        ///// <param name="input">要驗證的字串</param>
        ///// <param name="regularExp">正則運算式</param>
        ///// <returns>驗證通過返回true</returns>
        //public static bool IsMatch(string input, string regularExp)
        //{
        //    return Regex.IsMatch(input, regularExp);
        //}

        ///// <summary>
        ///// 驗證非負整數（正整數 + 0）
        ///// </summary>
        ///// <param name="input">要驗證的字串</param>
        ///// <returns>驗證通過返回true</returns>
        //public static bool IsUnMinusInt(string input)
        //{
        //    return Regex.IsMatch(input, RegularExp.UnMinusInteger);
        //}

        ///// <summary>
        ///// 驗證正整數
        ///// </summary>
        ///// <param name="input">要驗證的字串</param>
        ///// <returns>驗證通過返回true</returns>
        //public static bool IsPlusInt(string input)
        //{
        //    return Regex.IsMatch(input, RegularExp.PlusInteger);
        //}

        ///// <summary>
        ///// 驗證非正整數（負整數 + 0） 
        ///// </summary>
        ///// <param name="input">要驗證的字串</param>
        ///// <returns>驗證通過返回true</returns>
        //public static bool IsUnPlusInt(string input)
        //{
        //    return Regex.IsMatch(input, RegularExp.UnPlusInteger);
        //}

        ///// <summary>
        ///// 驗證負整數
        ///// </summary>
        ///// <param name="input">要驗證的字串</param>
        ///// <returns>驗證通過返回true</returns>
        //public static bool IsMinusInt(string input)
        //{
        //    return Regex.IsMatch(input, RegularExp.MinusInteger);
        //}

        ///// <summary>
        ///// 驗證整數
        ///// </summary>
        ///// <param name="input">要驗證的字串</param>
        ///// <returns>驗證通過返回true</returns>
        //public static bool IsInt(string input)
        //{
        //    return Regex.IsMatch(input, RegularExp.Integer);
        //}

        ///// <summary>
        ///// 驗證非負浮點數（正浮點數 + 0）
        ///// </summary>
        ///// <param name="input">要驗證的字串</param>
        ///// <returns>驗證通過返回true</returns>
        //public static bool IsUnMinusFloat(string input)
        //{
        //    return Regex.IsMatch(input, RegularExp.UnMinusFloat);
        //}

        ///// <summary>
        ///// 驗證正浮點數
        ///// </summary>
        ///// <param name="input">要驗證的字串</param>
        ///// <returns>驗證通過返回true</returns>
        //public static bool IsPlusFloat(string input)
        //{
        //    return Regex.IsMatch(input, RegularExp.PlusFloat);
        //}

        ///// <summary>
        ///// 驗證非正浮點數（負浮點數 + 0）
        ///// </summary>
        ///// <param name="input">要驗證的字串</param>
        ///// <returns>驗證通過返回true</returns>
        //public static bool IsUnPlusFloat(string input)
        //{
        //    return Regex.IsMatch(input, RegularExp.UnPlusFloat);
        //}

        ///// <summary>
        ///// 驗證負浮點數
        ///// </summary>
        ///// <param name="input">要驗證的字串</param>
        ///// <returns>驗證通過返回true</returns>
        //public static bool IsMinusFloat(string input)
        //{
        //    return Regex.IsMatch(input, RegularExp.MinusFloat);
        //}

        ///// <summary>
        ///// 驗證浮點數
        ///// </summary>
        ///// <param name="input">要驗證的字串</param>
        ///// <returns>驗證通過返回true</returns>
        //public static bool IsFloat(string input)
        //{
        //    return Regex.IsMatch(input, RegularExp.Float);
        //}

        ///// <summary>
        ///// 驗證由26個英文字母組成的字串
        ///// </summary>
        ///// <param name="input">要驗證的字串</param>
        ///// <returns>驗證通過返回true</returns>
        //public static bool IsLetter(string input)
        //{
        //    return Regex.IsMatch(input, RegularExp.Letter);
        //}

        ///// <summary>
        ///// 驗證由中文組成的字串
        ///// </summary>
        ///// <param name="input">要驗證的字串</param>
        ///// <returns>驗證通過返回true</returns>
        //public static bool IsChinese(string input)
        //{
        //    return Regex.IsMatch(input, RegularExp.Chinese);
        //}

        ///// <summary>
        ///// 驗證由26個英文字母的大寫組成的字串
        ///// </summary>
        ///// <param name="input">要驗證的字串</param>
        ///// <returns>驗證通過返回true</returns>
        //public static bool IsUpperLetter(string input)
        //{
        //    return Regex.IsMatch(input, RegularExp.UpperLetter);
        //}

        ///// <summary>
        ///// 驗證由26個英文字母的小寫組成的字串
        ///// </summary>
        ///// <param name="input">要驗證的字串</param>
        ///// <returns>驗證通過返回true</returns>
        //public static bool IsLowerLetter(string input)
        //{
        //    return Regex.IsMatch(input, RegularExp.LowerLetter);
        //}

        ///// <summary>
        ///// 驗證由數位和26個英文字母或中文組成的字串
        ///// </summary>
        ///// <param name="input">要驗證的字串</param>
        ///// <returns>驗證通過返回true</returns>
        //public static bool IsNumericOrLetterOrChinese(string input)
        //{
        //    return Regex.IsMatch(input, RegularExp.NumbericOrLetterOrChinese);
        //}

        ///// <summary>
        ///// 驗證由數位和26個英文字母或中文或底線組成的字串
        ///// </summary>
        ///// <param name="input">要驗證的字串</param>
        ///// <returns>驗證通過返回true</returns>
        //public static bool NumbericOrLetterOrChineseOrUnderline(string input)
        //{
        //    return Regex.IsMatch(input, RegularExp.NumbericOrLetterOrChineseOrUnderline);
        //}

        ///// <summary>
        ///// 驗證由數位、26個英文字母或者下劃線組成的字串
        ///// </summary>
        ///// <param name="input">要驗證的字串</param>
        ///// <returns>驗證通過返回true</returns>
        //public static bool IsNumericOrLetterOrUnderline(string input)
        //{
        //    return Regex.IsMatch(input, RegularExp.NumericOrLetterOrUnderline);
        //}

        ///// <summary>
        ///// 驗證email地址
        ///// </summary>
        ///// <param name="input">要驗證的字串</param>
        ///// <returns>驗證通過返回true</returns>
        //public static bool IsEmail(string input)
        //{
        //    return Regex.IsMatch(input, RegularExp.Email);
        //}

        ///// <summary>
        ///// 驗證URL
        ///// </summary>
        ///// <param name="input">要驗證的字串</param>
        ///// <returns>驗證通過返回true</returns>
        //public static bool IsUrl(string input)
        //{
        //    return Regex.IsMatch(input, RegularExp.Url);
        //}

        ///// <summary>
        ///// 驗證電話號碼
        ///// </summary>
        ///// <param name="input">要驗證的字串</param>
        ///// <returns>驗證通過返回true</returns>
        //public static bool IsTelephone(string input)
        //{
        //    return Regex.IsMatch(input, RegularExp.Telephone);
        //}

        ///// <summary>
        ///// 驗證手機號碼
        ///// </summary>
        ///// <param name="input">要驗證的字串</param>
        ///// <returns>驗證通過返回true</returns>
        //public static bool IsMobile(string input)
        //{
        //    return Regex.IsMatch(input, RegularExp.Mobile);
        //}

        ///// <summary>
        ///// 通過檔副檔名驗證圖像格式
        ///// </summary>
        ///// <param name="input">要驗證的字串</param>
        ///// <returns>驗證通過返回true</returns>
        //public static bool IsImageFormat(string input)
        //{
        //    return Regex.IsMatch(input, RegularExp.ImageFormat);
        //}



        ///// <summary>
        ///// 驗證顏色（#ff0000）
        ///// </summary>
        ///// <param name="input">要驗證的字串</param>
        ///// <returns>驗證通過返回true</returns>
        //public static bool IsColor(string input)
        //{
        //    return Regex.IsMatch(input, RegularExp.Color);
        //}

        ///// <summary>
        ///// 驗證Guid
        ///// </summary>
        ///// <param name="input">要驗證的字串</param>
        ///// <returns>驗證通過返回true</returns>
        //public static bool IsGuid(string input)
        //{
        //    return Regex.IsMatch(input, RegularExp.Guid);
        //}

        ///// <summary>
        ///// 驗證 Password 必須英數字大小寫 + 數字
        ///// </summary>
        ///// <param name="input">要驗證的字串</param>
        ///// <returns>驗證通過返回true</returns>
        //public static bool IsPassword(string input)
        //{
        //    return Regex.IsMatch(input, RegularExp.Password);
        //}

        ///// <summary>
        ///// 檢查是否符合台灣身分證字號規則
        ///// </summary>
        ///// <param name="id" />身分證字號</param>
        ///// <returns></returns>
        //public static bool IsROCIDNO(string id)
        //{
        //    if (string.IsNullOrEmpty(id))
        //    {
        //        //沒有輸入，回傳 ID 錯誤
        //        return false;   
        //    }

        //    id = id.ToUpper();
        //    var regex = new Regex("^[A-Z]{1}[0-9]{9}$");
        //    if (!regex.IsMatch(id))
        //    {
        //        return false;   //Regular Expression 驗證失敗，回傳 ID 錯誤
        //    }

        //    if (id[1] != '1' && id[1] != '2')
        //    {
        //        return false; // 第二碼只會有 1 或 2 ，用以表示性別
        //    }

        //    int[] seed = new int[10]; 
        //    //除了檢查碼外每個數字的存放空間
        //    string[] charMapping = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "J", "K", "L", "M", "N", "P", "Q", "R", "S", "T", "U", "V", "X", "Y", "W", "Z", "I", "O" };
        //    //A=10 B=11 C=12 D=13 E=14 F=15 G=16 H=17 J=18 K=19 L=20 M=21 N=22
        //    //P=23 Q=24 R=25 S=26 T=27 U=28 V=29 X=30 Y=31 W=32  Z=33 I=34 O=35

        //    string target = id.Substring(0, 1);

        //    for (int index = 0; index < charMapping.Length; index++)
        //    {
        //        if (charMapping[index] == target)
        //        {
        //            index += 10;
        //            seed[0] = index / 10;       //10進制的高位元放入存放空間
        //            seed[1] = (index % 10) * 9; //10進制的低位元*9後放入存放空間
        //            break;
        //        }
        //    }

        //    for (int index = 2; index < 10; index++)
        //    {   //將剩餘數字乘上權數後放入存放空間
        //        seed[index] = Convert.ToInt32(id.Substring(index - 1, 1)) * (10 - index);
        //    }

        //    //檢查是否符合檢查規則，10減存放空間所有數字和除以10的餘數的個位數字是否等於檢查碼
        //    //(10 - ((seed[0] + .... + seed[9]) % 10)) % 10 == 身分證字號的最後一碼
        //    bool checkResult = (10 - (seed.Sum() % 10)) % 10 == Convert.ToInt32(id.Substring(9, 1));

        //    return checkResult;
        //}
        #endregion
    }

    public struct RegularExp
    {
        public const string Chinese = @"^[\u4E00-\u9FA5\uF900-\uFA2D]+$";
        public const string Color = "^#[a-fA-F0-9]{6}";
        public const string Date = @"^((((1[6-9]|[2-9]\d)\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-0?2-(0?[1-9]|1\d|2[0-8]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29-))$";
        public const string DateTime = @"^((((1[6-9]|[2-9]\d)\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-0?2-(0?[1-9]|1\d|2[0-8]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29-)) (20|21|22|23|[0-1]?\d):[0-5]?\d:[0-5]?\d$";
        public const string Email = @"^[\w-]+(\.[\w-]+)*@[\w-]+(\.[\w-]+)+$";
        public const string Float = @"^(-?\d+)(\.\d+)?$";
        public const string ImageFormat = @"\.(?i:jpg|bmp|gif|ico|pcx|jpeg|tif|png|raw|tga)$";
        public const string Integer = @"^-?\d+$";
        public const string IP = @"^(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])$";
        public const string Letter = "^[A-Za-z]+$";
        public const string LowerLetter = "^[a-z]+$";
        public const string MinusFloat = @"^(-(([0-9]+\.[0-9]*[1-9][0-9]*)|([0-9]*[1-9][0-9]*\.[0-9]+)|([0-9]*[1-9][0-9]*)))$";
        public const string MinusInteger = "^-[0-9]*[1-9][0-9]*$";
        public const string Mobile = "^0{0,1}13[0-9]{9}$";
        public const string NumbericOrLetterOrChinese = @"^[A-Za-z0-9\u4E00-\u9FA5\uF900-\uFA2D]+$";
        public const string NumbericOrLetterOrChineseOrUnderline = @"^[A-Za-z0-9\u4E00-\u9FA5\uF900-\uFA2D_]+$";
        public const string Numeric = "^[0-9]+$";
        public const string NumericOrLetter = "^[A-Za-z0-9]+$";
        public const string NumericOrLetterOrUnderline = "^[A-Za-z0-9_]+$";
        public const string PlusFloat = @"^(([0-9]+\.[0-9]*[1-9][0-9]*)|([0-9]*[1-9][0-9]*\.[0-9]+)|([0-9]*[1-9][0-9]*))$";
        public const string PlusInteger = "^[0-9]*[1-9][0-9]*$";
        public const string Telephone = @"(^09\d{2}-?\d{3}-?\d{3}$)|(^(\d{2,3}-)?\d{7,8}(-\d+)?$)";
        public const string UnMinusFloat = @"^\d+(\.\d+)?$";
        public const string UnMinusInteger = @"\d+$";
        public const string UnPlusFloat = @"^((-\d+(\.\d+)?)|(0+(\.0+)?))$";
        public const string UnPlusInteger = @"^((-\d+)|(0+))$";
        public const string UpperLetter = "^[A-Z]+$";
        public const string Url = @"^http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?$";
        public const string Guid = "[0-9a-fA-F]{8}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{12}";
        public const string Password = @"(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).*$";

        // 先列出一些簡易的字元就好
        public const string SpecialCharacters = "[@#$%!&+~|'\"?<>/\\\\]";
    }
}
