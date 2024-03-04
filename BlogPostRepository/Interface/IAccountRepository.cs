using BlogPostBO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPostRepository.Interface
{
    public interface IAccountRepository
    {
        public List<Account> GetAll();
        public bool AddAccount(Account Account);
        public bool DeleteAccount(int id);
        public Account GetAccountById(int id);
        public Account CheckLogin(string email, string password);

        public bool EditAccount(Account Account);
    }
}
