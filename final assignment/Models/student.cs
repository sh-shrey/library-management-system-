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
    using System.Web;

    public partial class student
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string year { get; set; }
        public string stream { get; set; }
        public string image { get; set; }
        public HttpPostedFileBase imageupload { get; set; }
    }
}