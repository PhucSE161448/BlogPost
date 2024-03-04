
using BlogPostBO.Model;
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

        public bool AddAccount(Account Account) => _repo.AddAccount(Account);

        public Account CheckLogin(string email, string password) => _repo.CheckLogin(email, password);

        public bool DeleteAccount(int id) => _repo.DeleteAccount(id);

        public bool EditAccount(Account Account) => _repo.EditAccount(Account);

        public Account GetAccountById(int id) => _repo.GetAccountById(id);

        public List<Account> GetAll() => _repo.GetAll();
    }
}
