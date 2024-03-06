using BlogPostBO.Model;
using Microsoft.EntityFrameworkCore;
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
        public async Task<List<Account>> GetAll() => _db.Accounts.AsNoTracking().ToList();
        public async Task<bool> AddAccount(Account Account)
        {
            try
            {
                await _db.Accounts.AddAsync(Account);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public async Task<bool> DeleteAccount(int id)
        {
            Account Account = await GetAccountById(id);
            try
            {
                _db.Accounts.Remove(Account);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public async Task<Account> GetAccountById(int id)
        {
            return await _db.Accounts.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Account> CheckLogin(string email, string password)
        {
            return await _db.Accounts.AsNoTracking().FirstOrDefaultAsync(x => x.Email.Equals(email) && x.Password.Equals(password));
        }
        public async Task<bool> EditAccount(Account Account)
        {
            var acc = await _db.Accounts.AsNoTracking().FirstOrDefaultAsync(x => x.Id == Account.Id);
            if (acc != null)
            {
                acc.Email = Account.Email;
                acc.Name = Account.Name;
                acc.Password = acc.Password;
                acc.Role = Account.Role;
            }
            try
            {
                _db.Accounts.Update(acc);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
