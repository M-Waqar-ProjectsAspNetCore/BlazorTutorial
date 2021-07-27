using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorTutorial.Pages
{
    public class ConfirmCompBase : ComponentBase
    {
        [Parameter]
        public string ConfirmationMessage { get; set; }
        [Parameter]
        public string ConfirmationTitle { get; set; }
        [Parameter]
        public EventCallback<bool> ConfirmationChanged { get; set; }

        public bool ShowConfirmation { get; set; }

        public void Show()
        {
            ShowConfirmation = true;
            StateHasChanged();
        }

        protected async Task OnConfirmationChange(bool status)
        {
            ShowConfirmation = false;
            await ConfirmationChanged.InvokeAsync(status);
        }
    }
}
