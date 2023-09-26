﻿using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class User
    {
        public string? UserId { get; set; } = null!;
        public string EmailAddress { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string? Source { get; set; }
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public bool RoleId { get; set; }
        public string PubId { get; set; } = null!;
        public DateTime HireDate { get; set; }

        public virtual Publisher Pub { get; set; } = null!;
        public virtual Role Role { get; set; } = null!;
    }
}
