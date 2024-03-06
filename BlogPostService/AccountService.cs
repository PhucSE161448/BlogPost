
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

        public async Task<bool> AddAccount(Account Account) => await _repo.AddAccount(Account);

        public async Task<Account> CheckLogin(string email, string password) => await _repo.CheckLogin(email, password);

        public async Task<bool> DeleteAccount(int id) => await _repo.DeleteAccount(id);

        public async Task<bool> EditAccount(Account Account) => await _repo.EditAccount(Account);

        public async Task<Account> GetAccountById(int id) => await _repo.GetAccountById(id);

        public async Task<List<Account>> GetAll() => await _repo.GetAll();
    }
}
