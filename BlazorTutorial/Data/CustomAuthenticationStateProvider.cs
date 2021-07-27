using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BlazorTutorial.Data
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        private ISessionStorageService SessionStorageService;

        public CustomAuthenticationStateProvider(ISessionStorageService SessionStorageService)
        {
            this.SessionStorageService = SessionStorageService;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            string emailAddress = await SessionStorageService.GetItemAsync<string>("EMAIL");
            ClaimsIdentity identity;
            if (!string.IsNullOrEmpty(emailAddress))
            {
                identity = new ClaimsIdentity(new[]
                {
                   new Claim(ClaimTypes.Name, emailAddress)
                }, "apiauth_type");
            }
            else
            {
                identity = new ClaimsIdentity();
            }
            var user = new ClaimsPrincipal(identity);

            return await Task.FromResult(new AuthenticationState(user));
        }

        public void MarkUserAsAuthenticated(string emailAddress)
        {
            var identity = new ClaimsIdentity(new[]
            {
                    new Claim(ClaimTypes.Name, emailAddress)
            }, "apiauth_type");

            var user = new ClaimsPrincipal(identity);

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
        }

        public void MarkUserAsLogOut()
        {
            SessionStorageService.RemoveItemAsync("EMAIL");
            var identity = new ClaimsIdentity();
            var user = new ClaimsPrincipal(identity);
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
        }
    }
}
