using BlogPostBO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPostDAO
{
    public class CommentDAO
    {
        private readonly BlogPost_PRN221Context _db = null;
        private static CommentDAO _instance = null;
        public static CommentDAO Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CommentDAO();
                }
                return _instance;
            }
        }
        public CommentDAO()
        {
            _db = new BlogPost_PRN221Context();
        }
    }
}
