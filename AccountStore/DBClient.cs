using Microsoft.Extensions.Options;
using System.Net.Http;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using AccountStore.AccountCollection;

namespace AccountStore
{
    public class DBClient
    {
        private readonly IMongoCollection<Account> _accounts;
        public DBClient(IOptions<DBConfig> accountstoreDbConfig)
        {
            var client = new MongoClient(accountstoreDbConfig.Value.Connection_String);
            var database = client.GetDatabase(accountstoreDbConfig.Value.Database_Name);
            _accounts = database.GetCollection<Account>(accountstoreDbConfig.Value.Account_Collection_Name);

        }
        public IMongoCollection<Account> GetAccountCollection()
        {
            return _accounts;
        }
    }
}
