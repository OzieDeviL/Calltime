using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WikiWebStarter.Web.Models.Requests
{
    public class ItemsRequest<T>
    {
        [Required]
        public List<T> Items { get; set; }
    }
}
