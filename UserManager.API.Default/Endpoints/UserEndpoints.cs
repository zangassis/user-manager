public static class UserEndpoints
{
    public static void MapUsersEndpoints(this WebApplication app)
    {
        app.MapGet("/v1/users", GetAllUsers);
        app.MapGet("/v1/users/{id}", GetUserById);
    }

    public static void AddUserServices(this IServiceCollection service)
    {
        service.AddHttpClient<IUserConfigService, UserConfigService>();
    }

    internal static IResult GetAllUsers(IUserConfigService service)
    {
        var users = service.GetAllUsersAsync().Result.Users;

        return users is not null ? Results.Ok(users) : Results.NotFound();
    }

    internal static IResult GetUserById(IUserConfigService service, int id)
    {
        var user = service.GetUserByIdAsync(id).Result.Users.SingleOrDefault();

        return user is not null ? Results.Ok(user) : Results.NotFound();
    }
}