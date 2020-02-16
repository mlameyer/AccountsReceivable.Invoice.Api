using AccountsReceivable.InvoiceOperations.Api.Models;

namespace AccountsReceivable.InvoiceOperations.Api.Interfaces.Managers
{
    public interface IInvoiceManager
    {
        Invoice GetInvoiceByInvoiceID(long invoiceId);
        void CreateInvoiceRecord(Invoice inv);
    }
}
