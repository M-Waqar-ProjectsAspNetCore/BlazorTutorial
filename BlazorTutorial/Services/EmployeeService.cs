using BlazorTutorial.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorTutorial.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly Data.AppContext context;
        public EmployeeService(Data.AppContext context)
        {
            this.context = context;
        }
        public Employee AddEmployee(Employee newemployee)
        {
            context.Add(newemployee);
            context.SaveChanges();
            return newemployee;
        }
        public Employee DeleteEmployee(int id)
        {
            Employee emp = context.employees.Find(id);
            context.Remove(emp);
            context.SaveChanges();
            return emp;
        }
        public Employee EditEmployee(Employee employee)
        {
            context.Update(employee);
            context.SaveChanges();
            return employee;
        }
        public Employee GetEmployeeById(int id)
        {
            return context.employees.Find(id);
        }
        public IEnumerable<Employee> GetEmployees()
        {
            return context.employees;
        }

    }
}
