using Newtonsoft.Json;
using static GetUsersResponse;

public class UserConfigService : IUserConfigService
{
    private readonly HttpClient _httpClient;

    public UserConfigService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<GetUsersResponse> GetAllUsersAsync()
    {
        var userResponse = new GetUsersResponse();

        var uri = "https://jsonplaceholder.typicode.com/users";

        var responseString = await _httpClient.GetStringAsync(uri);

        var users = JsonConvert.DeserializeObject<List<User>>(responseString);

        userResponse.Users = users;

        return userResponse;
    }

    public async Task<GetUsersResponse> GetUserByIdAsync(int id)
    {
        var userResponse = new GetUsersResponse();

        var uri = $"https://jsonplaceholder.typicode.com/users?id={id}";

        var responseString = await _httpClient.GetStringAsync(uri);

        var users = JsonConvert.DeserializeObject<List<User>>(responseString);

        userResponse.Users = users;

        return userResponse;
    }
}