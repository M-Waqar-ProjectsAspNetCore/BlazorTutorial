using BlazorTutorial.Data;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Authorization;
using Blazored.SessionStorage;

namespace BlazorTutorial.Pages
{
    public class LoginComponentBase : ComponentBase
    {
        public LoginModel loginModel { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        public AuthenticationStateProvider AuthenticationStateProvider { get; set; }
        [Inject]
        public ISessionStorageService SessionStorage { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            loginModel = new LoginModel();
        }

        protected async Task<bool> HandleSubmitAsync()
        {
            ((CustomAuthenticationStateProvider)AuthenticationStateProvider).MarkUserAsAuthenticated(loginModel.UserName);
            NavigationManager.NavigateTo("/home");
            await SessionStorage.SetItemAsync("EMAIL", loginModel.UserName);
            return await Task.FromResult(true);
        }
    }
}
