using System.Collections.Generic;

namespace EventManagementSystem
{
    public class AccountManager
    {
        public Dictionary<string, Account> Accounts;

        public AccountManager()
        {
            Accounts = new Dictionary<string, Account>();
        }

        public void AddAccount(Account account)
        {
            if (!Accounts.ContainsKey(account.Username))
            {
                Accounts.Add(account.Username, account);
            }
        }

        public bool ValidateCredentials(string username, string password)
        {
            return Accounts.ContainsKey(username) && Accounts[username].Password == password;
        }

        public Account GetAccount(string username)
        {
            return Accounts.ContainsKey(username) ? Accounts[username] : null;
        }
    }
}
