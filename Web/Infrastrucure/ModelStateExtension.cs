using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Infrastrucure
{
    public static class ModelStateExtension
    {
        public static IList<string> GetErrorMessages(this ModelStateDictionary modelState)
        {
            var errorMessages = new List<string>();
            var modelErrors = modelState
                .Where(e => e.Value.Errors.Count > 0)
                .Select(e => e.Value.Errors);

            foreach (var item in modelErrors)
                errorMessages.AddRange(item.Select(e => string.Format("<li><strong>{0}</strong></li>", e.ErrorMessage)));
            
            return errorMessages;
        }
    }
}