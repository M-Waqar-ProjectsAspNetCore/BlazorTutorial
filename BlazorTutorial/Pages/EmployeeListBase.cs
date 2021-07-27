using BlazorTutorial.Data;
using BlazorTutorial.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorTutorial.Pages
{
    public class EmployeeListBase : ComponentBase
    {
        [Inject]
        public IEmployeeService EmployeeService { get; set; }
        public IEnumerable<Employee> Employees;
        public bool DisplayButtons = true;
        public int Count = 0;

        protected override void OnInitialized()
        {
            Employees = EmployeeService.GetEmployees().ToList();
        }

        protected void SelectedEmployee(bool selected)
        {
            if (selected)
                Count++;
            else
                Count--;
        }

        protected void DeleteEmployee(int id)
        {
            EmployeeService.DeleteEmployee(id);
            Employees = EmployeeService.GetEmployees().ToList();
        }
    }
}
