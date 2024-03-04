using BlogPostBO.Model;
using BlogPostDAO;
using BlogPostRepository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogPostRepository
{
    public class BlogRepository : IBlogRepository
    {
        public async Task<bool> AddBlogPost(BlogPost BlogPost) => await BlogDAO.Instance.AddBlogPost(BlogPost);

        public async Task<bool> DeleteBlogPost(int id) => await BlogDAO.Instance.DeleteBlogPost(id);

        public async Task<bool> EditBlogPost(BlogPost BlogPost) => await BlogDAO.Instance.EditBlogPost(BlogPost);
        public async Task<List<BlogPost>> GetAll() => await BlogDAO.Instance.GetAll();

        public async Task<List<BlogPost>> GetBlogPostsListByFilter(Expression<Func<BlogPost, bool>>? filter = null)
            => await BlogDAO.Instance.GetBlogPostsListByFilter(filter);
        public async Task<BlogPost> GetBlogPostsByFilter(Expression<Func<BlogPost, bool>>? filter = null)
            => await BlogDAO.Instance.GetBlogPostsByFilter(filter);
    }
}
