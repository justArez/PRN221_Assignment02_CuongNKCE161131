using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class InvoiceDAO
    {
        private static InvoiceDAO instance = null;
        private static readonly object instanceLock = new object();
        public static InvoiceDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new InvoiceDAO();
                    }
                }
                return instance;
            }
        }

        public IEnumerable<Invoice> GetList()
        {
            var orders = new List<Invoice>();
            try
            {
                using var context = new CarSaleManagementDbContext();
                orders = context.Invoices.ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return orders;
        }

        public Invoice GetById(string invoiceId)
        {
            Invoice invoice = null;
            try
            {
                using var context = new CarSaleManagementDbContext();
                invoice = context.Invoices.SingleOrDefault(c => c.Invoiceid == invoiceId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return invoice;
        }

        public void Add(Invoice invoice)
        {
            try
            {
                Invoice _invoice = GetById(invoice.Invoiceid);
                if (_invoice == null)
                {
                    using var context = new CarSaleManagementDbContext();
                    context.Invoices.Add(invoice);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Invoice is already existed.");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Update(Invoice invoice)
        {
            try
            {
                Invoice _order = GetById(invoice.Invoiceid);
                if (_order != null)
                {
                    using var context = new CarSaleManagementDbContext();
                    context.Invoices.Update(invoice);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Invoice does not exist.");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Delete(string invoiceId)
        {
            try
            {
                Invoice _invoice = GetById(invoiceId);
                if (_invoice != null)
                {
                    using var context = new CarSaleManagementDbContext();
                    context.Invoices.Remove(_invoice);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Invoice does not exist.");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
