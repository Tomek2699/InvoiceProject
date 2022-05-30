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

        public OurCompany FindOne(int ourCompanyId)
        {
            return db.OurCompanies.Find(ourCompanyId);
        }

        public List<OurCompany> GetAll()
        {
            return db.OurCompanies.ToList();
        }

        public void Edit(OurCompany ourCompany)
        {
            if (ourCompany != null)
            {
                OurCompany editOurCompany = db.OurCompanies.Find(ourCompany.CompanyID);

                if (ourCompany.CompanyName != null)
                {
                    editOurCompany.CompanyName = ourCompany.CompanyName;
                }
                if (ourCompany.Address != null)
                {
                    editOurCompany.Address = ourCompany.Address;
                }
                if (ourCompany.NIP != null)
                {
                    editOurCompany.NIP = ourCompany.NIP;
                }
                if (ourCompany.BankName != null)
                {
                    editOurCompany.BankName = ourCompany.BankName;
                }
                if (ourCompany.BankAccountNumber!= null)
                {
                    editOurCompany.BankAccountNumber = ourCompany.BankAccountNumber;
                }
                if (ourCompany.PhoneNumber != null)
                {
                    editOurCompany.PhoneNumber = ourCompany.PhoneNumber;
                }

                db.SaveChanges();
            }
        }

        public void Delete(int ourCompanyId)
        {
            var item = db.OurCompanies.Find(ourCompanyId);
            if(item.Invoice.Count() == 0)
            {
                db.OurCompanies.Remove(item);
                db.SaveChanges();
            } 
        }
    }
}
