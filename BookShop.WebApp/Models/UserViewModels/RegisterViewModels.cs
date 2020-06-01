using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookShop.WebApp.Models.UserViewModels
{
    public class RegisterViewModels
    {
        [Required]
        [DisplayName("用户名")]
        [StringLength(maximumLength:12,MinimumLength = 5,ErrorMessage = "{0}最长为{1}，最短为{2}")]
        public string UserName { get; set; }
        [Required]
        [DisplayName("用户姓名")]
        [StringLength(maximumLength: 4, MinimumLength =2, ErrorMessage = "{0}最长为{1}，最短为{2}")]
        public string Name { get; set; }
        [Required]
        [DisplayName("密码")]
        [StringLength(maximumLength: 12, MinimumLength = 8, ErrorMessage = "{0}最长为{1}，最短为{2}")]
        public string UserPwd { get; set; }
        [Required]
        [DisplayName("第二次输入的密码")]
        [Compare("UserName",ErrorMessage = "两次密码不一致")]
        public string ConfirmPwd { get; set; }
        [Required]
        [DisplayName("邮箱")]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DisplayName("住址")]
        [StringLength(maximumLength: 12, ErrorMessage = "{0}最长为{1}")]
        public string Adress { get; set; }
        [Required]
        [DisplayName("电话")]
        [StringLength(maximumLength: 11,MinimumLength = 11, ErrorMessage = "{0}最长度应为{1}位}")]
        public string Phone { get; set; }
        [Required]
        [DisplayName("验证码")]
        [StringLength(maximumLength: 5, MinimumLength = 5, ErrorMessage = "{0}的长度应为{1}")]
        public string Captcha { get; set; }
    }
}