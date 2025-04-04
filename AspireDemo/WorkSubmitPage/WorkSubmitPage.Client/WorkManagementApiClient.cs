using System.Net.Http;
using System.Text.Json;
using System.Text;

namespace WorkSubmitPage.Client
{
    public class WorkManagementApiClient
    {
        private const string WorkUnitRelativeUrl = "/WorkUnit/";

        private readonly HttpClient _client;

        public WorkManagementApiClient(HttpClient client)
        {
            _client = client;
        }

        internal void PostWork(WorkUnitPostDto workUnitDto)
        {
            // Serialize the request object to JSON
            var jsonBody = JsonSerializer.Serialize(workUnitDto);
            var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

            // Send the POST request
            var postTask = _client.PostAsync(WorkUnitRelativeUrl, content);
            postTask.Wait();

            var response = postTask.Result;
        }

        internal IEnumerable<WorkResult> GetWorkResults()
        {
            // Send the POST request
            var postTask = _client.GetAsync(WorkUnitRelativeUrl);
            postTask.Wait();

            var response = postTask.Result;

            // Ensure the response is successful
            response.EnsureSuccessStatusCode();

            // Read the response body as a string
            var responseBody = response.Content.ReadAsStream();

            // Deserialize the response JSON into a MyResponse object
            var responseObject = JsonSerializer.Deserialize<WorkResult[]>(responseBody, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            return responseObject;
        }

        internal static WorkManagementApiClient CreateClient(string baseAddress)
        {
            HttpClient httpClinet = new HttpClient() { BaseAddress = new Uri(baseAddress) };
            return new WorkManagementApiClient(httpClinet);
        }
    }
}
