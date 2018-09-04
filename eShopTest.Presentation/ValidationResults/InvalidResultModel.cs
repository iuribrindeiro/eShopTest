using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace eShopTest.Presentation.ValidationResults
{
    public class InvalidResultModel
    {
        public string Message { get; set; }

        public Dictionary<string, string[]> Errors { get; }

        public InvalidResultModel(ModelStateDictionary modelState)
        {
            Message = "Some data you provided are not valid";
            Errors = modelState.Keys.ToDictionary(key => key.ToString(),
                key => modelState[key].Errors.Select(e => e.ErrorMessage.ToString()).ToArray());
        }
    }
}
