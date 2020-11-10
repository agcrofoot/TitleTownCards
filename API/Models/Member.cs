namespace API.Models
{
    public class Member
    {
        public int memberID{get; set;}
        public string memberFName{get; set;}
        public string memberLName{get; set;}
        public string memberAddress1{get; set;}
        public string memberAddress2{get; set;}
        public string memberCity{get; set;}
        public string memberState{get; set;}
        public int memberZip{get; set;}
        public string memberCountry{get; set;}
        public string memberEmail{get; set;}
        public string memberDOB{get; set;}
        public string memberPhone{get; set;}
        public int memberCardNo{get; set;}
        public override string ToString()
        {
            return memberID + "/" + memberFName + "/" + memberLName + "/" + memberAddress1 + "/" + memberAddress2 + "/" + memberCity + "/" + memberState + "/" + memberZip + "/" + memberCountry + "/" + memberEmail + "/" + memberDOB + "/" + memberPhone + "/" + memberCardNo;
        }
    }
}