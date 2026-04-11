using Xunit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StreetTshirtApp.Services;
using StreetTshirtApp.Models;
using StreetTshirtApp.Data;
using System.Threading.Tasks;
using System;

namespace StreetTshirtApp.Tests
{
    public class AuthServiceTests
    {
        private readonly AuthService _authService;
        private readonly ApplicationDbContext _context;

        public AuthServiceTests()
        {
            // 1. Configura as opções do Banco em Memória
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            // 2. Configura um ServiceCollection para simular a Injeção de Dependência
            var services = new ServiceCollection();
            services.AddScoped(_ => new ApplicationDbContext(options));
            var serviceProvider = services.BuildServiceProvider();
            var scopeFactory = serviceProvider.GetRequiredService<IServiceScopeFactory>();

            // 3. Inicializa o contexto para preparar os dados
            _context = new ApplicationDbContext(options);
            _context.Users.Add(new User { Email = "admin", Password = "1234" });
            _context.SaveChanges();

            // 4. Passa o scopeFactory que o AuthService exige no erro CS1503
            _authService = new AuthService(scopeFactory);
        }

        [Fact]
        public async Task TC_AUTH_003_LoginSuccessfully()
        {
            var result = await _authService.Login("admin", "1234");
            Assert.True(result);
        }

        [Fact]
        public async Task TC_AUTH_004_LoginWithInvalidPassword()
        {
            var result = await _authService.Login("admin", "wrong");
            Assert.False(result);
        }
    }
}