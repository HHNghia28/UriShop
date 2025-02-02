using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.Features.Auth.Commands.ResetPassword
{
    public class ResetPasswordCommand : IRequest
    {
        public Guid UserId { get; set; }
        public string Password { get; set; }
        public string Code { get; set; }
    }
}
