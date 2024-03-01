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
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _repo = null;
        public CommentService()
        {
            _repo = new CommentRepository();
        }
    }
}
