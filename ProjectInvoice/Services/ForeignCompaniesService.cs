using ProjectInvoice.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectInvoice.Services
{
    public class ForeignCompaniesService
    {
        ProjectInvoiceEntities db = new ProjectInvoiceEntities();
        public bool Save(ForeignCompany company)
        {
            db.ForeignCompanies.Add(company);
            db.SaveChanges();
            return true;
        }

        public List<ForeignCompany> GetAll()
        {
            return db.ForeignCompanies.ToList();
        }
    }
}
