using IdentityModel.Client;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaylocityHelper;
using PaylocityToRecognize.Model;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;

namespace ConnectToPaylocity.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaylocityToRecognizeServiceController : ControllerBase
    {
        [HttpGet(Name = "GetEmployees")]
        public async Task<IEnumerable<RecognizeEmployee>> GetEmployees()
        {
            var recognizeEmployees = new List<RecognizeEmployee>();
            var paylocityClient = PaylocityHttpClient.Create();
            if (paylocityClient.IsValid())
            {
                var emps = await paylocityClient.GetPaylocityEmployees();

                foreach (var employee in emps)
                {
               
                    var employeeDetail = await paylocityClient.GetPaylocityEmployeeDetail(employee.EmployeeId);
                    if(employeeDetail.Status!=null)
                    {
                        if(employeeDetail.Status.EmployeeStatus == "A")
                        {
                            var partimeJobTitle = employeeDetail.DepartmentPosition.JobTitle.Replace("-", "");
                            partimeJobTitle = partimeJobTitle.Replace(" ", "");

                            if (!partimeJobTitle.ToLower().StartsWith("parttime"))
                            {
                                var recognizeEmployee = RecognizeUtility.Map(employeeDetail);

                                if (!string.IsNullOrWhiteSpace(employeeDetail.DepartmentPosition.SupervisorEmployeeId))
                                {
                                    var employeeManagerDetail = await paylocityClient.GetPaylocityEmployeeDetail(employeeDetail.DepartmentPosition.SupervisorEmployeeId);
                                    var recognizeManager = RecognizeUtility.Map(employeeManagerDetail);
                                    recognizeEmployee.ManagerEmail = recognizeManager.Email;
                                }

                                recognizeEmployees.Add(recognizeEmployee);
                            }
                        }
                    }
                    
                }
            }

            return recognizeEmployees;
        }
    }
}
