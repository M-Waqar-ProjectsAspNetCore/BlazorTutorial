using BlazorTutorial.Data;
using BlazorTutorial.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorTutorial.Pages
{
    public class EditEmployeeBase : ComponentBase
    {
        [Parameter]
        public int Id { get; set; }
        [Inject]
        public IEmployeeService EmployeeService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public Employee Employee { get; set; }

        protected override void OnInitialized()
        {
            Employee = EmployeeService.GetEmployeeById(Id);
            base.OnInitialized();   
        }
        protected void EditEmployee()
        {
            EmployeeService.EditEmployee(Employee);
            NavigationManager.NavigateTo("/employees");
        }
    }
}
