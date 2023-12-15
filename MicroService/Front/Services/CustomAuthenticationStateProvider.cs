using Front.Entities;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using System.Security.Claims;
using System.Security.Principal;

namespace Front.Services
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        private ClaimsPrincipal _currentUser = new ClaimsPrincipal(new ClaimsIdentity());
        private ProtectedLocalStorage _sessionStorage;

        public CustomAuthenticationStateProvider(ProtectedLocalStorage protectedSessionStorage)
        {
            _sessionStorage = protectedSessionStorage;
        }

        public async Task<ClaimsPrincipal> MarkUserAsAuthenticated(UserDTO user)
        {
            await _sessionStorage.SetAsync("User", user);
            var claims = new[] {
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Role, "User")
            };
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            _currentUser = new ClaimsPrincipal(identity);

            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());

            return _currentUser;
        }
        public async Task<ClaimsPrincipal> Logout()
        {
            await _sessionStorage.DeleteAsync("User");
            _currentUser = new ClaimsPrincipal(new ClaimsIdentity());

            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
            return _currentUser;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var userSession = await _sessionStorage.GetAsync<UserDTO>("User");
            if(userSession.Success && userSession.Value != null)
            {
                var user = userSession.Value;
                var claims = new[] {
                    new Claim(ClaimTypes.Name, user.Name),
                    new Claim(ClaimTypes.Role, "User")
                };
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                _currentUser = new ClaimsPrincipal(identity);
            } else {
                _currentUser = new ClaimsPrincipal(new ClaimsIdentity());
            }
            return await Task.FromResult(new AuthenticationState(_currentUser));
        }
    }
}
