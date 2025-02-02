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

namespace Identity.Application.Features.Auth.Commands.ResendEmail
{
    public class ResendConfirmEmailCommandHandler(IUserRepository userRepository, IPasswordHasher passwordHasher, IEmailSender emailSender, IConfiguration configuration) : IRequestHandler<ResendConfirmEmailCommand>
    {
        private readonly IUserRepository _userRepository = userRepository;
        private readonly IPasswordHasher _passwordHasher = passwordHasher;
        private readonly IEmailSender _emailSender = emailSender;
        private readonly IConfiguration _configuration = configuration;

        async Task IRequestHandler<ResendConfirmEmailCommand>.Handle(ResendConfirmEmailCommand command, CancellationToken cancellationToken)
        {
            var existingUser = await _userRepository.GetByEmailAsync(command.Email);

            if (existingUser == null) throw new NotFoundException("User not found");

            string code = await _userRepository.GenerateCodeConfirmEmail(existingUser.Id);

            await _userRepository.SaveAsync();

            string url = _configuration["Base:Url"] ?? string.Empty;
            string content = url + "/api/auth/confirm-email?userId=" + existingUser.Id + "&code=" + code;

            await _emailSender.SendEmailAsync(existingUser.Email, "Confirm email", content);
        }
    }
}
