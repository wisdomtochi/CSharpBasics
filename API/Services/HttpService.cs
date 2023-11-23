namespace API.Services
{
    public class HttpService
    {
        private readonly HttpClient _client;
        public HttpService()
        {
            _client = new HttpClient();
        }

        public async Task<string> Get(string uri)
        {
            using HttpResponseMessage message = await _client.GetAsync(uri);
            return await message.Content.ReadAsStringAsync();
        }
    }
}
