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


namespace ProjectInvoice.Views.NewContractor
{
    /// <summary>
    /// Interaction logic for NewForeignCompany.xaml
    /// </summary>
    public partial class NewForeignCompany : ThemedWindow
    {
        ForeignCompaniesService foreignCompanyService = new ForeignCompaniesService();

        public NewForeignCompany()
        {
            
            InitializeComponent();
            btnSave.IsEnabled = false;
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            ForeignCompany company = new ForeignCompany()
            {
                CompanyName = textBoxCompanyName.Text,
                Address = textBoxAddress.Text,
                NIP = textBoxNIP.Text,
                PhoneNumber = textBoxPhoneNumber.Text,
                BankName = textBoxBankName.Text,
                BankAccountNumber = textBoxBankAccountNumber.Text,
            };

            if (foreignCompanyService.Save(company))
            {
                this.Close();
            }
        }

        private void textBoxCompanyName_Validate(object sender, DevExpress.Xpf.Editors.ValidationEventArgs e)
        {
            if (e.Value == null)
            {
                e.SetError(
                    "Nazwa firmy nie może być pusta",
                    DevExpress.XtraEditors.DXErrorProvider.ErrorType.Warning
                );
                
            }
            else if (e.Value.ToString().Length > 100)
            {
                e.SetError(
                    "Nazwa firmy nie może być dłuższa niż 100 znaków",
                    DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical
                );
                
            }
        }

        private void textBoxAddress_Validate(object sender, DevExpress.Xpf.Editors.ValidationEventArgs e)
        {
            if (e.Value == null)
            {
                e.SetError(
                    "Adres firmy nie może być pusty",
                    DevExpress.XtraEditors.DXErrorProvider.ErrorType.Warning
                );
                btnSave.IsEnabled = false;

            }
            else if (e.Value.ToString().Length > 200)
            {
                e.SetError(
                    "Adres nie może być dłuższy niż 200 znaków",
                    DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical
                );
                btnSave.IsEnabled = false;
            }
        }

        private void textBoxNIP_Validate(object sender, DevExpress.Xpf.Editors.ValidationEventArgs e)
        {
            if (e.Value == null)
            {
                e.SetError(
                    "NIP nie może być pusty",
                    DevExpress.XtraEditors.DXErrorProvider.ErrorType.Warning
                );
                btnSave.IsEnabled = false;
            }
            else if (e.Value.ToString().Length > 20)
            {
                e.SetError(
                    "Nazwa nie może być dłuższa niż 20 znaków",
                    DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical
                );
                btnSave.IsEnabled = false;
            }
        }

        private void textBoxBankName_Validate(object sender, DevExpress.Xpf.Editors.ValidationEventArgs e)
        {
            if (e.Value == null)
            {
                e.SetError(
                    "Nazwa banku nie może być pusta",
                    DevExpress.XtraEditors.DXErrorProvider.ErrorType.Warning
                );
                btnSave.IsEnabled = false;
            }
            else if (e.Value.ToString().Length > 50)
            {
                e.SetError(
                    "Nazwa nie może być dłuższa niż 50 znaków",
                    DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical
                );
                btnSave.IsEnabled = false;
            }
        }

        private void textBoxBankAccountNumber_Validate(object sender, DevExpress.Xpf.Editors.ValidationEventArgs e)
        {
            if (e.Value == null)
            {
                e.SetError(
                    "Numer konta bankowego nie może być pusty",
                    DevExpress.XtraEditors.DXErrorProvider.ErrorType.Warning
                );
                btnSave.IsEnabled = false;

            }
            else if (e.Value.ToString().Length > 100)
            {
                e.SetError(
                    "Numer konta bankowego nie może być dłuższy niż 100 znaków",
                    DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical
                );
                btnSave.IsEnabled = false;
            }
        }

        private void textBoxPhoneNumber_Validate(object sender, DevExpress.Xpf.Editors.ValidationEventArgs e)
        {
            if (e.Value == null)
            {
                e.SetError(
                    "Numer telefonu nie może być pusty",
                    DevExpress.XtraEditors.DXErrorProvider.ErrorType.Warning
                );
                btnSave.IsEnabled = false;
            }
            else if (e.Value.ToString().Length > 9)
            {
                e.SetError(
                    "Numer telefonu nie może być dłuższy niż 9 znaków",
                    DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical
                );
                btnSave.IsEnabled = false;
            }
            else
            {
                btnSave.IsEnabled = true;
            }

            
        }
    }
}
