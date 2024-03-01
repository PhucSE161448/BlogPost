using System;
using System.Collections.Generic;

namespace BlogPostBO.Model
{
    public partial class BlogPost
    {
        public BlogPost()
        {
            BlogPostComments = new HashSet<BlogPostComment>();
            BlogPostLikes = new HashSet<BlogPostLike>();
            Tags = new HashSet<Tag>();
        }

        public int Id { get; set; }
        public int AccountId { get; set; }
        public string Heading { get; set; }
        public string PageTitle { get; set; }
        public string Content { get; set; }
        public string ShortDescription { get; set; }
        public string ImageUrl { get; set; }
        public string UrlHandle { get; set; }
        public DateTime PublishedDate { get; set; }
        public bool? Visible { get; set; }

        public virtual Account Account { get; set; }
        public virtual ICollection<BlogPostComment> BlogPostComments { get; set; }
        public virtual ICollection<BlogPostLike> BlogPostLikes { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
    }
}
