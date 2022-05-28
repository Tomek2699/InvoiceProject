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


namespace ProjectInvoice.Views.EditInvoice
{
    public partial class EditInvoice : ThemedWindow
    {
        ForeignCompaniesService foreignCompaniesService = new ForeignCompaniesService();
        OurCompaniesService ourCompaniesService = new OurCompaniesService();
        CommoditiesService commoditiesService = new CommoditiesService();
        ProjectInvoiceEntities dbContext = new ProjectInvoiceEntities();
        InvoiceService invoiceService = new InvoiceService();
        private EditModel model {get;set;}
        public EditInvoice(EditModel item)
        {
            InitializeComponent();
            model = item;
            SetData();
        }

        private void SetData()
        {
            textBoxNoInvoice.Text = model.NoInvoice;
            comboBoxSeller.SelectedValue = model.CompanyID;
            comboBoxBuyer.SelectedItem = model.ForeignCompanyID;
            dateEditStartDate.DateTime = model.StartDate;
            dateEditFinishDateDelivery.DateTime = model.FinishDateDelivery;
            dateEditPaymentDay.DateTime = model.PaymentDate;
            comboBoxPaymentWay.SelectedItem = model.PaymentWay;
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

            if (selectedValue != null)
            {
                textBoxBuyerAddress.Text = selectedValue.Address;
                textBoxBuyerNIP.Text = selectedValue.NIP;
                textBoxBuyerPhoneNumber.Text = selectedValue.PhoneNumber;
            }
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
