using System;
using System.Collections.Generic;

namespace BlogPostBO.Model
{
    public partial class BlogPostComment
    {
        public int Id { get; set; }
        public string Description { get; set; } = null!;
        public int BlogPostId { get; set; }
        public int AccountId { get; set; }
        public DateTime DateAdded { get; set; }

        public virtual Account Account { get; set; } = null!;
        public virtual BlogPost BlogPost { get; set; } = null!;
    }
}
