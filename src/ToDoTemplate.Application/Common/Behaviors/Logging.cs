using MediatR;
using Serilog;
using ToDoTemplate.Application.Common.Interfaces;

namespace ToDoTemplate.Application.Common.Behaviors
{

    public class Logging<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        public readonly ICurrentUserService _user;
        public Logging(ICurrentUserService user)
        {
            _user = user;
        }
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var requestName = typeof(TRequest).Name;
            var userId = _user.UserId;

            Log.Information("Request: {Name} {@UserId} {@Request}",
                requestName, userId, request);
            return await next();
        }
    }

}
