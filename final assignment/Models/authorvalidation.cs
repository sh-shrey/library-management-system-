using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace final_assignment.Models
{
    [MetadataType(typeof(authormetadata))]
    public  partial class author
    {
        public class authormetadata
        {
            [DisplayName("Author Name")]
            public string author_name { get; set; }

        }
    }
}