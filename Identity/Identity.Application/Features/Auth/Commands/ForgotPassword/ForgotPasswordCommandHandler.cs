using Identity.Application.Exceptions;
using Identity.Application.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.Features.Auth.Commands.ForgotPassword
{
    public class ForgotPasswordCommandHandler(IUserRepository userRepository, IEmailSender emailSender, IConfiguration configuration) : IRequestHandler<ForgotPasswordCommand>
    {
        private readonly IUserRepository _userRepository = userRepository;
        private readonly IEmailSender _emailSender = emailSender;
        private readonly IConfiguration _configuration = configuration;

        public async Task Handle(ForgotPasswordCommand request, CancellationToken cancellationToken)
        {
            var existingUser = await _userRepository.GetByEmailAsync(request.Email);

            if (existingUser == null) throw new NotFoundException("User not found");

            string code = await _userRepository.GenerateCodeConfirmEmail(existingUser.Id);

            await _userRepository.SaveAsync();

            string url = _configuration["Base:UrlClient"] ?? string.Empty;
            string content = url + "/api/auth/reset-password?userId=" + existingUser.Id + "&code=" + code;

            await _emailSender.SendEmailAsync(existingUser.Email, "Forgot password", content);
        }
    }
}
