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


namespace ProjectInvoice.Views.Commodities
{
    /// <summary>
    /// Interaction logic for Commodities.xaml
    /// </summary>
    public partial class Commodities : ThemedWindow
    {
        InvoiceService invoiceService = new InvoiceService();
        CommoditiesService commoditiesService = new CommoditiesService();
        public Commodities()
        {
            InitializeComponent();
            comboBoxInvoice.ItemsSource = invoiceService.GetAll();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedValue = comboBoxInvoice.SelectedValue as Invoice;
 
            if (selectedValue != null)
            {
                var gridItems = commoditiesService.GetAllByInvoiceId(selectedValue.InvoiceID);
                gridControlCommodities.ItemsSource = gridItems;
                gridControlCommodities .RefreshData();

                textBoxPriceNetto.Text = gridItems.Sum(i => i.PriceNetto).ToString();
                textBoxAmountNetto.Text = gridItems.Sum(i => i.ValueNetto).ToString();
                textBoxAmountVAT.Text = gridItems.Sum(i => i.AmountVAT).ToString();
                textBoxAmountBrutto.Text = gridItems.Sum(i => i.AmountBrutto).ToString();
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
