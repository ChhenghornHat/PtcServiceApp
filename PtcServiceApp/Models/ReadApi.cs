using System.Net;
using System.Net.Http.Headers;

namespace PtcServiceApp.Models;

public static class ReadApi
{
    private static string server;
    private static HttpResponseMessage Response;
    private static string errorMessage = "";

    public static HttpClient Client
    {
        get
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(server);
            client.Timeout = new TimeSpan(0, 0, 500);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", "UGx5aXQxMjM1QGdtYWlsLmNvbTpQYWx5eWEwMTA3");
            return client;
        }
    }

    public static HttpStatusCode Post(string requestURI, object value)
    {
        Response = Client.PostAsJsonAsync(requestURI, value).Result;
        return Response.StatusCode;

    }
}