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
    }
}
