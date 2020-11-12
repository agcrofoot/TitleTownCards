using System;
using System.Data.SQLite;
using API.Models.Interfaces.Add;

namespace API.Models.Save
{
    public class AddMemberData : IAddMember
    {
        public void AddMember(Member value)
        {
            string cs = @"URI = file:C:\Users\birdc\source\repos\TitleTownCards\TTCDatabase.db";
            using var con = new SQLiteConnection(cs);
            con.Open();

            using var cmd = new SQLiteCommand(con);

            cmd.CommandText = @"INSERT INTO Member(MemberFName, MemberLName, MemberAddress1, MemberAddress2, MemberCity, MemberState, MemberZip, MemberCountry, MemberEmail, MemberDOB, MemberPhone, MemberCardNo)
                VALUES(@MemberFName, @MemberLName, @MemberAddress1, @MemberAddress2, @MemberCity, @MemberState, @MemberZip, @MemberCountry, @MemberEmail, @MemberDOB, @MemberPhone, @MemberCardNo)";
            cmd.Parameters.AddWithValue("@MemberFName",value.memberFName);
            cmd.Parameters.AddWithValue("@MemberLName",value.memberLName);
            cmd.Parameters.AddWithValue("@MemberAddress1",value.memberAddress1);
            cmd.Parameters.AddWithValue("@MemberAddress2",value.memberAddress2);
            cmd.Parameters.AddWithValue("@MemberCity",value.memberCity);
            cmd.Parameters.AddWithValue("@MemberState",value.memberState);
            cmd.Parameters.AddWithValue("@MemberZip",value.memberZip);
            cmd.Parameters.AddWithValue("@MemberCountry",value.memberCountry);
            cmd.Parameters.AddWithValue("@MemberEmail",value.memberEmail);
            cmd.Parameters.AddWithValue("@MemberDOB",value.memberDOB);
            cmd.Parameters.AddWithValue("@MemberPhone",value.memberPhone);
            cmd.Parameters.AddWithValue("@MemberCardNo",value.memberCardNo);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }
    }
}