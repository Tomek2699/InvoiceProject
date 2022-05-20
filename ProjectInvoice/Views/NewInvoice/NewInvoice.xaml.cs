using DevExpress.Xpf.Core;
using ProjectInvoice.DataBase;
using ProjectInvoice.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace ProjectInvoice.Views
{
    /// <summary>
    /// Interaction logic for NewInvoice.xaml
    /// </summary>
    public partial class NewInvoice : ThemedWindow
    {
        ForeignCompaniesService foreignCompaniesService = new ForeignCompaniesService();
        OurCompaniesService ourCompaniesService = new OurCompaniesService();
        CommoditiesService commoditiesService = new CommoditiesService();
        ProjectInvoiceEntities dbContext = new ProjectInvoiceEntities();
        InvoiceService invoiceService = new InvoiceService();
        MainWindow mainWindow = new MainWindow();
        private List<Commodity> Commodities { get; set; } = new List<Commodity>();
        public NewInvoice()
        {
            InitializeComponent();
            SetData();
        }

        public void SetData()
        {
            comboBoxSeller.ItemsSource = ourCompaniesService.GetAll();
            comboBoxBuyer.ItemsSource = foreignCompaniesService.GetAll();
        }

        private void comboBoxSellerSelected(object sender, SelectionChangedEventArgs e)
        {
            var selectedValue = comboBoxSeller.SelectedValue as OurCompany;

            if (selectedValue != null)
            {
                textBoxSellerAddress.Text = selectedValue.Address;
                textBoxSellerNIP.Text = selectedValue.NIP;
                textBoxSellerPhoneNumber.Text = selectedValue.PhoneNumber;
                textBoxBankName.Text = selectedValue.BankName;
                textBoxBankAccountNumber.Text = selectedValue.BankAccountNumber;
            }
        }

        private void comboBoxBuyerSelected(object sender, SelectionChangedEventArgs e)
        {
            var selectedValue = comboBoxBuyer.SelectedValue as ForeignCompany;

            if(selectedValue != null)
            {
                textBoxBuyerAddress.Text = selectedValue.Address;
                textBoxBuyerNIP.Text = selectedValue.NIP;
                textBoxBuyerPhoneNumber.Text = selectedValue.PhoneNumber;
            }
        }

        private void SaveInvoice()
        {
            var ourCompany = comboBoxSeller.SelectedItem as OurCompany;
            var foreignCompany = comboBoxBuyer.SelectedItem as ForeignCompany;

            Invoice invoice = new Invoice()
            {
                InvoiceID = dbContext.Invoices.Count(),
                CompanyID = ourCompany.CompanyID,
                ForeignCompanyID = foreignCompany.ForeignCompanyID,
                NoInvoice = textBoxNoInvoice.Text,
                StartDate = dateEditStartDate.DateTime,
                FinishDateDelivery = dateEditFinishDateDelivery.DateTime,
                PaymentDate = dateEditPaymentDay.DateTime,
                PaymentWay = comboBoxPaymentWay.Text,
                IsPay = false,
            };
            invoiceService.Save(invoice);
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            SaveInvoice();
            SaveCommodities();
            mainWindow.InvoiceGrid.RefreshData();
            this.Close();
        }

        private void CommoditiesUpdate(object sender, DevExpress.Xpf.Grid.RowEventArgs e)
        {
           int lastInvoiceId = dbContext.Invoices.Count() + 1;
           var commodity = e.Row as Commodity;
           if (commodity != null)
           {
                commodity.InvoiceID = lastInvoiceId;
                Commodities.Add(commodity);
           }
        }

        private void SaveCommodities()
        {
            commoditiesService.Save(Commodities);
        }

        private void textBoxNoInvoice_Validate(object sender, DevExpress.Xpf.Editors.ValidationEventArgs e)
        {
            if (e.Value == null)
            {
                e.SetError(
                    "Nr faktury nie może być pusty",
                    DevExpress.XtraEditors.DXErrorProvider.ErrorType.Warning
                );
                /*btnSave.IsEnabled = false;*/
            }
            else if (e.Value.ToString().Length > 100)
            {
                e.SetError(
                    "Nazwa firmy nie może być dłuższa niż 100 znaków",
                    DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical
                );
                /*btnSave.IsEnabled = false;*/
            }
        }
    }
}
