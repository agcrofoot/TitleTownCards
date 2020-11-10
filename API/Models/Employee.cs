namespace API.Models
{
    public class Employee
    {
        public int employeeID{get; set;}
        public string employeeName{get; set;}
        public string employeePhone{get; set;}
        public string employeeEmail{get; set;}
        public string employeeAddress{get; set;}
        public int managerID{get; set;}

        public override string ToString()
        {
            return employeeID + "/" + employeeName + "/" + employeePhone + "/" + employeeEmail + "/" + employeeAddress + "/" + managerID;
        }
    }
}