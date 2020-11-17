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
            string cs = @"server=<localhost>;user=<root>;database=<ttowncards>;password=<>;";
            MySqlConnection con = new MySqlConnection(cs);
            con.Open();

            string stm = "SELECT * FROM Member";
            MySqlCommand cmd = new MySqlCommand(stm,con);

            using SQLiteDataReader rdr = cmd.ExecuteReader();
            List<Member> allMembers = new List<Member>();
            while(rdr.Read())
            {
                allMembers.Add(new Member(){memberID = rdr.GetInt32(0), memberFName = rdr.GetString(1), memberLName = rdr.GetString(2), memberAddress1 = rdr.GetString(3), memberAddress2 = rdr.GetString(4), memberCity = rdr.GetString(5), memberState = rdr.GetString(6), memberZip = rdr.GetInt32(7), memberCountry = rdr.GetString(8), memberEmail = rdr.GetString(9), memberDOB = rdr.GetString(10), memberPhone = rdr.GetString(11), memberCardNo = rdr.GetInt32(12)});
            }
            return allMembers;
        }
        public Member GetMember(int memberID)
        {
            string cs = @"URI = file:C:\Users\birdc\source\repos\TitleTownCards\TTCDatabase.db";
            using var con = new SQLiteConnection(cs);
            con.Open();

            string stm = "SELECT * FROM Member WHERE MemberID = @MemberID";
            using var cmd = new SQLiteCommand(stm, con);
            cmd.Parameters.AddWithValue("@MemberID", memberID);
            cmd.Prepare();
            using SQLiteDataReader rdr = cmd.ExecuteReader();
            
            rdr.Read();
            return new Member(){memberID = rdr.GetInt32(0), memberFName = rdr.GetString(1), memberLName = rdr.GetString(2), memberAddress1 = rdr.GetString(3), memberAddress2 = rdr.GetString(4), memberCity = rdr.GetString(5), memberState = rdr.GetString(6), memberZip = rdr.GetInt32(7), memberCountry = rdr.GetString(8), memberEmail = rdr.GetString(9), memberDOB = rdr.GetString(10), memberPhone = rdr.GetString(11), memberCardNo = rdr.GetInt32(12)};
        }
    }
}