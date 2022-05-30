using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectInvoice.Views.EditInvoice
{
    public class EditInvoiceValidationModel
    {
        public bool NoInvoice { get; set; }
        public bool StartDate { get; set; }
        public bool FinishDateDelivery { get; set; }
        public bool PaymentDate { get; set; }
    }
}
