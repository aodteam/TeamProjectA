using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace TeamProjectA.Models
{
    public class Logon
    {
        [Required(ErrorMessage = "아이디를 입력해주세요")]
        public string Userid { set; get; }

        [Required(ErrorMessage = "비밀번호는 입력해주세요.")]
        public string Passwd { set; get; }
    }
}