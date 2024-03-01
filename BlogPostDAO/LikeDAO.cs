using BlogPostBO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPostDAO
{
    public class LikeDAO
    {
        private readonly BlogPost_PRN221Context _db = null;
        private static LikeDAO _instance = null;
        public static LikeDAO Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new LikeDAO();
                }
                return _instance;
            }
        }
        public LikeDAO()
        {
            _db = new BlogPost_PRN221Context();
        }
    }
}
