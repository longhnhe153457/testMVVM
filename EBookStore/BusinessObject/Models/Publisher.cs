using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BusinessObject.Models
{
    public partial class Publisher
    {
        public Publisher()
        {
            Books = new HashSet<Book>();
            Users = new HashSet<User>();
        }

        public string PubId { get; set; } = null!;
        public string PublisherName { get; set; } = null!;
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Country { get; set; }

        [JsonIgnore]
        public virtual ICollection<Book> Books { get; set; }

        [JsonIgnore]
        public virtual ICollection<User> Users { get; set; }
    }
}
