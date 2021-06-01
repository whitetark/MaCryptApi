using System;
using System.Collections.Generic;
using System.Text;

namespace AccountStore
{
    public class DBConfig
    {

        public string Database_Name { get; set; } = "macrypt_database";
        public string Account_Collection_Name { get; set; } = "account";
        public string Connection_String { get; set; } = "mongodb+srv://whitetark:whitetark@cluster0.ctok8.mongodb.net/macrypt_database?retryWrites=true&w=majority";

    }
}
