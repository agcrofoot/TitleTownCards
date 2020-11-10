namespace API.Models
{
    public class Manager
    {
        public int managerID{get; set;}
        public string managerName{get; set;}
        public string managerPhone{get; set;}
        public string managerEmail{get; set;}
        public string managerAddress{get; set;}

        public override string ToString()
        {
            return managerID + "/" + managerName + "/" + managerPhone + "/" + managerEmail + "/" + managerAddress;
        }
    }
}