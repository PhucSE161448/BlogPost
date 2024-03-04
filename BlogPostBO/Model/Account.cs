using System;
using System.Collections.Generic;

namespace BlogPostBO.Model
{
    public partial class Account
    {
        public Account()
        {
            BlogPostComments = new HashSet<BlogPostComment>();
            BlogPostLikes = new HashSet<BlogPostLike>();
            BlogPosts = new HashSet<BlogPost>();
        }

        public int Id { get; set; }
        public string Email { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Role { get; set; } = null!;
        public bool? IsDelete { get; set; }

        public virtual ICollection<BlogPostComment> BlogPostComments { get; set; }
        public virtual ICollection<BlogPostLike> BlogPostLikes { get; set; }
        public virtual ICollection<BlogPost> BlogPosts { get; set; }
    }
}
