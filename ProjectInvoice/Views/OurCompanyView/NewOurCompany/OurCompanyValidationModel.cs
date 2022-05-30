using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectInvoice.Views.NewOurCompany
{
    public class OurCompanyValidationModel
    {
        public bool Companyname { get; set; }
        public bool Address { get; set; }
        public bool NIP { get; set; }
        public bool BankName { get; set; }
        public bool BankAccountNumber { get; set; }
        public bool PhoneNumber { get; set; }
    }
}
