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
    public class AccountRepository : IAccountRepository
    {
        public async Task<bool> AddAccount(Account Account) => await AccountDAO.Instance.AddAccount(Account);

        public async Task<Account> CheckLogin(string email, string password) => await AccountDAO.Instance.CheckLogin(email, password);

        public async Task<bool> DeleteAccount(int id) => await AccountDAO.Instance.DeleteAccount(id);

        public async Task<bool> EditAccount(Account Account) => await AccountDAO.Instance.EditAccount(Account);

        public async Task< Account> GetAccountById(int id) => await AccountDAO.Instance.GetAccountById(id);
        public async Task<List<Account>> GetAll() => await AccountDAO.Instance.GetAll();
    }
}
