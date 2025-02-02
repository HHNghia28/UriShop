using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Identity.Application.Features.Users.Commands.UpdateAccount
{
    public class UpdateUserCommand : IRequest
    {
        [JsonIgnore]
        public Guid Id { get; set; }

        [Required]
        [StringLength(50)]
        public string FullName { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        public int RoleId { get; set; }
    }
}
