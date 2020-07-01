using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace final_assignment.Models
{
    [MetadataType(typeof(bookmetadata))]
    public partial class book
    {
        public class bookmetadata
        {
            [DisplayName("Book name")]
            public string book_name { get; set; }
            [DisplayName("category")]
            public string cat_id { get; set; }
            [DisplayName("author")]
            public string a_id { get; set; }
            [DisplayName("publisher")]
            public string p_id { get; set; }
            [DisplayName("about")]
            public string about { get; set; }
            [DisplayName("pages")]
            public string pages { get; set; }
            [DisplayName("edition")]
            public string edition { get; set; }


        }
    }
}