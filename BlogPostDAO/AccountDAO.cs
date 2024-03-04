using BlogPostBO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogPostDAO
{
    public class AccountDAO
    {
        private readonly BlogPost_PRN221Context _db = null;
        private static AccountDAO _instance = null;
        public static AccountDAO Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new AccountDAO();
                }
                return _instance;
            }
        }
        public AccountDAO()
        {
            _db = new BlogPost_PRN221Context();
        }
        public List<Account> GetAll() => _db.Accounts.ToList(); 
        public bool AddAccount(Account Account)
        {
            try
            {
                _db.Add(Account);
                _db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool DeleteAccount(int id)
        {
            Account Account = GetAccountById(id);
            try
            {
                _db.Accounts.Remove(Account);
                _db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public Account GetAccountById(int id)
        {
            return _db.Accounts.FirstOrDefault(x => x.Id == id);
        }

        public Account CheckLogin(string email, string password)
        {
            return _db.Accounts.FirstOrDefault(x => x.Email.Equals(email) && x.Password.Equals(password));
        }
        public bool EditAccount(Account Account)
        {
            Account de = GetAccountById(Account.Id);
            try
            {
                _db.Update(de);
                _db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
