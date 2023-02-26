using MediatR.Pipeline;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.SharedLibrary.Common.Behaviours.Logging
{
    public class SimpleLoggingBehaviour<TRequest> : IRequestPreProcessor<TRequest> where TRequest : notnull
    {

        private readonly ILogger _logger;

        public SimpleLoggingBehaviour(ILogger logger)
        {
            _logger = logger;
        }

        public Task Process(TRequest request, CancellationToken cancellationToken)
        {
            var requestName = typeof(TRequest).Name;
            _logger.LogInformation("Request: {Name} with Request Info: {@Request}",
                requestName, request);

            return Task.CompletedTask;
        }
    }
}
