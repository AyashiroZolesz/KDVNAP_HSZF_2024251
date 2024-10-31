namespace KDVNAP_HSZF_2024251.Model
{
    public class Factory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Size { get; set; }
        public List<Department> Departments { get; set; } = new();
    }

    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int FactoryId { get; set; }
        public Factory Factory { get; set; }  // Kapcsolat a Factory osztállyal
        public List<Employee> Employees { get; set; } = new();
    }

    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public List<Department> Departments { get; set; } = new();
    }
}
