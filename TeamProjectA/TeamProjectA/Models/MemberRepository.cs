using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TeamProjectA.Models
{
    public class MemberRepository
    {
        //ADO.NET 연결문자열
        private string sqlurl = ConfigurationManager.ConnectionStrings["sqlconn"].ConnectionString;

        private SqlConnection sqlconn = null;

        //생성자
        public MemberRepository()
        {
            // SQL 연결 객체 생성
            sqlconn = new SqlConnection(sqlurl);
            sqlconn.Open();
        }
        // 회원 CRUD
        public void insertMember(Member m)
        {
            using (SqlCommand cmd = new SqlCommand("newMember", sqlconn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@userid", m.Userid);
                cmd.Parameters.AddWithValue("@passwd", m.Passwd);
                cmd.Parameters.AddWithValue("@username", m.Usernm);
                cmd.Parameters.AddWithValue("@email", m.Email);

                cmd.ExecuteNonQuery();
            };
        }

        // 회원정보 아이디 가져오기
        public Member selectOneMember(Member m)
        {
            using (SqlCommand cmd = new SqlCommand("oneMember", sqlconn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@userid", m.Userid);
                cmd.Parameters.AddWithValue("@passwd", m.Passwd);

                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    if (sdr.HasRows)        //아이디 비번이 일치한다면
                    {
                        sdr.Read();
                        m.Usernm = sdr["UserName"].ToString();
                        m.Email = sdr["Email"].ToString();
                        m.Regdate = sdr["RegDate"].ToString();
                    }
                    else
                    {
                        m = null;
                    }
                }   //sdr
            }       //cmd
            return m;
        }
    }
}