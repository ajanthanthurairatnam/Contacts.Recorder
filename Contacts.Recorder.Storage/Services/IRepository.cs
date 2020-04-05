using Contacts.Recorder.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contacts.Recorder.Storage
{
    public interface IRepository
    {
        IEnumerable<Contact> FetchAll();
        Contact Add(Contact contact);
        Contact GetById(string id);
        Contact Save(Contact contact);
    }
}
