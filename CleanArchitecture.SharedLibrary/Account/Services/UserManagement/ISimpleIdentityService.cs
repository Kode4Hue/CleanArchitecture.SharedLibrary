using CleanArchitecture.SharedLibrary.Common.DTOs;
using System.Threading.Tasks;

namespace CleanArchitecture.SharedLibrary.Account.Services.UserManagement
{
    public interface ISimpleIdentityService
    {
        Task<string> GetUserNameAsync(string userId);
        Task<bool> IsInRoleAsync(string userId, string role);
        Task<bool> AuthorizeAsync(string userId, string policyName);
        Task<ResultDto> DeleteUserAsync(string userId);
    }
}
