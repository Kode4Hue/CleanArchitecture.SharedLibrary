using System.Threading.Tasks;

namespace CleanArchitecture.SharedLibrary.Account.Services.UserManagement
{
    public interface IIdentityService
    {
        Task<string> Login(string username, string password);

    }
}
