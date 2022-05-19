using ProjectInvoice.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectInvoice.Services
{
    public class CommoditiesService
    {
        ProjectInvoiceEntities db = new ProjectInvoiceEntities();

        public void Save(List<Commodity> commodities)
        {
            foreach (var item in commodities)
            {
                db.Commodities.Add(item);
            }
            db.SaveChanges();
        }
    }
}
