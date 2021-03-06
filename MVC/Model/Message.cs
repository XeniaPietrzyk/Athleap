using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Model
{
    public class Message
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public bool Status { get; set; }
        public Employee Sender { get; set; }
        public Employee Receiver { get; set; }
    }
}
