using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountsReceivable.InvoiceOperations.Api.Interfaces.Database
{
    public interface IAccountsReceivableDatabase
    {
        string InvoiceCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
