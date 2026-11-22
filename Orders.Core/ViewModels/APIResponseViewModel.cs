using System;
using System.Collections.Generic;
using System.Text;

namespace Orders.Core.ViewModels
{
    public class APIResponseViewModel
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }

        public APIResponseViewModel(
            bool status,
            string message,
            object data)
        {
            Status = status;
            Message = message;
            Data = data;
        }
    }
}
