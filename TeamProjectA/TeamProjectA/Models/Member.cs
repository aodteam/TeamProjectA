using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TeamProjectA.Models
{
    public class Member
    {
        //회원번호, 아이디, 비번, 이름, 이메일, 가입일
        public int No { get; set; }

        [Required(ErrorMessage = "아이디는 필수입니다")]  //필수특성
        [StringLength(18, MinimumLength = 6, ErrorMessage = "아이디는 최소 6자부터 18자까지입니다.")]
        public string Userid { get; set; }

        [Required(ErrorMessage = "비밀번호는 필수입니다")]  //필수특성
        [StringLength(18, MinimumLength = 6, ErrorMessage = "비밀번호는 최소 6자부터 18자까지입니다.")]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{6,18}$", ErrorMessage = "비밀번호는 영문자,숫자 조합으로 입력하세요")]
        public string Passwd { get; set; }

        [Required(ErrorMessage = "비밀번호 확인은 필수입니다")]  //필수특성
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{6,18}$", ErrorMessage = "비밀번호는 영문자,숫자 조합으로 최소 6자부터 18자까지 입력하세요")]
        [Compare("Passwd", ErrorMessage = "비밀번호가 서로 일치하지 않습니다.")]
        public string Repwd { get; set; }

        [Required(ErrorMessage = "이름은 필수입니다")]  //필수특성
        public string Usernm { get; set; }

        [Display(Name = "이메일 주소")]
        [Required(ErrorMessage = "이메일은 필수입니다")]  //필수특성
        [EmailAddress(ErrorMessage = "이메일 형식이 잘못되었습니다.")]
        public string Email { get; set; }

        public string Regdate { get; set; }


    }
}