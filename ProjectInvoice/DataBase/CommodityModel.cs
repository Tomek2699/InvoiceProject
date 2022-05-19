using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectInvoice.DataBase
{
    public class CommodityModel : ViewModelBase
    {
        public ObservableCollection<Commodity> Commodities
        {
            get => GetValue<ObservableCollection<Commodity>>();
            set => SetValue(value);
        }

        public CommodityModel()
        {
            Commodities = new ObservableCollection<Commodity>();
        }
    }
}
