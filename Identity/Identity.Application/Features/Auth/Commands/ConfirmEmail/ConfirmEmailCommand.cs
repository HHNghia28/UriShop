﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.Features.Auth.Commands.ConfirmEmail
{
    public class ConfirmEmailCommand : IRequest<bool>
    {
        public Guid UserId { get; set; }
        public string Code { get; set; }
    }
}
