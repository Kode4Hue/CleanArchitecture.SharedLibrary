
namespace CleanArchitecture.SharedLibrary.Account.Services
{
    public interface ICurrentUserService
    {
        string? UserId { get; }
    }
}
