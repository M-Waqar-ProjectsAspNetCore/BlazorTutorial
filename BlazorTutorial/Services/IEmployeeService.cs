using BlazorTutorial.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorTutorial.Services
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> GetEmployees();
        Employee GetEmployeeById(int id);
        Employee AddEmployee(Employee newemployee);
        Employee DeleteEmployee(int id);
        Employee EditEmployee(Employee employee);
    }
}
