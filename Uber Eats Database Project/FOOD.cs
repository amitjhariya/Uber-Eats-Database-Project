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
    
    public partial class FOOD
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FOOD()
        {
            this.ORDER_FOOD = new HashSet<ORDER_FOOD>();
        }
    
        public string FOOD_NAME { get; set; }
        public string RESTAURANT_NAME { get; set; }
        public string RESTAURANT_LOCATION { get; set; }
        public decimal PRICE { get; set; }
        public int DISCOUNT { get; set; }
        public int RATING { get; set; }
        public string INGREDIANTS { get; set; }
        public string TOP_DISH { get; set; }
        public string FOODIMAGE { get; set; }
        public string FOODTYPE { get; set; }
    
        public virtual RESTAURANT RESTAURANT { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ORDER_FOOD> ORDER_FOOD { get; set; }
    }
}
