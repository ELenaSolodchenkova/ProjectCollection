//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RostelecomMainWIndow
{
    using System;
    using System.Collections.Generic;
    
    public partial class InstalledEquipment
    {
        public int IdCE { get; set; }
        public int IdClient { get; set; }
        public int IdEquipment { get; set; }
        public System.DateTime Date { get; set; }
    
        public virtual Client Client { get; set; }
        public virtual EquipmentList EquipmentList { get; set; }
    }
}
