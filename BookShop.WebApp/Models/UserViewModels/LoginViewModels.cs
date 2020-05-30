using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.ComponentModel.DataAnnotations;


namespace BookShop.WebApp.Models
{
    /// <summary>
    /// 用于数据显示和校验
    /// </summary>
    public class LoginViewModels
    {

        [Required]
        [DisplayName("用户名")]
        [StringLength(maximumLength:20,MinimumLength = 10,ErrorMessage = "{0}最大限度为{1}最小限度为{2}")]
        public string UserNo { get; set; }
        
        [Required]
        [DisplayName("用户密码")]
        [DataType(DataType.Password)]
        [StringLength(maximumLength: 20, MinimumLength = 10, ErrorMessage = "{0}最大限度为{1}最小限度为{2}")]
        public string UserPwd { get; set; }

        [Required]
        [DisplayName("验证码")]
        public string Captcha { get; set; }

        public bool IsRemenber { get; set; }

    }
}