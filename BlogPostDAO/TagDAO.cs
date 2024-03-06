using BlogPostBO.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPostDAO
{
    public class TagDAO
    {
        private readonly BlogPost_PRN221Context _db = null;
        private static TagDAO _instance = null;
        public static TagDAO Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new TagDAO();
                }
                return _instance;
            }
        }
        public TagDAO()
        {
            _db = new BlogPost_PRN221Context();
        }
        public async Task<IEnumerable<Tag>> GetAll()
        {
            var tags = await _db.Tags.AsNoTracking().ToListAsync();
            return tags.DistinctBy(x => x.Name.ToLower());
        }
    }
}
