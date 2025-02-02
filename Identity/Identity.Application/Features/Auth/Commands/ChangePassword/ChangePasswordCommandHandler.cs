using Identity.Application.Exceptions;
using Identity.Application.Handlers;
using Identity.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.Features.Auth.Commands.ChangePassword
{
    public class ChangePasswordCommandHandler(IUserRepository userRepository, IPasswordHasher passwordHasher) : IRequestHandler<ChangePasswordCommand>
    {
        private readonly IUserRepository _userRepository = userRepository;
        private readonly IPasswordHasher _passwordHasher = passwordHasher;

        public async Task Handle(ChangePasswordCommand command, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByEmailAsync(command.Email);

            if (user == null || !_passwordHasher.VerifyPassword(command.OldPassword, user.PasswordHash)) throw new InvalidCredentialsException("Invalid credentials");

            if (!user.IsEmailConfirmed) throw new InvalidCredentialsException("Please confirm email");

            await _userRepository.ChangePassword(user.Id, _passwordHasher.HashPassword(command.NewPassword));

            await _userRepository.SaveAsync();
        }
    }
}
