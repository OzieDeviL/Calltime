using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Calltime.Web.Models.Requests
{
    public class BaseRequest : IRequestModel
    {
        [Required]
        public int PersonId { get; set; }
    }
}