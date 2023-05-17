
using CloudCustomers.Domain.Domain;
using CloudCustomers.Services.Interfaces;
using System.Net.Http.Json;

namespace CloudCustomers.Services.Services;

public class UserService : IUserService
{
    private readonly HttpClient _httpClient;

    public UserService(HttpClient httpClient)
    {
        this._httpClient = httpClient;
    }
    public async Task<IEnumerable<User>> ListUsers()
    {
        var response = await _httpClient.GetAsync("http://example.com.br");
        if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
        {
            return new List<User> { };

        }
        var responseContent = response.Content;
        var allUsers = await responseContent.ReadFromJsonAsync<List<User>>();
        return allUsers.ToList();
    }
}
