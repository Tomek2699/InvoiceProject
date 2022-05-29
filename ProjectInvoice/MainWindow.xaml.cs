using DevExpress.Xpf.Core;
using ProjectInvoice.DataBase;
using ProjectInvoice.Services;
using ProjectInvoice.Views;
using ProjectInvoice.Views.EditInvoice;
using ProjectInvoice.Views.NewContractor;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjectInvoice
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ThemedWindow
    {
        InvoiceService invoiceService = new InvoiceService();
        OurCompaniesService ourCompanyService = new OurCompaniesService();
        ForeignCompaniesService foreignCompanyService = new ForeignCompaniesService();

        public MainWindow()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            InvoiceTab.Visibility = Visibility.Hidden;
            CompanyTab.Visibility = Visibility.Hidden;
        }

        private void CreateInvoice(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            NewInvoice window = new NewInvoice();
            window.Owner = this;
            window.ShowDialog();

        }

        private void CreateNewOurCompany(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            NewOurCompany window = new NewOurCompany();
            window.Owner = this;
            window.ShowDialog();
        }

        private void CreateNewContractor(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            NewForeignCompany window = new NewForeignCompany();
            window.Owner = this;
            window.ShowDialog();
        }

        private void RibbonControl_SelectedPageChanged(object sender, DevExpress.Xpf.Ribbon.RibbonPropertyChangedEventArgs e)
        {
            if(ribbonControl.SelectedPage == InvoicePage)
            {
                TabControl.ShowTabItem(InvoiceTab, true);
                InvoiceTab.Visibility = Visibility.Hidden;
                CompanyTab.Visibility = Visibility.Hidden;
            }
            else if(ribbonControl.SelectedPage == CompanyPage)
            {
                TabControl.ShowTabItem(CompanyTab, true);
                InvoiceTab.Visibility = Visibility.Hidden;
                CompanyTab.Visibility = Visibility.Hidden;
            }
        }

        private void InvoiceGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var selectedRow = GridControlInvoice.SelectedItem as Invoice;

            if(selectedRow != null)
            {

                EditInvoiceModel editModel = new EditInvoiceModel()
                {
                    InvoiceID = selectedRow.InvoiceID,
                    CompanyID = selectedRow.CompanyID,
                    ForeignCompanyID = selectedRow.ForeignCompanyID,
                    NoInvoice = selectedRow.NoInvoice,
                    StartDate = selectedRow.StartDate,
                    FinishDateDelivery = selectedRow.FinishDateDelivery,
                    PaymentDate = selectedRow.PaymentDate,
                    IsPay = selectedRow.IsPay,
                };
                EditInvoice editInvoiceWindow = new EditInvoice(editModel);
                editInvoiceWindow.Owner = this;
                editInvoiceWindow.ShowDialog();
            }
        }

        private void deleteInvoice_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            var row = GridControlInvoice.GetFocusedRow() as Invoice;
           if(MessageBox.Show("Czy na pewno chcesz usunąć fakturę?", "Usuwanie faktury", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
           {
               if (row != null)
               {
                   invoiceService.Delete(row.InvoiceID);
               }
           }  
        }

        private void deleteOurCompany_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            var row = GridControlOurCompany.GetFocusedRow() as OurCompany;
            if(MessageBox.Show("Czy na pewno chcesz usunąć swoją firmę?", "Usuwanie swojej firmy", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                if (row != null)
                {
                    ourCompanyService.Delete(row.CompanyID);
                }
            }
        }

        private void deleteForeignCompany_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            var row = GridControlForeignCompany.GetFocusedRow() as ForeignCompany;
            if(MessageBox.Show("Czy na pewno chcesz usunąć obcą firmę?", "Usuwanie obcej firmy", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                if (row != null)
                {
                    foreignCompanyService.Delete(row.ForeignCompanyID);
                }
            }
        }
    }
}
