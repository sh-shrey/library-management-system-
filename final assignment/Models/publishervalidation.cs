using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace final_assignment.Models
{
    [MetadataType(typeof(publishermetadata))]
    public partial class publisher
    {
        public class publishermetadata
        {
            [DisplayName("Publisher Name")]
            public string name { get; set; }

        }
    }
}