using ProjectInvoice.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectInvoice.Services
{
    public class InvoiceService
    {
        ProjectInvoiceEntities db = new ProjectInvoiceEntities();

        public void Save(Invoice invoice)
        {
            db.Invoices.Add(invoice);
            db.SaveChanges();
        }

        public void Edit(Invoice invoice)
        {
            if(invoice != null)
            {
                Invoice editInvoice = db.Invoices.Find(invoice.InvoiceID);

                if(invoice.NoInvoice != null)
                {
                    editInvoice.NoInvoice = invoice.NoInvoice;
                }
                if (invoice.CompanyID != null)
                {
                    editInvoice.CompanyID = invoice.CompanyID;
                }
                if (invoice.ForeignCompanyID != null)
                {
                    editInvoice.ForeignCompanyID = invoice.ForeignCompanyID;
                }
                if (invoice.StartDate != null)
                {
                    editInvoice.StartDate = invoice.StartDate;
                }
                if (invoice.FinishDateDelivery != null)
                {
                    editInvoice.FinishDateDelivery = invoice.FinishDateDelivery;
                }
                if (invoice.PaymentDate != null)
                {
                    editInvoice.PaymentDate = invoice.PaymentDate;
                }
                if (invoice.PaymentWay != null)
                {
                    editInvoice.PaymentWay = invoice.PaymentWay;
                }

                db.SaveChanges();
            }
        }

        public Invoice FindOne(int invoiceId)
        {
            return db.Invoices.Find(invoiceId);
        }

        public int LastInvoice()
        {
            var invoices =  db.Invoices.ToList();
            var lastInvoice = invoices.Last();
            return lastInvoice.InvoiceID;
        }

        public void Delete(int invoiceId)
        {
            var item = db.Invoices.Find(invoiceId);

            if(item.Commodity != null)
            {
                db.Commodities.RemoveRange(db.Commodities.Where(i => i.InvoiceID == invoiceId));
            }

            db.Invoices.Remove(item);
            db.SaveChanges();

        }
    }
}
