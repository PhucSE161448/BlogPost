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
        public static AccountDAO Instance {  
            get 
            { 
                if(_instance == null)
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
    }
}
