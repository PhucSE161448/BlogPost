using BlogPostBO.Model;
using BlogPostRepository.Interface;
using BlogPostRepository;
using BlogPostService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPostService
{
    public class TagService : ITagService
    {
        private readonly ITagRepository _repo = null;
        public TagService()
        {
            _repo = new TagRepository();
        }
        public Task<IEnumerable<Tag>> GetAll()
        {
            return _repo.GetAll();
        }
    }
}
