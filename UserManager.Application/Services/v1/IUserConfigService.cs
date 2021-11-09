public interface IUserConfigService
{
    public Task<GetUsersResponse> GetAllUsersAsync();
    public Task<GetUsersResponse> GetUserByIdAsync(int id);
}