using System;
using System.Threading;
using System.Threading.Tasks;
using Correlator.Core;
using MediatR;

namespace Correlator.Providers.MediatR.Core
{
    /// <summary>
    /// A MediatR behaviour providing data from requests to <see cref="CorrelationService"/>.
    /// </summary>
    /// <typeparam name="TRequest">MediatR Request</typeparam>
    /// <typeparam name="TResponse">MediatR Response</typeparam>
    public class CorrelationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : notnull
    {
        private readonly ICorrelationService _correlationService;
        private readonly ICorrelationMap<TRequest>? _correlationMap;

        public CorrelationBehaviour(
            ICorrelationService correlationService,
            ICorrelationMap<TRequest>? correlationMap)
        {
            _correlationService = correlationService ?? throw new ArgumentNullException(nameof(correlationService));
            _correlationMap = correlationMap;
        }

        public async Task<TResponse> Handle(
            TRequest request,
            CancellationToken cancellationToken,
            RequestHandlerDelegate<TResponse> next)
        {
            if (request is null) throw new ArgumentNullException(nameof(request));

            if (!(_correlationMap is null))
            {
                //TODO: Implement
            }

            return await next().ConfigureAwait(false);
        }
    }
}