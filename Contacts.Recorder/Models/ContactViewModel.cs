using Contacts.Recorder.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contacts.Recorder.API.Models
{
    public class ContactViewModel
    {
        public IEnumerable<Contact> Contacts { get; set; }



    }
}
