using Microsoft.AspNet.Identity;
using System;

namespace WikiWebStarter.Web.Classes.Exceptions
{
    public class IdentityResultException : Exception
    {
        public IdentityResultException(IdentityResult result)
        {
            this.Result = result;
        }

        public IdentityResult Result { get; set; }

    }
}
