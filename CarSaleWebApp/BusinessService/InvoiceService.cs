
using BusinessObject;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessService
{
    public class InvoiceService: IInvoiceService
    {
        public InvoiceService() { }

        private InvoiceRepo invoiceRepo;

        private InvoiceRepo _invoiceRepo()
        {
            if(this.invoiceRepo == null)
            {
                this.invoiceRepo = new InvoiceRepo();
            }
            return this.invoiceRepo;
        }

        public void AddInvoice(Invoice invoice)
        {
            _invoiceRepo().AddInvoice(invoice);
        }

        public void DeleteInvoiceById(string id)
        {
            _invoiceRepo().DeleteInvoiceById(id);
        }
        public Invoice GetInvoiceById(string id)
        {
            return _invoiceRepo().GetInvoiceById(id);
        }

        public IEnumerable<Invoice> GetInvoiceList()
        {
            return _invoiceRepo().GetInvoiceList();
        }

        public void UpdateInvoice(Invoice invoice)
        {
            _invoiceRepo().UpdateInvoice(invoice);
        }
    }
}
