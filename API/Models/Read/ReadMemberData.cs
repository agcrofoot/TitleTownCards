using System.Collections.Generic;
using API.Models.Interfaces.GetAll;
using API.Models.Interfaces.Get;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using System;

namespace API.Models.Read
{
    public class ReadMemberData : IGetAllMembers, IGetMember
    {
        public List<Member> GetAllMembers()
        {
            DBConnect db = new DBConnect();
            bool isOpen = db.OpenConnection();

            if(isOpen)
            {
                MySqlConnection conn = db.GetConn();
                string stm = "SELECT * FROM Member";
                MySqlCommand cmd = new MySqlCommand(stm,conn);

                List<Member> allMembers = new List<Member>();
                using(var rdr = cmd.ExecuteReader())
                {
                    while(rdr.Read())
                    {
                        allMembers.Add(new Member(){memberID = rdr.GetInt32(0), memberName = rdr.GetString(1), memberAddress = rdr.GetString(2), memberEmail = rdr.GetString(3), memberDOB = rdr.GetString(4), memberPhone = rdr.GetString(5)});
                    
                    }
                    db.CloseConnection();
                    return allMembers;
                }
            }
            else
            {
                return new List<Member>();
            }
        }
        public Member GetMember(int memberID)
        {
            DBConnect db = new DBConnect();
            bool isOpen = db.OpenConnection();

            if(isOpen)
            {
                MySqlConnection conn = db.GetConn();
                string stm = "SELECT * FROM Member WHERE MemberID = @MemberID";
                MySqlCommand cmd = new MySqlCommand(stm,conn);
                cmd.Parameters.AddWithValue("@MemberID", memberID);
                cmd.Prepare();
                using var rdr = cmd.ExecuteReader();
                rdr.Read();
                Member member = new Member(){memberID = rdr.GetInt32(0), memberName = rdr.GetString(1), memberAddress = rdr.GetString(2), memberEmail = rdr.GetString(3), memberDOB = rdr.GetString(4), memberPhone = rdr.GetString(5)};
                db.CloseConnection();
                return member;
            }
            else
            {
                return new Member();
            }
        }
    }
}