using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.DTO
{
    public class CreateUpdateUserDTO
    {
        public string? UserId { get; set; }
        public string EmailAddress { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string? Source { get; set; }
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public bool? RoleId { get; set; }
        public string? PubId { get; set; } = null!;
        public DateTime? HireDate { get; set; }
    }
}
