using System;

namespace AccountsReceivable.InvoiceOperations.Api.Models
{
    public class InvoiceRate
    {
        public long OrderNumber { get; set; }
        public string Description { get; set; }
        public decimal Quantity { get; set; }
        public decimal Rate { get; set; }
        public decimal Amount { get; set; }
        public string SourceCurrency { get; set; }
        public string FunctionalCurrency { get; set; }
        public decimal ExchangeRate { get; set; }
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset Updated { get; set; }
    }
}
