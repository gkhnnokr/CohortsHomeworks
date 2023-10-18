using Week2Homework.Entities;

namespace Week2Homework.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private List<Employee> _employees;

        public EmployeeRepository()
        {
            _employees = new List<Employee>
        {
            new Employee { Id = 1, Name = "Gökhan", Surname = "Okur" },
            new Employee { Id = 2, Name = "İlkay", Surname = "Seki" },
            new Employee { Id = 3, Name = "Ahmet", Surname = "Yağmur" },
        };
        }
        public List<Employee> GetEmployees()
        {
            return _employees;
        }

        public Employee GetEmployeeById(int id)
        {
            return _employees.FirstOrDefault(e => e.Id == id);
        }

        public void AddEmployee(Employee employee)
        {
            int newId = _employees.Max(e => e.Id) + 1;
            employee.Id = newId;
            _employees.Add(employee);
        }

        public void UpdateEmployee(int id, Employee updatedEmployee)
        {
            var employee = _employees.FirstOrDefault(e => e.Id == id);
            if (employee != null)
            {
                employee.Name = updatedEmployee.Name;
                employee.Surname = updatedEmployee.Surname;
            }
        }

        public void DeleteEmployee(int id)
        {
            var employee = _employees.FirstOrDefault(e => e.Id == id);
            if (employee != null)
            {
                _employees.Remove(employee);
            }
            else
            {
                throw new Exception("Silme işlemi başarısız oldu.");
            }
        }
    }
}
