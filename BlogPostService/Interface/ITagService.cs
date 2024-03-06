using BlogPostBO.Model;
using BlogPostDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPostService.Interface
{
    public interface ITagService
    {
        Task<IEnumerable<Tag>> GetAll();
    }
}
