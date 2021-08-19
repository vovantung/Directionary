using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.Login
{
    public class LoginRequest
    {
        [Required(ErrorMessage = "Nhập tên đăng nhập!")]
        public string Username { set; get; }
        [Required(ErrorMessage = "Nhập mật khẩu!")]
        public string Password { set; get; }
        public bool RememberMe { set; get; }
    }
}
