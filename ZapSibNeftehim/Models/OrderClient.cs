//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ZapSibNeftehim.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class OrderClient
    {
        public int ID { get; set; }
        public int orderID { get; set; }
        public string clientID { get; set; }
    
        public virtual Client Client { get; set; }
        public virtual Order Order { get; set; }
    }
}