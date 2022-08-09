using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.SharedLibrary.Account.Services
{
    public interface IIdentityService
    {
        Task<string> Login(string username, string password);

    }
}
