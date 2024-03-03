using BusinessObject;
using DataAccess.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class InvoiceRepo: IInvoiceRepo
    {
        public InvoiceRepo() { }

        private InvoiceDAO invoiceDAO = null;
       
        private InvoiceDAO _invoiceDAO()
        {
            if (this.invoiceDAO == null)
            {
                this.invoiceDAO = new InvoiceDAO();
            }
            return this.invoiceDAO;
        }

        public void AddInvoice(Invoice invoice)
        {
            _invoiceDAO().Add(invoice);
        }

        public void DeleteInvoiceById(string id)
        {
            _invoiceDAO().Delete(id);
        }

        public Invoice GetInvoiceById(string id)
        {
            return _invoiceDAO().GetById(id);
        }
        public IEnumerable<Invoice> GetInvoiceList()
        {
            return _invoiceDAO().GetList();
        }

        public void UpdateInvoice(Invoice invoice)
        {
            _invoiceDAO().Update(invoice);
        }
    }
}
