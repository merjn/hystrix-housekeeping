using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Skyr.Application.Exceptions;
using Skyr.Application.Hasher;
using Skyr.Application.Repository;
using Skyr.Application.Service;
using Skyr.Application.Specifications;
using Skyr.Domain.Entity.UserAggregate;
using Skyr.Domain.Permission;
using Unit = MediatR.Unit;

namespace Skyr.Application.Authentication
{
    public sealed class AuthenticateUserHandler : IRequestHandler<AuthenticationViewModel, Unit>
    {
        private readonly IAsyncHasher _hasher;
        private readonly IAuthenticationService _authenticationService;
        private readonly IAsyncRepository<User> _userRepository;

        public AuthenticateUserHandler(
            IAsyncHasher hasher, 
            IAuthenticationService authenticationService, 
            IAsyncRepository<User> userRepository) 
        {
            _hasher = hasher;
            _authenticationService = authenticationService;
            _userRepository = userRepository;
        }

        public async Task<Unit> Handle(AuthenticationViewModel request, CancellationToken cancellationToken)
        {
            var hashedPassword = await _hasher.HashAsync(request.Password);
            
            var spec = new UserByUsernameAndPasswordSpecification(request.Username, hashedPassword);
            var user = await _userRepository.FindAsync(spec, cancellationToken);
            if (user == null)
            {
                throw new UserCredentialsNotFoundException("Username and password combination not found");
            }
            
            if (!user.HasPermission(PermissionEnum.CanEnterHk))
            {
                throw new PermissionException("User is not allowed to enter the housekeeping");
            }

            await _authenticationService.AuthenticateAsync(user);

            return Unit.Value;
        }
    }
}