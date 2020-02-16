using AccountsReceivable.InvoiceOperations.Api.Interfaces.Database;
using AccountsReceivable.InvoiceOperations.Api.Interfaces.Repositories;
using AccountsReceivable.InvoiceOperations.Api.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace AccountsReceivable.InvoiceOperations.Api.Repositories
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly IMongoCollection<Invoice> _invoices;
        public InvoiceRepository(IAccountsReceivableDatabase settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _invoices = database.GetCollection<Invoice>(settings.InvoiceCollectionName);
        }

        public Invoice GetInvoiceByInvoiceId(long invoiceNumber)
        {
            Invoice inv = new Invoice();
            inv = _invoices.Find<Invoice>(invoice => invoice.InvoiceNumber == invoiceNumber).FirstOrDefault();

            return inv;
        }

        public void CreateInvoiceRecord(Invoice inv)
        {
            _invoices.InsertOne(inv);
        }

        private Invoice createFakeInvoice(long invoiceId)
        {
            InvoiceRate rate = new InvoiceRate();

            rate.Amount = 50.00M;
            rate.Created = DateTime.Now;
            rate.Description = "Line Haul";
            rate.ExchangeRate = 1.0M;
            rate.FunctionalCurrency = "USD";
            rate.OrderNumber = 54321;
            rate.Quantity = 50.0M;
            rate.Rate = 1.0M;
            rate.SourceCurrency = "USD";
            rate.Updated = DateTime.Now;

            InvoiceRate rate2 = new InvoiceRate();

            rate2.Amount = 50.00M;
            rate2.Created = DateTime.Now;
            rate2.Description = "Line Haul";
            rate2.ExchangeRate = 1.0M;
            rate2.FunctionalCurrency = "USD";
            rate2.OrderNumber = 54321;
            rate2.Quantity = 25.0M;
            rate2.Rate = 2.0M;
            rate2.SourceCurrency = "USD";
            rate2.Updated = DateTime.Now;

            List<InvoiceRate> rates = new List<InvoiceRate>();
            rates.Add(rate);
            rates.Add(rate2);

            Invoice invoice = new Invoice();

            invoice.InvoiceNumber = invoiceId;
            invoice.Amount = 100.00M;
            invoice.Balance = 100.00M;
            invoice.Created = DateTime.Now;
            invoice.CreditorPartyCode = "1233";
            invoice.DebtorPartyCode = "C100";
            invoice.Rates = rates;

            return invoice;
        }
    }
}
