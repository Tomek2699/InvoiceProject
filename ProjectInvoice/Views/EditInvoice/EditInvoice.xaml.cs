using DevExpress.Xpf.Core;
using ProjectInvoice.DataBase;
using ProjectInvoice.Services;
using ProjectInvoice.Views.NewForeignCompany;
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
        ProjectInvoiceEntities dbContext = new ProjectInvoiceEntities();
        private InvoiceValidationModel validationModel = new InvoiceValidationModel();
        InvoiceService invoiceService = new InvoiceService();
        private EditInvoiceModel model {get;set;}

        public EditInvoice(EditInvoiceModel item)
        {
            InitializeComponent();
            model = item;
            SetData();
        }

        private void SetData()
        {
            PrepareDataToShow();
            
        }

        private void PrepareDataToShow()
        {
            model.PrepareComboBoxOurCompany();
            textBoxNoInvoice.Text = model.NoInvoice;
            comboBoxSeller.ItemsSource = model.OurCompanies;
            comboBoxSeller.SelectedIndex = model.OurCompanyIndex;
            comboBoxBuyer.ItemsSource = model.ForeignCompanies;
            comboBoxBuyer.SelectedIndex = model.ForeignCompanyIndex;
            dateEditStartDate.DateTime = model.StartDate;
            dateEditFinishDateDelivery.DateTime = model.FinishDateDelivery;
            dateEditPaymentDay.DateTime = model.PaymentDate;
            comboBoxPaymentWay.SelectedIndex = model.PaymentWayIndex;
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

        private void Edit()
        {
            var ourCompany = comboBoxSeller.SelectedItem as OurCompany;
            var foreignCompany = comboBoxBuyer.SelectedItem as ForeignCompany;

            Invoice invoice = new Invoice()
            {
                InvoiceID =  model.InvoiceID,
                CompanyID = ourCompany.CompanyID,
                ForeignCompanyID = foreignCompany.ForeignCompanyID,
                NoInvoice = textBoxNoInvoice.Text,
                StartDate = dateEditStartDate.DateTime,
                FinishDateDelivery = dateEditFinishDateDelivery.DateTime,
                PaymentDate = dateEditPaymentDay.DateTime,
                PaymentWay = comboBoxPaymentWay.Text,
                IsPay = false,
            };
            invoiceService.Edit(invoice);
        }

        private bool ValidationComboBox()
        {
            if (comboBoxSeller.SelectedIndex == -1)
            {
                if (MessageBox.Show("Proszę wybrać sprzedawcę", "Sprzedawca", MessageBoxButton.OK, MessageBoxImage.Warning) == MessageBoxResult.OK) 
                {
                    return false;
                }
            }
            else if (comboBoxBuyer.SelectedIndex == -1)
            {
                if (MessageBox.Show("Proszę wybrać nabywcę", "Nabywca", MessageBoxButton.OK, MessageBoxImage.Warning) == MessageBoxResult.OK) 
                {
                    return false;
                }
            }
            else if (comboBoxPaymentWay.SelectedIndex == -1)
            {
                if (MessageBox.Show("Proszę wybrać sposób płatności", "Sposób płatności", MessageBoxButton.OK, MessageBoxImage.Warning) == MessageBoxResult.OK)
                {
                    return false;
                }
            }

            return true;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if(ValidationComboBox() && Validation())
            {
                Edit();
                this.Close();
            }
        }

        private bool Validation()
        {
            if (validationModel.NoInvoice && validationModel.StartDate && validationModel.FinishDateDelivery && validationModel.PaymentDate)
            {
                btnSave.IsEnabled = true;
                return true;
            }
            else
            {
                btnSave.IsEnabled = false;
                return false;
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
                validationModel.NoInvoice = false;
                btnSave.IsEnabled = false;
            }
            else
            {
                validationModel.NoInvoice = true;
                btnSave.IsEnabled = true;
            }
        }

        private void dateEditStartDate_Validate(object sender, DevExpress.Xpf.Editors.ValidationEventArgs e)
        {
            if (e.Value == null)
            {
                e.SetError(
                    "Data wystawienia nie może być pusta",
                    DevExpress.XtraEditors.DXErrorProvider.ErrorType.Warning
                );
                validationModel.StartDate = false;
            }
            else
            {
                validationModel.StartDate = true;
                btnSave.IsEnabled = true;
            }
        }

        private void dateEditFinishDateDelivery_Validate(object sender, DevExpress.Xpf.Editors.ValidationEventArgs e)
        {
            if (e.Value == null)
            {
                e.SetError(
                    "Data zakończenia dostawy towaru nie może być pusta",
                    DevExpress.XtraEditors.DXErrorProvider.ErrorType.Warning
                );
                validationModel.FinishDateDelivery = false;
            }
            else
            {
                validationModel.FinishDateDelivery = true;
                btnSave.IsEnabled = true;
            }
        }

        private void dateEditPaymentDay_Validate(object sender, DevExpress.Xpf.Editors.ValidationEventArgs e)
        {
            if (e.Value == null)
            {
                e.SetError(
                    "Data płatności nie może być pusta",
                    DevExpress.XtraEditors.DXErrorProvider.ErrorType.Warning
                );
                validationModel.PaymentDate = false;
            }
            else
            {
                validationModel.PaymentDate = true;
                btnSave.IsEnabled = true;
            }
        }
    }
}
