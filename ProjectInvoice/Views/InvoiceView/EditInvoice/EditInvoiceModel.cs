using ProjectInvoice.DataBase;
using ProjectInvoice.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectInvoice.Views.EditInvoice
{
    public class EditInvoiceModel
    {
        ForeignCompaniesService foreignCompaniesService = new ForeignCompaniesService();
        OurCompaniesService ourCompaniesService = new OurCompaniesService();
        CommoditiesService commoditiesService = new CommoditiesService();
        ProjectInvoiceEntities dbContext = new ProjectInvoiceEntities();
        InvoiceService invoiceService = new InvoiceService();

        public int InvoiceID { get; set; }
        public int CompanyID { get; set; }
        public int ForeignCompanyID { get; set; }
        public string NoInvoice { get; set; }
        public System.DateTime StartDate { get; set; }
        public System.DateTime FinishDateDelivery { get; set; }
        public System.DateTime PaymentDate { get; set; }
        public string PaymentWay { get; set; }
        public Nullable<bool> IsPay { get; set; }
        public ICollection<Commodity> Commodity { get; set; }
        public ForeignCompany ForeignCompany { get; set; }
        public OurCompany OurCompany { get; set; }
        public int OurCompanyIndex { get; set; }
        public int ForeignCompanyIndex { get; set; }
        public int PaymentWayIndex { get; set; }
        public List<OurCompany> OurCompanies { get; set; }
        public List<ForeignCompany> ForeignCompanies { get; set; }


        public void PrepareComboBoxOurCompany()
        {
            OurCompanies = ourCompaniesService.GetAll();
            OurCompany = ourCompaniesService.FindOne(CompanyID);

            for (int i = 0; i < OurCompanies.Count; i++)
            {
                if (OurCompanies[i].CompanyID == CompanyID)
                {
                    OurCompanyIndex = i;
                    break;
                }
                else
                {
                    OurCompanyIndex = -1;
                }
            }

            ForeignCompanies = foreignCompaniesService.GetAll();
            ForeignCompany = foreignCompaniesService.FindOne(ForeignCompanyID);

            for (int i = 0; i < ForeignCompanies.Count; i++)
            {
                if (ForeignCompanies[i].ForeignCompanyID == ForeignCompanyID)
                {
                    ForeignCompanyIndex = i;
                    break;
                }
                else
                {
                    ForeignCompanyIndex = -1;
                }
            }

            if(PaymentWay == "Przelew")
            {
                PaymentWayIndex = 0;
            }
            else if(PaymentWay == "Gotówka")
            {
                PaymentWayIndex = 1;
            }
        }
    }
}
