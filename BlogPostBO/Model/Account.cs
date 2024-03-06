using System;
using System.Collections.Generic;

namespace BlogPostBO.Model
{
    public partial class Account
    {
        public Account()
        {
            BlogPosts = new HashSet<BlogPost>();
        }

        public int Id { get; set; }
        public string Email { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Role { get; set; } = null!;
        public bool? IsDelete { get; set; }

        public virtual ICollection<BlogPost> BlogPosts { get; set; }
    }
}
