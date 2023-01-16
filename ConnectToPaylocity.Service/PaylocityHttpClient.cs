using IdentityModel.Client;
using IdentityServer4.Models;
using Newtonsoft.Json;
using PaylocityToRecognize.Model;
using System.Net.Http.Headers;

namespace ConnectToPaylocity.Service
{
    public class PaylocityHttpClient
    {
        private static HttpClient m_client;
        public static PaylocityHttpClient Create()
        {
            m_client = new HttpClient();
            return new PaylocityHttpClient();
        }

        public bool IsValid()
        {
            return true;
        }

        private async Task<TokenResponse> GetIdentityTokenResponse()
        {
            return await m_client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            {
                Address = "https://api.paylocity.com/IdentityServer/connect/token",
                ClientId = "xfjriqEWiUmGnovNi4e7/S04NTg1MzE5MzcyNTk3OTk1ODE3",
                ClientSecret = "dotdsX//7/+8uvZkQDzb6og95jboaPmyofKYb6AqG+aXy7TPxFzmlzzGCYyih4ND1X4qYiwNxWpH4i7ZC4ildQ==",
                Scope = "WebLinkAPI",
            });
        }
        public async Task<PaylocityEmployee[]> GetPaylocityEmployees() {

            int pageSize = 5000;
            int pageIndex = 0;
            var identityServerResponse = await GetIdentityTokenResponse();
            m_client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", identityServerResponse.AccessToken);
            var employees = await m_client.GetFromJsonAsync<PaylocityEmployee[]>($"https://api.paylocity.com/api/v2/companies/109021/employees?pageSize={pageSize}&page={pageIndex}");

            return employees;
        }

        public async Task<PaylocityEmployeeDetail> GetPaylocityEmployeeDetail(string employeeId)
        {
            PaylocityEmployeeDetail employeeDetail = new PaylocityEmployeeDetail(); 
            if(employeeId == null)
                return new PaylocityEmployeeDetail();

            var identityServerResponse = await GetIdentityTokenResponse();

            Console.WriteLine($"Getting detail of employee {employeeId}");
            //var employeeDetail = await m_client.GetFromJsonAsync<PaylocityEmployeeDetail>($"https://api.paylocity.com/api/v2/companies/109021/employees/{employeeId}");
            var response = await m_client.GetAsync($"https://api.paylocity.com/api/v2/companies/109021/employees/{employeeId}");
            if (response.IsSuccessStatusCode)
            {
                var stringData = await response.Content.ReadAsStringAsync();
                employeeDetail = JsonConvert.DeserializeObject<PaylocityEmployeeDetail>(stringData);
            }
            return employeeDetail;
        }
    }
}
