using BlogPostBO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public List<BlogPost> GetAll() => _db.BlogPosts.ToList();
        public bool AddBlogPost(BlogPost BlogPost)
        {
            try
            {
                _db.Add(BlogPost);
                _db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool DeleteBlogPost(int id)
        {
            BlogPost BlogPost = GetBlogPostById(id);
            try
            {
                _db.BlogPosts.Remove(BlogPost);
                _db.SaveChanges();
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

        public bool EditBlogPost(BlogPost BlogPost)
        {
            BlogPost de = GetBlogPostById(BlogPost.Id);
            try
            {
                _db.Update(de);
                _db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
