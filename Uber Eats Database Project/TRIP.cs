//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Uber_Eats_Database_Project
{
    using System;
    using System.Collections.Generic;
    
    public partial class TRIP
    {
        public int ORDER_ID { get; set; }
        public decimal DISTANCE_OF_TRIP { get; set; }
        public string DELIVERYPARTNER_USERNAME { get; set; }
        public decimal DELIVERYFEES { get; set; }
    
        public virtual DELIVERY_PARTNER DELIVERY_PARTNER { get; set; }
        public virtual ORDER ORDER { get; set; }
    }
}
