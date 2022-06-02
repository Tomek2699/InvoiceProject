using DevExpress.Xpf.Core;
using ProjectInvoice.DataBase;
using ProjectInvoice.Services;
using ProjectInvoice.Views;
using ProjectInvoice.Views.Commodities;
using ProjectInvoice.Views.EditInvoice;
using ProjectInvoice.Views.ForeignCompanyView.EditForeignCompany;
using ProjectInvoice.Views.NewContractor;
using ProjectInvoice.Views.NewOurCompany;
using ProjectInvoice.Views.OurCompanyView.EditOurCompany;
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
        ProjectInvoiceEntities db = new ProjectInvoiceEntities();  

        public MainWindow()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            GridControlInvoice.ItemsSource = db.Invoices.ToList();
            GridControlOurCompany.ItemsSource = db.OurCompanies.ToList();
            GridControlForeignCompany.ItemsSource = db.ForeignCompanies.ToList();
            
            InvoiceTab.Visibility = Visibility.Hidden;
            CompanyTab.Visibility = Visibility.Hidden;

            deleteOurCompany.IsEnabled = false;
            deleteForeignCompany.IsEnabled = false;
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

        private void GridControlInvoice_MouseDoubleClick(object sender, MouseButtonEventArgs e)
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
                    RefreshInvoiceGrid();
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
                    RefreshCompanyAndForiegnGrid();
                    deleteOurCompany.IsEnabled = false;
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
                    RefreshCompanyAndForiegnGrid();
                    deleteForeignCompany.IsEnabled = false;
                }
            }
        }

        private void GridControlOurCompany_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var selectedRow = GridControlOurCompany.SelectedItem as OurCompany;

            EditOurCompanyModel editModel = new EditOurCompanyModel()
            {
                CompanyID = selectedRow.CompanyID,
                CompanyName = selectedRow.CompanyName,
                Address = selectedRow.Address,
                NIP = selectedRow.NIP,
                BankName = selectedRow.BankName,
                BankAccountNumber = selectedRow.BankAccountNumber,
                PhoneNumber = selectedRow.PhoneNumber,
            };

            EditOurCompany editOurCompanyWindow = new EditOurCompany(editModel);
            editOurCompanyWindow.Owner = this;
            editOurCompanyWindow.ShowDialog();
        }

        private void GridControlForeignCompany_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var selectedRow = GridControlForeignCompany.SelectedItem as ForeignCompany;

            EditForeignCompanyModel editModel = new EditForeignCompanyModel()
            {
                ForeignCompanyID = selectedRow.ForeignCompanyID,
                CompanyName = selectedRow.CompanyName,
                Address = selectedRow.Address,
                NIP = selectedRow.NIP,
                BankName = selectedRow.BankName,
                BankAccountNumber = selectedRow.BankAccountNumber,
                PhoneNumber = selectedRow.PhoneNumber,
            };

            EditForeignCompany editForeignCompanyWindow = new EditForeignCompany(editModel);
            editForeignCompanyWindow.Owner = this;
            editForeignCompanyWindow.ShowDialog();
        }

        private void RefreshInvoiceGrid()
        {
            GridControlInvoice.ItemsSource = db.Invoices.ToList();
            GridControlInvoice.RefreshData();
        }

        private void RefreshCompanyAndForiegnGrid()
        {
            GridControlOurCompany.ItemsSource = db.OurCompanies.ToList();
            GridControlForeignCompany.ItemsSource = db.ForeignCompanies.ToList();
            GridControlOurCompany.RefreshData();
            GridControlForeignCompany.RefreshData();
        }

        private void refreshInvoice_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            RefreshInvoiceGrid();
        }

        private void refreshCompanyAndForeignGrid_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            RefreshCompanyAndForiegnGrid();
        }

        private void TableView_GotFocus(object sender, RoutedEventArgs e)
        {
            deleteOurCompany.IsEnabled = true;
        }

        private void TableView_GotFocus_1(object sender, RoutedEventArgs e)
        {
            deleteForeignCompany.IsEnabled = true;
        }

        private void GridControlInvoice_CustomColumnDisplayText(object sender, DevExpress.Xpf.Grid.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column == columnCompanyID)
            {
                var value = e.Value as int?;
                if (value != null)
                {
                    var companyName = ourCompanyService.FindOne(value);
                    e.DisplayText = companyName.CompanyName.ToString();
                }
            }

            if (e.Column == columnForeignCompanyID)
            {
                var value = e.Value as int?;
                if (value != null)
                {
                    var foreignCompanyName = foreignCompanyService.FindOne(value);
                    e.DisplayText = foreignCompanyName.CompanyName.ToString();
                }
            }
        }

        private void showCommoditiesInInvoice_ItemClick(object sender, DevExpress.Xpf.Bars.ItemClickEventArgs e)
        {
            Commodities window = new Commodities();
            window.Owner = this;
            window.ShowDialog();
        }
    }
}
