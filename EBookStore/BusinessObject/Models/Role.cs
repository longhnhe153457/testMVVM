using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BusinessObject.Models
{
    public partial class Role
    {
        public Role()
        {
            Users = new HashSet<User>();
        }

        public bool RoleId { get; set; }
        public string? RoleDesc { get; set; }

        [JsonIgnore]
        public virtual ICollection<User> Users { get; set; }
    }
}
