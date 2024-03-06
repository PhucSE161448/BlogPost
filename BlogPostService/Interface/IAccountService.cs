using BlogPostBO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPostService.Interface
{
    public interface IAccountService
    {
         Task<List<Account>> GetAll();
         Task<bool> AddAccount(Account Account);
         Task<bool> DeleteAccount(int id);
         Task<Account> GetAccountById(int id);
         Task<Account> CheckLogin(string email, string password);

         Task<bool> EditAccount(Account Account);
    }
}
