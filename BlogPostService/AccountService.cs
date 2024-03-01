using BlogPostRepository;
using BlogPostRepository.Interface;
using BlogPostService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPostService
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _repo = null;
        public AccountService()
        {
            _repo = new AccountRepository();
        }
    }
}
