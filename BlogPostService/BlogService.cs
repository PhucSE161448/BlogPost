using BlogPostRepository.Interface;
using BlogPostRepository;
using BlogPostService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogPostBO.Model;
using System.Linq.Expressions;

namespace BlogPostService
{
    public class BlogService : IBlogService
    {
        private readonly IBlogRepository _repo = null;
        public BlogService()
        {
            _repo = new BlogRepository();
        }

        public async Task<bool> AddBlogPost(BlogPost BlogPost) => await _repo.AddBlogPost(BlogPost);

        public async Task<bool> DeleteBlogPost(int id) => await _repo.DeleteBlogPost(id);

        public async Task<bool> EditBlogPost(BlogPost BlogPost) => await _repo.EditBlogPost(BlogPost);

        public async Task<List<BlogPost>> GetAll() => await  _repo.GetAll();

        public async Task<List<BlogPost>> GetBlogPostsListByFilter(Expression<Func<BlogPost, bool>>? filter = null)
            => await _repo.GetBlogPostsListByFilter(filter);
        public async Task<BlogPost> GetBlogPostsByFilter(Expression<Func<BlogPost, bool>>? filter = null)
            => await _repo.GetBlogPostsByFilter(filter);
    }
}
