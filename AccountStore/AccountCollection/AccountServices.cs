using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AccountStore.AccountCollection
{
    public class AccountServices
    {
        private readonly IMongoCollection<Account> _accounts;
        public AccountServices(DBClient dbClient)
        {
            _accounts = dbClient.GetAccountCollection();
        }

        public async Task<ReplaceOneResult> UpdateAccount(Account account)
        {
            try
            {
                await GetAccount(account.Id);
                return await _accounts.ReplaceOneAsync(b => b.ChatId == account.ChatId, account);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public async Task<DeleteResult> DeleteAccount(string id)
        {
            try
            {
                return await _accounts.DeleteOneAsync(account => account.ChatId == id);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task AddAccount(Account account)
        {
            try
            {
                await _accounts.InsertOneAsync(account);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Account> GetAccount(string id)
        {
            try
            {
               return await _accounts.Find(account => account.ChatId == id).FirstOrDefaultAsync();
 
            } 
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}