using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace ClinicManagementSystem.Tests.ClientTests
{
    public class ClientTests
    {
        private readonly TestContext _testContext;

        public ClientTests()
        {
            _testContext = new TestContext();
        }

        [Fact]
        public void Test_IndexPage_LoadsSuccessfully()
        {
            // Arrange
            var cut = _testContext.RenderComponent<Pages.Index>();
            
            // Act
            var content = cut.Markup;

            // Assert
            Assert.Contains("Welcome to the Clinic Management System", content);
        }

        [Fact]
        public void Test_LoginPage_LoadsSuccessfully()
        {
            // Arrange
            var cut = _testContext.RenderComponent<Pages.Login>();
            
            // Act
            var content = cut.Markup;

            // Assert
            Assert.Contains("Login", content);
        }

        [Fact]
        public void Test_NewPatientRegistrationPage_LoadsSuccessfully()
        {
            // Arrange
            var cut = _testContext.RenderComponent<Pages.Receptionist.NewPatientRegistration>();
            
            // Act
            var content = cut.Markup;

            // Assert
            Assert.Contains("Register New Patient", content);
        }

        [Fact]
        public void Test_DoctorDashboard_LoadsSuccessfully()
        {
            // Arrange
            var cut = _testContext.RenderComponent<Pages.Doctor.Dashboard>();
            
            // Act
            var content = cut.Markup;

            // Assert
            Assert.Contains("Latest Patients", content);
        }

        [Fact]
        public void Test_ManageClinicsPage_LoadsSuccessfully()
        {
            // Arrange
            var cut = _testContext.RenderComponent<Pages.Admin.ManageClinics>();
            
            // Act
            var content = cut.Markup;

            // Assert
            Assert.Contains("Manage Clinics", content);
        }
    }
}