using Identity.Application.Exceptions;
using Identity.Application.Handlers;
using Identity.Application.Interfaces;
using Identity.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Identity.Application.Features.Auth.Commands.RegisterUser
{
    public class RegisterUserCommandHandler(IUserRepository userRepository, IPasswordHasher passwordHasher, IEmailSender emailSender, IConfiguration configuration) : IRequestHandler<RegisterUserCommand>
    {
        private readonly IUserRepository _userRepository = userRepository;
        private readonly IPasswordHasher _passwordHasher = passwordHasher;
        private readonly IEmailSender _emailSender = emailSender;
        private readonly IConfiguration _configuration = configuration;

        async Task IRequestHandler<RegisterUserCommand>.Handle(RegisterUserCommand command, CancellationToken cancellationToken)
        {
            var existingUser = await _userRepository.GetByEmailAsync(command.Email);

            if (existingUser != null) throw new InvalidCredentialsException("User already exists");

            Guid userId = Guid.NewGuid();

            var user = new User
            {
                Id = userId,
                FullName = command.FullName,
                Email = command.Email,
                PasswordHash = _passwordHasher.HashPassword(command.Password),
                RoleId = command.RoleId
            };

            await _userRepository.AddAsync(user);

            string code = await _userRepository.GenerateCodeConfirmEmail(userId);

            await _userRepository.SaveAsync();

            string url = _configuration["Base:Url"] ?? string.Empty;
            string content = url + "/api/auth/confirm-email?userId=" + userId + "&code=" + code;

            await _emailSender.SendEmailAsync(command.Email, "Confirm email", content);
        }
    }
}
