//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjectInvoice.DataBase
{
    using System;
    using System.Collections.Generic;
    
    public partial class Commodity
    {
        public int CommodityID { get; set; }
        public int InvoiceID { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public string Unit { get; set; }
        public int PriceNetto { get; set; }
        public int ValueNetto { get; set; }
        public int VAT { get; set; }
        public int AmountVAT { get; set; }
        public int AmountBrutto { get; set; }
    
        public virtual Invoice Invoice { get; set; }
    }
}
