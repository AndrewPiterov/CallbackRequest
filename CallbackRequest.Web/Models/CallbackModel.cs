using System;

namespace CallbackRequest.Web.Models
{
    public class CallbackModel
    {
        public DateTime CreatedAt { get; internal set; }
        public string Name { get; set; }
        public string Phone { get; set; }
    }
}