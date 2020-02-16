using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace AccountsReceivable.InvoiceOperations.Api.Models
{
    public class Invoice
    {
        public long InvoiceNumber { get; set; }
        public string DebtorPartyCode { get; set; }
        public string CreditorPartyCode { get; set; }
        public decimal Amount { get; set; }
        public decimal Balance { get; set; }
        public DateTimeOffset Created { get; set; }
        public List<InvoiceRate> Rates { get; set; }
        public List<InvoiceReceipt> Receipts { get; set; }
    }
}
