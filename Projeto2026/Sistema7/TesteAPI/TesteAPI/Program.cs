using System.Net.Http.Json;

string baseAddress = "https://www.microleme.com/ServiceHubTeste";


var idLoja = "1332";
var tokenUrl = $"https://www.microleme.com/servicehubteste/api/b2b/v1/lojas/{1332}/auth/token";
using var client = new HttpClient();

var request = new HttpRequestMessage(HttpMethod.Post, tokenUrl);
var formParams = new Dictionary<string, string>
{
    ["grant_type"] = "client_credentials",
    ["client_id"] = "2kCLgDSaMG9eCeeK7WPZ",
    ["client_secret"] = "#9Mz4zJd1-EGuh-ncj09$",
};
request.Content = new FormUrlEncodedContent(formParams);

using var response = await client.SendAsync(request);

if (response.StatusCode == System.Net.HttpStatusCode.OK)
{
    var jsonResult = await response.Content.ReadAsStringAsync();
    Console.WriteLine(jsonResult);
}
else
{
    Console.WriteLine(response.StatusCode);
}

Console.ReadKey();