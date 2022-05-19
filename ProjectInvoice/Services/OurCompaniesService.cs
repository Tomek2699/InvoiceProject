using ProjectInvoice.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectInvoice.Services
{
    public class OurCompaniesService
    {
        ProjectInvoiceEntities db = new ProjectInvoiceEntities();
        public bool Save(OurCompany company)
        {
            db.OurCompanies.Add(company);
            db.SaveChanges();
            return true;
        }

        public List<OurCompany> GetAll()
        {
            return db.OurCompanies.ToList();
        }
    }
}
