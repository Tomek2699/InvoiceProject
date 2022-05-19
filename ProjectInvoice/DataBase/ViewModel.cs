using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectInvoice.DataBase
{
    public class ViewModel : ViewModelBase
    {
        ProjectInvoiceEntities dbcontext;


        public ObservableCollection<Commodity> Commodities
        {
            get => GetValue<ObservableCollection<Commodity>>();
            set => SetValue(value);
        }

        public ObservableCollection<Invoice> Invoices
        {
            get => GetValue<ObservableCollection<Invoice>>();
            set => SetValue(value);
        }

        public ViewModel()
        {
            dbcontext = new ProjectInvoiceEntities();

            if (IsInDesignMode)
            {
                Commodities = new ObservableCollection<Commodity>();
                Invoices = new ObservableCollection<Invoice>();
            }
            else
            {
                dbcontext.Commodities.Load();
                Commodities = dbcontext.Commodities.Local;
                dbcontext.Invoices.Load();
                Invoices = dbcontext.Invoices.Local;
            }
        }
    }
}
