using System.Net;

namespace Laboratory.Core;
public class TestCore
{
    private readonly IHttpClientFactory _httpClientFactory;
    public TestCore(IHttpClientFactory httpClientFactory){
          _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
    }

    public async Task<bool> Run() {
        try
        {
            var response = _httpClientFactory.CreateClient().GetAsync("https://www.googleapis.com/oauth2/v3/certs").GetAwaiter().GetResult();
            
            if (response.StatusCode == HttpStatusCode.OK) 
            {
                string body = await response.Content.ReadAsStringAsync();
                Console.Write(body);
            }
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }

    }
}