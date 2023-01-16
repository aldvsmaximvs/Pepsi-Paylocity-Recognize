using PaylocityHelper;

namespace PaylocityAccessTest
{
    public class GetEmployeeTest
    {
        [Fact]
        public void GetEmployeeFromPaylocity()
        {
            var paylocityService = new ConnectToPaylocity.Service.Controllers.PaylocityToRecognizeServiceController();

            var result = paylocityService.GetEmployees();
            Assert.NotNull(result);
        }

        //[Fact]
        //public void GetEmployeeDetailFromPaylocity()
        //{
        //    var paylocityService = new ConnectToPaylocity.Service.Controllers.PaylocityToRecognizeServiceController();

        //    var result = paylocityService.GetEmployees();
        //    Assert.NotNull(result);
        //}


        [Fact]
        public void GetTeamNameFromLocationDecorah()
        {
            string location = "Gillette Pepsi Decorah";

            string teamName = StringUtility.GetTeamNameFromLocation(location);

            Assert.Equal("Decorah", teamName);
        }

        [Fact]
        public void GetRoleNameFromPositionCode()
        {
            string positionCode = "1100";

            string roleName = StringUtility.GetRoleNameFromPositionCode(positionCode);

            Assert.Equal("Mnt Dew", roleName);
        }
    }
}