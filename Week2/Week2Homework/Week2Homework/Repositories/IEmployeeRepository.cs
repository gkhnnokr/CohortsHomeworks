using Week2Homework.Entities;

namespace Week2Homework.Repositories
{
    public interface IEmployeeRepository
    {
        List<Employee> GetEmployees();
        Employee GetEmployeeById(int id);
        void AddEmployee(Employee employee);
        void UpdateEmployee(int id, Employee updatedEmployee);
        void DeleteEmployee(int id);
    }
}
