using BlogPostRepository.Interface;
using BlogPostRepository;
using BlogPostService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPostService
{
    public class BlogService : IBlogService
    {
        private readonly IBlogRepository _repo = null;
        public BlogService()
        {
            _repo = new BlogRepository();
        }
    }
}
