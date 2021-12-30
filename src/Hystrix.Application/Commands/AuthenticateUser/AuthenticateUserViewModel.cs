using MediatR;
using Hystrix.Application.Exceptions;

namespace Hystrix.Application.Commands.AuthenticateUser
{
    public class AuthenticateUserViewModel : IRequest<Unit>
    {
        public string Username { get; init; }
        
        public string Password { get; init; }
    }
}