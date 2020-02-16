using AccountsReceivable.InvoiceOperations.Api.Interfaces.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountsReceivable.InvoiceOperations.Api.Models
{
    public class AccountsReceivableDatabase : IAccountsReceivableDatabase
    {
        public string InvoiceCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
