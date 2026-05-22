namespace EmployeeManagementAPI.Models
{
    public class Employee
    {
        //This becomes a coloum in database table.
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public decimal Salary { get; set; }
        public string Email { get; set; } = string.Empty;
    }
}
