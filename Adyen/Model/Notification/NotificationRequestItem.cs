using System.Collections.Generic;

namespace Adyen.Model.Notification
{
    public class NotificationRequestItem
    {
        public Amount Amount { get; set; }
        public string EventCode { get; set; }
        public string EventDate { get; set; }
        public string MerchantAccountCode  { get; set; }
        public string MerchantReference { get; set; }
        public string OriginalReference { get; set; }
        public string PspReference { get; set; }
        public string Reason { get; set; }
        public bool Success { get; set; }
        public string PaymentMethod { get; set; }
        public List<string> Operations { get; set; }
        public Dictionary<string, string> AdditionalData { get; set; }
    }
}