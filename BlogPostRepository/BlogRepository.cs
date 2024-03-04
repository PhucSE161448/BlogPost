using BlogPostBO.Model;
using BlogPostDAO;
using BlogPostRepository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPostRepository
{
    public class BlogRepository : IBlogRepository
    {
        public bool AddBlogPost(BlogPost BlogPost) => BlogDAO.Instance.AddBlogPost(BlogPost);

        public bool DeleteBlogPost(int id) => BlogDAO.Instance.DeleteBlogPost(id);

        public bool EditBlogPost(BlogPost BlogPost) => BlogDAO.Instance.EditBlogPost(BlogPost);
        public List<BlogPost> GetAll() => BlogDAO.Instance.GetAll();
    }
}
