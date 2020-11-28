using System;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using API.Models.Interfaces.Update;

namespace API.Models.Update
{
    public class UpdateMemberData : IUpdateMembers
    {
        public void EditMember(Member value)
        {
            DBConnect db = new DBConnect();
            bool isOpen = db.OpenConnection();

            if(isOpen)
            {
                MySqlConnection conn = db.GetConn();
                MySqlCommand cmd = new MySqlCommand();

                cmd.Connection = conn;

                cmd.CommandText = @"UPDATE Member SET MemberName = @MemberName, MemberAddress = @MemberAddress, MemberEmail = @MemberEmail,
                MemberDOB = @MemberDOB, MemberPhone = @MemberPhone WHERE MemberID = @MemberID";
                cmd.Parameters.AddWithValue("@MemberID",value.memberID);
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