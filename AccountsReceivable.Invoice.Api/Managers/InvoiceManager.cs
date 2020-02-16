using AccountsReceivable.InvoiceOperations.Api.Interfaces.Managers;
using AccountsReceivable.InvoiceOperations.Api.Interfaces.Repositories;
using AccountsReceivable.InvoiceOperations.Api.Models;

namespace AccountsReceivable.InvoiceOperations.Api.Managers
{
    public class InvoiceManager : IInvoiceManager
    {
        private IInvoiceRepository _repo;
        public InvoiceManager(IInvoiceRepository repo)
        {
            _repo = repo;
        }
        
        public Invoice GetInvoiceByInvoiceID(long invoiceId)
        {
            Invoice invoice = new Invoice();
            invoice = _repo.GetInvoiceByInvoiceId(invoiceId);
            return invoice;
        }

        public void CreateInvoiceRecord(Invoice inv)
        {
            _repo.CreateInvoiceRecord(inv);
        }
    }
}
