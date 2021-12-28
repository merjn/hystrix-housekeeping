using LanguageExt;
using MediatR;
using Skyr.Application.Exceptions;

namespace Skyr.Application.Authentication
{
    public class AuthenticationViewModel : IRequest<MediatR.Unit>
    {
        public string Username { get; init; }
        
        public string Password { get; init; }
    }
}