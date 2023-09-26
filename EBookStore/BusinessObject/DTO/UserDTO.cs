using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.DTO
{
    public class UserDTO
    {
        public string UserId { get; set; } = null!;
        public string EmailAddress { get; set; } = null!;
        public string? Source { get; set; }
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public string Role { get; set; } = null!;
        public string Publisher { get; set; } = null!;
        
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}",
               ApplyFormatInEditMode = true)]
        public DateTime HireDate { get; set; }

    }
}
