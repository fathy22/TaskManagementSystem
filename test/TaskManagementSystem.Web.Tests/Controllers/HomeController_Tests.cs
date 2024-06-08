using System.Threading.Tasks;
using TaskManagementSystem.Models.TokenAuth;
using TaskManagementSystem.Web.Controllers;
using Shouldly;
using Xunit;

namespace TaskManagementSystem.Web.Tests.Controllers
{
    public class HomeController_Tests: TaskManagementSystemWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}