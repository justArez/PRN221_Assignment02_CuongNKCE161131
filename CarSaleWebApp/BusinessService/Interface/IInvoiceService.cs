
using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessService
{
    public interface IInvoiceService
    {
        public void AddInvoice(Invoice invoice);

        public void DeleteInvoiceById(string id);

        public Invoice GetInvoiceById(string id);

        public IEnumerable<Invoice> GetInvoiceList();

        public void UpdateInvoice(Invoice invoice);
    }
}
