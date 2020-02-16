using System;

namespace AccountsReceivable.InvoiceOperations.Api.Models
{
    public class InvoiceReceipt
    {
        public decimal Amount { get; set; }
        public string SourceCurrency { get; set; }
        public string FunctionalCurrency { get; set; }
        public decimal ExchangeRate { get; set; }
        public DateTimeOffset ReceiptDate { get; set; }
    }
}
