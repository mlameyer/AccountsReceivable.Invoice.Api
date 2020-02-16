using AccountsReceivable.InvoiceOperations.Api.Models;

namespace AccountsReceivable.InvoiceOperations.Api.Interfaces.Repositories
{
    public interface IInvoiceRepository
    {
        Invoice GetInvoiceByInvoiceId(long invoiceId);
        void CreateInvoiceRecord(Invoice inv);
    }
}
