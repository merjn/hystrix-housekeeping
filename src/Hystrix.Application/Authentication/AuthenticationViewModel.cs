using MediatR;
using Hystrix.Application.Exceptions;

namespace Hystrix.Application.Authentication
{
    public class AuthenticationViewModel : IRequest<MediatR.Unit>
    {
        public string Username { get; init; }
        
        public string Password { get; init; }
    }
}