using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace AccountStore.AccountCollection
{
    public class Account
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public List<string> WalletAdresses { get; set; }
        public string Preference { get; set; }
        public string ChatId { get; set; }
        public List<string> Subs { get; set; }
    }
}