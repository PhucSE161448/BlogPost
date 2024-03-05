using BlogPostBO.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogPostDAO
{
    public class BlogDAO
    {
        private readonly BlogPost_PRN221Context _db = null;
        private static BlogDAO _instance = null;
        public static BlogDAO Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new BlogDAO();
                }
                return _instance;
            }
        }
        public BlogDAO()
        {
            _db = new BlogPost_PRN221Context();
        }
        public async Task<List<BlogPost>> GetAll() => await _db.BlogPosts.AsNoTracking().Include(x => x.Account).ToListAsync();
        public async Task<bool> AddBlogPost(BlogPost BlogPost)
        {
            try
            {
                await _db.BlogPosts.AddAsync(BlogPost);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public async Task<bool> DeleteBlogPost(int id)
        {
            BlogPost BlogPost = GetBlogPostById(id);
            try
            {
                _db.BlogPosts.Remove(BlogPost);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public BlogPost GetBlogPostById(int id)
        {
            return _db.BlogPosts.FirstOrDefault(x => x.Id == id);
        }

        public async Task<bool> EditBlogPost(BlogPost BlogPost)
        {
            var blog = await _db.BlogPosts.Include(x => x.Tags).AsNoTracking().FirstOrDefaultAsync(x => x.Id == BlogPost.Id);
            if (blog != null)
            {
                blog.Heading = BlogPost.Heading;
                blog.PageTitle = BlogPost.PageTitle;
                blog.Content = BlogPost.Content;
                blog.ShortDescription = BlogPost.ShortDescription;
                blog.ImageUrl = BlogPost.ImageUrl;
                blog.UrlHandle = BlogPost.UrlHandle;
                blog.PublishedDate = BlogPost.PublishedDate;
                blog.Visible = BlogPost.Visible;
                blog.AccountId = BlogPost.AccountId;

                if (blog.Tags != null && blog.Tags.Any())
                {
                    _db.Tags.RemoveRange(blog.Tags);
                    BlogPost.Tags.ToList().ForEach(x => x.BlogPostId = blog.Id);
                    await _db.Tags.AddRangeAsync(BlogPost.Tags);
                }
            }
            try
            {
                _db.BlogPosts.Update(BlogPost);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<List<BlogPost>> GetBlogPostsListByFilter(Expression<Func<BlogPost, bool>>? filter = null)
        {
            IQueryable<BlogPost> query = _db.BlogPosts;
            if (filter != null)
            {
                query = query.Include(x => x.Account).Where(filter);
            }
            return await query.ToListAsync();
        }

        public async Task<BlogPost> GetBlogPostsByFilter(Expression<Func<BlogPost, bool>>? filter = null)
        {
            IQueryable<BlogPost> query = _db.BlogPosts;
            if (filter != null)
            {
                query = query.AsNoTracking().Include(x => x.Account).Include(x => x.Tags).Where(filter);
            }
            return await query.FirstOrDefaultAsync();
        }
    }
}
