using Dapper;
using Identity.Application.DTO;
using Identity.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.Features.Users.Queries.GetUser
{
    public class GetUserQueryHandler(IUserRepository userRepository) : IRequestHandler<GetUserQuery, UserResponse>
    {
        private readonly IUserRepository _userRepository = userRepository;

        public async Task<UserResponse> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            return await _userRepository.GetUser(request.Id);
        }
    }
}
