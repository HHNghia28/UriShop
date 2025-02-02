using Identity.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.DTO
{
    public class UserResponse
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }

        public bool IsEmailConfirmed { get; set; } = false;

        public bool IsDeleted { get; set; } = false;

        public int RoleId { get; set; }
        public string Role { get; set; }
    }
}
