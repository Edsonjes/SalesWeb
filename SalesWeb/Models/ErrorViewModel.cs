using System;

namespace SalesWeb.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }
        public string Massage { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}