using DevExpress.Xpf.Core;
using ProjectInvoice.DataBase;
using ProjectInvoice.Views;
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
    }
}
