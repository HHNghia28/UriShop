using Identity.Application.Interfaces;
using Identity.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.Features.Users.Commands.UpdateAccount
{
    public class UpdateUserCommandHandler(IUserRepository userRepository) : IRequestHandler<UpdateUserCommand>
    {
        private readonly IUserRepository _userRepository = userRepository;

        public async Task Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            await _userRepository.UpdateUser(new User
            {
                Id = request.Id,
                Email = request.Email,
                FullName = request.FullName,
                RoleId = request.RoleId,
            });

            await _userRepository.SaveAsync();
        }
    }
}
