using BlogPostBO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPostRepository.Interface
{
    public interface IBlogRepository
    {
        public List<BlogPost> GetAll() ;
        public bool AddBlogPost(BlogPost BlogPost);
        public bool DeleteBlogPost(int id);
        public bool EditBlogPost(BlogPost BlogPost);
    }
}
