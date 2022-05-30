using DevExpress.Xpf.Core;
using ProjectInvoice.DataBase;
using ProjectInvoice.Services;
using ProjectInvoice.Views.NewOurCompany;
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


namespace ProjectInvoice.Views.OurCompanyView.EditOurCompany
{
    /// <summary>
    /// Interaction logic for EditOurCompany.xaml
    /// </summary>
    public partial class EditOurCompany : ThemedWindow
    {
        OurCompaniesService companyService = new OurCompaniesService();
        EditOurCompanyValidationModel validationModel = new EditOurCompanyValidationModel();
        EditOurCompanyModel model = new EditOurCompanyModel();

        public EditOurCompany(EditOurCompanyModel item)
        {
            InitializeComponent();
            model = item;
            btnSave.IsEnabled = false;
            SetData();
        }

        private void SetData()
        {
            PrepareDataToShow();
        }

        private void PrepareDataToShow()
        {
            textBoxCompanyName.Text = model.CompanyName;
            textBoxAddress.Text = model.Address;
            textBoxNIP.Text = model.NIP;
            textBoxBankName.Text = model.BankName;
            textBoxBankAccountNumber.Text = model.BankAccountNumber;
            textBoxPhoneNumber.Text = model.PhoneNumber;
        }

        private void Edit()
        {
            OurCompany company = new OurCompany()
            {
                CompanyID = model.CompanyID,
                CompanyName = textBoxCompanyName.Text,
                Address = textBoxAddress.Text,
                NIP = textBoxNIP.Text,
                PhoneNumber = textBoxPhoneNumber.Text,
                BankName = textBoxBankName.Text,
                BankAccountNumber = textBoxBankAccountNumber.Text,
            };

            companyService.Edit(company);
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (Validation())
            {
                Edit();
                this.Close();
            }
        }



        private bool Validation()
        {
            if (validationModel.Companyname && validationModel.Address && validationModel.NIP && validationModel.BankName
                && validationModel.BankAccountNumber && validationModel.PhoneNumber)
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

        private void textBoxCompanyName_Validate(object sender, DevExpress.Xpf.Editors.ValidationEventArgs e)
        {
            if (e.Value == null)
            {
                e.SetError(
                    "Nazwa firmy nie może być pusta",
                    DevExpress.XtraEditors.DXErrorProvider.ErrorType.Warning
                );
                validationModel.Companyname = false;
                btnSave.IsEnabled = false;

            }
            else if (e.Value.ToString().Length > 100)
            {
                e.SetError(
                    "Nazwa firmy nie może być dłuższa niż 100 znaków",
                    DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical
                );
                validationModel.Companyname = false;
                btnSave.IsEnabled = false;
            }
            else
            {
                validationModel.Companyname = true;
                btnSave.IsEnabled = true;
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
                validationModel.Address = false;
                btnSave.IsEnabled = false;

            }
            else if (e.Value.ToString().Length > 200)
            {
                e.SetError(
                    "Adres nie może być dłuższy niż 200 znaków",
                    DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical
                );
                validationModel.Address = false;
                btnSave.IsEnabled = false;
            }
            else
            {
                validationModel.Address = true;
                btnSave.IsEnabled = true;
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
                validationModel.NIP = false;
                btnSave.IsEnabled = false;

            }
            else if (e.Value.ToString().Length > 20)
            {
                e.SetError(
                    "Nazwa nie może być dłuższa niż 20 znaków",
                    DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical
                );
                validationModel.NIP = false;
                btnSave.IsEnabled = false;
            }
            else
            {
                validationModel.NIP = true;
                btnSave.IsEnabled = true;
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
                validationModel.BankName = false;
                btnSave.IsEnabled = false;

            }
            else if (e.Value.ToString().Length > 50)
            {
                e.SetError(
                    "Nazwa nie może być dłuższa niż 50 znaków",
                    DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical
                );
                validationModel.BankName = false;
                btnSave.IsEnabled = false;
            }
            else
            {
                validationModel.BankName = true;
                btnSave.IsEnabled = true;
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
                validationModel.BankAccountNumber = false;
                btnSave.IsEnabled = false;

            }
            else if (e.Value.ToString().Length > 100)
            {
                e.SetError(
                    "Numer konta bankowego nie może być dłuższy niż 100 znaków",
                    DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical
                );
                validationModel.BankAccountNumber = false;
                btnSave.IsEnabled = false;
            }
            else
            {
                validationModel.BankAccountNumber = true;
                btnSave.IsEnabled = true;
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
                validationModel.PhoneNumber = false;
                btnSave.IsEnabled = false;

            }
            else if (e.Value.ToString().Length > 9)
            {
                e.SetError(
                    "Numer telefonu nie może być dłuższy niż 9 znaków",
                    DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical
                );
                validationModel.PhoneNumber = false;
                btnSave.IsEnabled = false;
            }
            else
            {
                validationModel.PhoneNumber = true;
                btnSave.IsEnabled = true;
            }
        }
    }
}
