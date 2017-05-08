using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace Calltime.Web.Models.Requests
{
    public class ProductionPostPutRequest : BaseRequest, IRequestModel
    {
        [Required]
        [StringLength(128)]
        public string ProductionName { get; set; }

        [StringLength(128)]
        public string LongName { get; set; }

        [StringLength(128)]
        public string CodeName { get; set; }
    }
}