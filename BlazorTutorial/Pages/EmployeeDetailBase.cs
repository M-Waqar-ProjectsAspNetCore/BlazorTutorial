using BlazorTutorial.Data;
using BlazorTutorial.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorTutorial.Pages
{
    public class EmployeeDetailBase : ComponentBase
    {
        [Inject]
        public IEmployeeService EmployeeService { get; set; }
        [Inject]
        protected NavigationManager NavigationManager { get; set; }
        [Parameter]
        public string Id { get; set; }

        protected ConfirmComp DeleteConfirmation { get; set; }

        public Employee Employee { get; set; }
        public string Cordinates { get; set; }
        public string CssHide { get; set; }
        public string BtnText { get; set; } = "Hide Menu";

        protected override void OnInitialized()
        {
            Employee = EmployeeService.GetEmployeeById(Convert.ToInt32(Id));
        }
        protected void MouseMove(MouseEventArgs e)
        {
            Cordinates = $"X:{e.ClientX} - Y:{e.ClientY}";
        }
        protected void NavigateBtn(MouseEventArgs e)
        {
            if (BtnText == "Hide Menu")
            {
                BtnText = "Show Menu";
                CssHide = "hide-btns";
            }
            else
            {
                BtnText = "Hide Menu";
                CssHide = "";
            }
        }
        protected void DeleteClick()
        {
            DeleteConfirmation.Show();
        }
        protected async Task DeleteConfirmed(bool isDelete)
        {
            if (isDelete)
            {
                EmployeeService.DeleteEmployee(Employee.Id);
                NavigationManager.NavigateTo("/employees");
            }
            await Task.FromResult(true);
        }
    }
}
