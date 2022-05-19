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
    }
}
