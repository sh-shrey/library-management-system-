//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace final_assignment.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class book
    {
        public int Id { get; set; }
        public string book_name { get; set; }
        public int cat_id { get; set; }
        public int a_id { get; set; }
        public int p_id { get; set; }
        public string about { get; set; }
        public string pages { get; set; }
        public string edition { get; set; }
    
        public virtual author author { get; set; }
        public virtual category category { get; set; }
        public virtual publisher publisher { get; set; }
    }
}
