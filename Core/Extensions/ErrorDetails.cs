using FluentValidation.Results;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
namespace Core.Extensions
{
    //middlevare de hataların detaylarını göreceğiz.
    public class ErrorDetails
    {
        public string Message { get; set; }
        public int StatusCode { get; set; }

        public override string ToString()
        {
            //jsonconvert bir paket
            return JsonConvert.SerializeObject(this);
        }
    }

    public class ValidationErrorDetails : ErrorDetails
    {
        //ayrıca içermesini istediğim 
        public IEnumerable<ValidationFailure> Errors { get; set; }
    }
}