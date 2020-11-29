using System;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using API.Models.Interfaces.Delete;

namespace API.Models.Delete
{
    public class DeleteMemberData : IDeleteMember
    {
        public void DeleteMember(int memberID)
        {
            DBConnect db = new DBConnect();
            bool isOpen = db.OpenConnection();

            if(isOpen)
            {
                MySqlConnection conn = db.GetConn();
                MySqlCommand cmd = new MySqlCommand();

                cmd.Connection = conn;

                cmd.CommandText = @"DELETE FROM Member WHERE MemberID = @MemberID";
                cmd.Parameters.AddWithValue("@MemberID", memberID);
                cmd.Prepare();
                cmd.ExecuteNonQuery();

                //close connection
                db.CloseConnection();
            }
        }
    }
}