using Xunit;
using StreetTshirtApp.Services;
using StreetTshirtApp.Model;

namespace StreetTshirtApp.Tests
{
    public class AuthServiceTests
    {
        private readonly AuthService _authService;

        public AuthServiceTests()
        {
            _authService = new AuthService();
        }

        // REQ-AUTH-001 - Register
        [Fact]
        public void TC_AUTH_001_RegisterUserSuccessfully()
        {
            var result = _authService.Register("test@email.com", "123456");

            Assert.True(result);
        }

        [Fact]
        public void TC_AUTH_002_RegisterWithExistingEmail()
        {
            _authService.Register("test@email.com", "123456");

            var result = _authService.Register("test@email.com", "123456");

            Assert.False(result);
        }

        // REQ-AUTH-002 - Login
        [Fact]
        public void TC_AUTH_003_LoginSuccessfully()
        {
            _authService.Register("user@email.com", "123456");

            var result = _authService.Login("user@email.com", "123456");

            Assert.True(result);
        }

        [Fact]
        public void TC_AUTH_004_LoginWithInvalidPassword()
        {
            _authService.Register("user@email.com", "123456");

            var result = _authService.Login("user@email.com", "wrong");

            Assert.False(result);
        }

        // REQ-AUTH-003 - Logout
        [Fact]
        public void TC_AUTH_005_LogoutSuccessfully()
        {
            _authService.Register("user@email.com", "123456");
            _authService.Login("user@email.com", "123456");

            _authService.Logout();

            Assert.False(_authService.IsAuthenticated);
        }
    }
}