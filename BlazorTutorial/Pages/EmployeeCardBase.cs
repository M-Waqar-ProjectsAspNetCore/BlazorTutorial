using BlazorTutorial.Data;
using BlazorTutorial.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace BlazorTutorial.Pages
{
    public class EmployeeCardBase : ComponentBase
    {
        [Parameter]
        public Employee Employee { get; set; }
        [Parameter]
        public bool DisplayButtons { get; set; }
        [Parameter]
        public EventCallback<bool> OnSelectedEmployee { get; set; }
        [Parameter]
        public EventCallback<int> OnDeleteEmployee { get; set; }

        protected ConfirmComp DeleteConfirmation { get; set; }

        protected void CheckBoxChanged(ChangeEventArgs e)
        {
            OnSelectedEmployee.InvokeAsync(Convert.ToBoolean(e.Value));
        }
        protected void DeleteEmployee()
        {
            DeleteConfirmation.Show();
        }
        protected async Task ConfirmDeleteClick(bool isDelete)
        {
            if(isDelete)
                await OnDeleteEmployee.InvokeAsync(Employee.Id);
        }
    }
}
