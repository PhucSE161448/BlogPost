﻿using BlogPostBO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPostRepository.Interface
{
    public interface ITagRepository
    {
        Task<IEnumerable<Tag>> GetAll();
    }
}
