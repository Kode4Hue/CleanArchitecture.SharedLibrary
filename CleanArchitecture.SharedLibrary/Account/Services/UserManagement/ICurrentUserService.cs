namespace CleanArchitecture.SharedLibrary.Account.Services.UserManagement
{
    public interface ICurrentUserService
    {
        string? UserId { get; }
    }
}
