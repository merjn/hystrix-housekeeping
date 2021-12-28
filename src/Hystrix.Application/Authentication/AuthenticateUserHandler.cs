using System;
using System.Threading;
using System.Threading.Tasks;
using Hystrix.Application.Exceptions;
using Hystrix.Application.Hasher;
using Hystrix.Application.Repository;
using Hystrix.Application.Service;
using Hystrix.Application.Specifications;
using MediatR;
using Hystrix.Domain.Entity.UserAggregate;
using Hystrix.Domain.Permission;
using Unit = MediatR.Unit;

namespace Hystrix.Application.Authentication
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

            await _authenticationService.AuthenticateAsync(user.Username);

            return Unit.Value;
        }
    }
}