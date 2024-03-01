using System;
using System.Collections.Generic;

namespace BlogPostBO.Model
{
    public partial class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BlogPostId { get; set; }

        public virtual BlogPost BlogPost { get; set; }
    }
}
