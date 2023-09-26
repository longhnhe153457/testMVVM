using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BusinessObject.Models
{
    public partial class Author
    {
        public Author()
        {
            BookAuthors = new HashSet<BookAuthor>();
        }

        public string AuthorId { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string? FullName
        {
            get
            {
                return LastName + " " + FirstName;
            }
        }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Zip { get; set; }
        public string? EmailAddress { get; set; }
        
        [JsonIgnore]
        public virtual ICollection<BookAuthor> BookAuthors { get; set; }
    }
}
