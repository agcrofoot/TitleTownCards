using System;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using API.Models.Interfaces.Add;

namespace API.Models.Save
{
    public class AddMemberData : IAddMember
    {
        public void AddMember(Member value)
        {
            DBConnect db = new DBConnect();
            bool isOpen = db.OpenConnection();

            if(isOpen)
            {
                MySqlConnection conn = db.GetConn();
                MySqlCommand cmd = new MySqlCommand();

                cmd.Connection = conn;

                cmd.CommandText = @"INSERT INTO Member(MemberName, MemberAddress, MemberEmail, MemberDOB, MemberPhone)
                VALUES(@MemberName, @MemberAddress, @MemberEmail, @MemberDOB, @MemberPhone)";
                cmd.Parameters.AddWithValue("@MemberName",value.memberName);
                cmd.Parameters.AddWithValue("@MemberAddress",value.memberAddress);
                cmd.Parameters.AddWithValue("@MemberEmail",value.memberEmail);
                cmd.Parameters.AddWithValue("@MemberDOB",value.memberDOB);
                cmd.Parameters.AddWithValue("@MemberPhone",value.memberPhone);
                cmd.Prepare();
                cmd.ExecuteNonQuery();

                //close connection
                db.CloseConnection();
            }
        }
    }
}