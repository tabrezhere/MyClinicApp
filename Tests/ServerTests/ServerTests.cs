using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace ClinicManagementSystem.Tests.ServerTests
{
    public class ServerTests
    {
        private readonly IServiceProvider _serviceProvider;

        public ServerTests()
        {
            var services = new ServiceCollection();
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseInMemoryDatabase("TestDb"));
            services.AddControllers();
            _serviceProvider = services.BuildServiceProvider();
        }

        [Fact]
        public async Task Test_AdminController_GetAllAdmins_ReturnsOk()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var controller = scope.ServiceProvider.GetRequiredService<AdminController>();
                var result = await controller.GetAllAdmins();
                Assert.IsType<OkObjectResult>(result);
            }
        }

        [Fact]
        public async Task Test_DoctorController_GetDoctorById_ReturnsNotFound_WhenDoctorDoesNotExist()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var controller = scope.ServiceProvider.GetRequiredService<DoctorController>();
                var result = await controller.GetDoctorById(999); // Assuming 999 does not exist
                Assert.IsType<NotFoundResult>(result);
            }
        }

        // Additional tests for other controllers can be added here
    }
}