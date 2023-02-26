using CleanArchitecture.SharedLibrary.Account.Services.UserManagement;
using MediatR.Pipeline;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.SharedLibrary.Common.Behaviours.Logging
{
    public class UserRequestLoggingBehaviour<TRequest> : IRequestPreProcessor<TRequest> where TRequest : notnull
    {
        private readonly ILogger _logger;
        private readonly ICurrentUserService _currentUserService;
        private readonly ISimpleIdentityService _identityService;

        public UserRequestLoggingBehaviour(ILogger logger,
            ICurrentUserService currentUserService, ISimpleIdentityService identityService)
        {
            _logger = logger;
            _currentUserService = currentUserService;
            _identityService = identityService;
        }

        public async Task Process(TRequest request, CancellationToken cancellationToken)
        {
            var requestName = typeof(TRequest).Name;
            var userId = _currentUserService.UserId ?? string.Empty;
            string userName = string.Empty;

            if (!string.IsNullOrEmpty(userId))
            {
                userName = await _identityService.GetUserNameAsync(userId);
            }

            _logger.LogInformation("Request: {Name} made by user with UserId: {@UserId} & Username: {@UserName}. Request Info: {@Request}",
                requestName, userId, userName, request);
        }
    }
}
