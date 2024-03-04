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
        public bool AddAccount(Account Account) => AccountDAO.Instance.AddAccount(Account);

        public Account CheckLogin(string email, string password) => AccountDAO.Instance.CheckLogin(email, password);

        public bool DeleteAccount(int id) => AccountDAO.Instance.DeleteAccount(id);

        public bool EditAccount(Account Account) => AccountDAO.Instance.EditAccount(Account);

        public Account GetAccountById(int id) => AccountDAO.Instance.GetAccountById(id);
        public List<Account> GetAll() => AccountDAO.Instance.GetAll();
    }
}
