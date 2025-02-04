using Identity.Application.DTO;
using Identity.Application.Exceptions;
using Identity.Application.Handlers;
using Identity.Application.Interfaces;
using Identity.Domain.Shares;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.Features.Auth.Commands.LoginUser
{
    public class LoginUserCommandHandler(IUserRepository userRepository, IPasswordHasher passwordHasher, ITokenService tokenService) : IRequestHandler<LoginUserCommand, LoginResponse>
    {
        private readonly IUserRepository _userRepository = userRepository;
        private readonly IPasswordHasher _passwordHasher = passwordHasher;
        private readonly ITokenService _tokenService = tokenService;

        public async Task<LoginResponse> Handle(LoginUserCommand command, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByEmailAsync(command.Email);

            if (user == null || !_passwordHasher.VerifyPassword(command.Password, user.PasswordHash)) throw new InvalidCredentialsException("Invalid credentials");

            if (!user.IsEmailConfirmed) throw new InvalidCredentialsException("Please confirm email");

            var accessToken = _tokenService.GenerateJwtToken(user);
            var refreshToken = _tokenService.GenerateRefreshToken(64);

            await _userRepository.SaveRefreshToken(user.Id, refreshToken, DateUtility.GetCurrentDateTime().AddDays(1));
            await _userRepository.SaveAsync();

            return new LoginResponse
            {
                Email = user.Email,
                FullName = user.FullName,
                AccessToken = accessToken,
                RefreshToken = refreshToken
            };
        }
    }
}
