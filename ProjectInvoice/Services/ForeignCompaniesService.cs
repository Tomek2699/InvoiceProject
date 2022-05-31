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

        public ForeignCompany FindOne(int? foreignCompanyId)
        {
            return db.ForeignCompanies.Find(foreignCompanyId);
        }

        public List<ForeignCompany> GetAll()
        {
            return db.ForeignCompanies.ToList();
        }

        public void Edit(ForeignCompany foreignCompany)
        {
            if (foreignCompany != null)
            {
                ForeignCompany editForeignCompany = db.ForeignCompanies.Find(foreignCompany.ForeignCompanyID);

                if (foreignCompany.CompanyName != null)
                {
                    editForeignCompany.CompanyName = foreignCompany.CompanyName;
                }
                if (foreignCompany.Address != null)
                {
                    editForeignCompany.Address = foreignCompany.Address;
                }
                if (foreignCompany.NIP != null)
                {
                    editForeignCompany.NIP = foreignCompany.NIP;
                }
                if (foreignCompany.BankName != null)
                {
                    editForeignCompany.BankName = foreignCompany.BankName;
                }
                if (foreignCompany.BankAccountNumber != null)
                {
                    editForeignCompany.BankAccountNumber = foreignCompany.BankAccountNumber;
                }
                if (foreignCompany.PhoneNumber != null)
                {
                    editForeignCompany.PhoneNumber = foreignCompany.PhoneNumber;
                }

                db.SaveChanges();
            }
        }

        public void Delete(int foreignCompanyId)
        {
            var item = db.ForeignCompanies.Find(foreignCompanyId);
            if(item.Invoice.Count() == 0)
            {
                db.ForeignCompanies.Remove(item);
                db.SaveChanges();
            }
        }
    }
}
