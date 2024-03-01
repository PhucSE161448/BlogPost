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
    public class LikeService : ILikeService
    {
        private readonly ILikeRepository _repo = null;
        public LikeService()
        {
            _repo = new LikeRepository();
        }
    }
}
