using System.Collections.Generic;
using System.Threading.Tasks;
using RestSharp;

namespace TaskManagerClient.Models
{
    public class StatusRepository
    {
        private RestClientOptions _options;

        public StatusRepository(RestClientOptions options)
        {
            _options = options;
        }

        public async Task<List<Status>> GetAsync()
        {
            var client = new RestClient(_options);

            var result = await client.GetJsonAsync<List<Status>>("api/status");

            return result;
        }
    }
}