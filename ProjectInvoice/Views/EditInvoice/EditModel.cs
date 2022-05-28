using ProjectInvoice.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectInvoice.Views.EditInvoice
{
    public class EditModel
    {
        public int InvoiceID { get; set; }
        public int CompanyID { get; set; }
        public int ForeignCompanyID { get; set; }
        public string NoInvoice { get; set; }
        public System.DateTime StartDate { get; set; }
        public System.DateTime FinishDateDelivery { get; set; }
        public System.DateTime PaymentDate { get; set; }
        public string PaymentWay { get; set; }
        public Nullable<bool> IsPay { get; set; }
        public virtual ICollection<Commodity> Commodity { get; set; }
        public virtual ForeignCompany ForeignCompany { get; set; }
        public virtual OurCompany OurCompany { get; set; }
    }
}
