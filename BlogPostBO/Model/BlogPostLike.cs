using System;
using System.Collections.Generic;
namespace BlogPostBO.Model
{
    public partial class BlogPostLike
    {
        public int Id { get; set; }
        public int BlogPostId { get; set; }
        public int AccountId { get; set; }

        public virtual Account Account { get; set; } = null!;
        public virtual BlogPost BlogPost { get; set; } = null!;
    }
}
