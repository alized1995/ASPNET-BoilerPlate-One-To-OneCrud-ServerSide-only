using System.Threading.Tasks;
using OneToOneCrud.Models.TokenAuth;
using OneToOneCrud.Web.Controllers;
using Shouldly;
using Xunit;

namespace OneToOneCrud.Web.Tests.Controllers
{
    public class HomeController_Tests: OneToOneCrudWebTestBase
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