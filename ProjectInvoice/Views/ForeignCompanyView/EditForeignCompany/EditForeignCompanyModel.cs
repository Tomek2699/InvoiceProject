using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectInvoice.Views.ForeignCompanyView.EditForeignCompany
{
    public class EditForeignCompanyModel
    {
        public int ForeignCompanyID { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string NIP { get; set; }
        public string PhoneNumber { get; set; }
        public string BankName { get; set; }
        public string BankAccountNumber { get; set; }
    }
}
