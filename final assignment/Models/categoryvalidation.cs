using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace final_assignment.Models
{
    [MetadataType(typeof(categorymetadata))]
    public partial class category
    {
        public class categorymetadata
        {
            [DisplayName("category name")]
            public string category_name { get; set; }
            [DisplayName("Status")]
            public string status { get; set; }

        }

    }
}