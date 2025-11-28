using System.ComponentModel.DataAnnotations;
using BackendPlatform.API.Attributes.DtoValidations;

namespace BackendPlatform.API.DTOs
{
    // 基本上 API Request Dto 的欄位資料驗證, 都要定義在 DTO 的物件上面

    public class API_LoginRequestBase
    {
        /// <summary>
        /// 帳號
        /// </summary>
        [Required(ErrorMessage = "")]
        [MaxLength(20, ErrorMessage = "")]
        [NumericOrLetter(ErrorMessage = "")]
        public string Account { get; set; }

        /// <summary>
        /// 密碼
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 驗證碼
        /// </summary>
        public string AuthCode { get; set; }

        /// <summary>
        /// 是否從JSP登入過來的
        /// </summary>
        public bool FromJspLogin { get; set; } = false;
    }

    public sealed class API_LoginRequest : API_LoginRequestBase
    {
        public int LoginRole { get; set; }
        public string LangCode { get; set; }
        internal string IP { get; set; }
    }
}
