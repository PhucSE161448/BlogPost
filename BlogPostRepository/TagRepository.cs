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
    public class TagRepository : ITagRepository
    {
        public async Task<IEnumerable<Tag>> GetAll() => await TagDAO.Instance.GetAll();
    }
}
