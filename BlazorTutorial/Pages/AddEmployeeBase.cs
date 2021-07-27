using BlazorTutorial.Data;
using BlazorTutorial.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorTutorial.Pages
{
    public class AddEmployeeBase : ComponentBase
    {
        [Inject]
        public IEmployeeService EmployeeService { get; set; }
        public Employee Employee { get; set; }

        protected override void OnInitialized()
        {
            Employee = new Employee();
            base.OnInitialized();
        }

        protected void AddEmployee()
        {
            EmployeeService.AddEmployee(Employee);
            Employee = new Employee();
        }

    }
}
