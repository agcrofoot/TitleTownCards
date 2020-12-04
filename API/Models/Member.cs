namespace API.Models
{
    public class Member
    {
        public int memberID{get; set;}
        public string memberName{get; set;}
        public string memberAddress{get; set;}
        public string memberEmail{get; set;}
        public string memberDOB{get; set;}
        public string memberPhone{get; set;}
        public override string ToString()
        {
            return memberID + "/" + memberName + "/" + memberAddress + "/" + memberEmail + "/" + memberDOB + "/" + memberPhone;
        }
    }
}