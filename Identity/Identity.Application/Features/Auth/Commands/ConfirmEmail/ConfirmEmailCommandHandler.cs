using Identity.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.Features.Auth.Commands.ConfirmEmail
{
    public class ConfirmEmailCommandHandler(IUserRepository userRepository) : IRequestHandler<ConfirmEmailCommand, bool>
    {
        private readonly IUserRepository _userRepository = userRepository;

        async Task<bool> IRequestHandler<ConfirmEmailCommand, bool>.Handle(ConfirmEmailCommand request, CancellationToken cancellationToken)
        {
            var confirm = await _userRepository.IsVerifyCode(request.UserId, request.Code);

            if (confirm) await _userRepository.ConfirmEmail(request.UserId);

            await _userRepository.SaveAsync();

            return confirm;
        }
    }
}
