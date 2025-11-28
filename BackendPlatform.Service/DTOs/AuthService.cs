using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using BackendPlatform.API.Attributes.DtoValidations;

namespace BackendPlatform.Service.DTOs
{
    // DTO 存在的層級 (位置/順序)
    // 1. 前端傳入的請求 => controller action
    // 2. 呼叫服務物件 => service method
    // 3. 呼叫相關元件 => 某個物件的方法 (這一點可有可無)
    // 4. 呼叫資料存取物件 => repository method

    // 5. 資料存取物件 從DB回傳相關資料到 相關元件
    // 6. 相關元件 回傳資料給服務物件
    // 7. 服務物件回傳資料給 controller action (服務層的回應物件定義成 record 就可以, 因為不會再修改欄位資料)

    public sealed class LoginRequest
    {
        /// <summary>
        /// 帳號
        /// </summary>
        [Required(ErrorMessage = "")]
        [MaxLength(20, ErrorMessage = "")]
        //[NumericOrLetter(ErrorMessage = "")]
        public string Account { get; set; }
        public string Pwd { get; set; }
        public string AuthCode { get; set; }
        public bool FromJspLogin { get; set; }
        public int LoginRole { get; set; }
        public string LangCode { get; set; }
        internal string IP { get; set; }
    }
}
