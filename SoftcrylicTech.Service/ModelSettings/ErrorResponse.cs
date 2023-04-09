using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text.Json;

namespace SoftcrylicTech.Service.ModelSettings
{
    public class ErrorResponse
    {
        public int StatusCode { get; set; }
        public string Type { get; set; }
        public string Error { get; set; }
        public List<string> ValidationErrors { get; set; }       
        public string Detail { get; set; }
        public string ErrorId { get; set; }
        public string TimeStamp { get; set; }

        public ErrorResponse(Exception exception)
        {
            StatusCode = (int)HttpStatusCode.InternalServerError;
            Error = exception.Message;
            Type = exception.GetType().Name;

            if (exception.InnerException != null)
            {
                Detail = exception.InnerException.Message;
            }
            else
            {
                Detail = "";
            }
            InitializeData();
        }

        public ErrorResponse(HttpStatusCode httpStatusCode, string errorMessage)
        {
            StatusCode = (int)httpStatusCode;
            Error = errorMessage;

            InitializeData();
        }

        public ErrorResponse(HttpStatusCode httpStatusCode, IEnumerable<ValidationResult> validationResults)
        {
            StatusCode = (int)httpStatusCode;
            ValidationErrors = new List<string>();

            foreach (var data in validationResults)
            {
                ValidationErrors.Add(data.ErrorMessage);
            }
            InitializeData();
        }

        private void InitializeData()
        {
            ErrorId = Guid.NewGuid().ToString();
            TimeStamp = DateTime.Now.Date.ToShortDateString() + "" + DateTime.Now.ToShortTimeString();
        }

        public string ToJson()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}