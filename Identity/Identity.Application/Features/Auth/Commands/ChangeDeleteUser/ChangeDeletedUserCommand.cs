using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.Features.Auth.Commands.ChangeDeleteUser
{
    public class ChangeDeletedUserCommand : IRequest
    {
        public Guid UserId { get; set; }
        public bool IsDeleted { get; set; }
    }
}
