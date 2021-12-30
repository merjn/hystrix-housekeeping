using System;
using System.Threading;
using System.Threading.Tasks;
using Hystrix.Application.Exceptions;
using Hystrix.Application.Specifications;
using Hystrix.Domain.Authentication;
using MediatR;
using Hystrix.Domain.Entity.UserAggregate;
using Hystrix.Domain.Hasher;
using Hystrix.Domain.Permission;
using Hystrix.Domain.Repository;
using Unit = MediatR.Unit;

namespace Hystrix.Application.Commands.AuthenticateUser
{
    public sealed class AuthenticateUserHandler : IRequestHandler<AuthenticateUserViewModel, Unit>
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

        public async Task<Unit> Handle(AuthenticateUserViewModel request, CancellationToken cancellationToken)
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