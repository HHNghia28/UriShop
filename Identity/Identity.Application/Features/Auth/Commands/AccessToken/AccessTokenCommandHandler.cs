using Identity.Application.DTO;
using Identity.Application.Exceptions;
using Identity.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.Features.Auth.Commands.AccessToken
{
    public class AccessTokenCommandHandler(IUserRepository userRepository, ITokenService tokenService) : IRequestHandler<AccessTokenCommand, LoginResponse>
    {
        private readonly IUserRepository _userRepository = userRepository;
        private readonly ITokenService _tokenService = tokenService;

        public async Task<LoginResponse> Handle(AccessTokenCommand command, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByRefreshToken(command.RefreshToken);

            if (user == null) throw new InvalidCredentialsException("Invalid refresh token");

            var accessToken = _tokenService.GenerateJwtToken(user);

            return new LoginResponse
            {
                Email = user.Email,
                FullName = user.FullName,
                AccessToken = accessToken,
                RefreshToken = command.RefreshToken
            };
        }
    }
}
