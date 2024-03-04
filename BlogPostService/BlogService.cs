using BlogPostRepository.Interface;
using BlogPostRepository;
using BlogPostService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogPostBO.Model;

namespace BlogPostService
{
    public class BlogService : IBlogService
    {
        private readonly IBlogRepository _repo = null;
        public BlogService()
        {
            _repo = new BlogRepository();
        }

        public bool AddBlogPost(BlogPost BlogPost) => _repo.AddBlogPost(BlogPost);

        public bool DeleteBlogPost(int id) => _repo.DeleteBlogPost(id);

        public bool EditBlogPost(BlogPost BlogPost) => (_repo.EditBlogPost(BlogPost));

        public List<BlogPost> GetAll() => _repo.GetAll();
    }
}
