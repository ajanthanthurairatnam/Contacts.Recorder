using System;
using System.Collections.Generic;
using System.Text;

namespace Contacts.Recorder.Core.Models
{
    public class Contact
    {
        public string Id { get; set; }
        public string ContactId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mobile { get; set; }
        public string Home { get; set; }
    }
}
