using Contacts.Recorder.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contacts.Recorder.Storage.Services
{
    public class Repository : IRepository
    {
        public IEnumerable<Contact> _contacts;
        public Repository()
        {
            _contacts = FetchAll();

        }
        public IEnumerable<Contact> FetchAll()
        {
            yield return new Contact()
            {
                Id= "c5f925c6-8196-4a37-8e3a-e3a14bfd3415",
                FirstName = "AJANTHAN",
                Home = "0112638612",
                LastName = "THURAIRATNAM",
                Mobile = "0779648396"
            };

            yield return new Contact()
            {
                Id = "2d5a1eae-6577-4527-901d-fa75d2a598bc",
                FirstName = "James",
                Home = "0123456789",
                LastName = "FRANKLIN",
                Mobile = "077123456"
            };

            yield return new Contact()
            {
                Id = "98c85d5c-1782-4f53-992a-4d93c154fa27",
                FirstName = "Steve",
                Home = "023232323",
                LastName = "Smith",
                Mobile = "42525454"
            };

        }
        public Contact Add(Contact contact)
        {
            contact.Id = Guid.NewGuid().ToString();
            var contacts = _contacts.ToList();
            contacts.Add(contact);
            _contacts = contacts;
            return contact;
        }

        public Contact GetById(string id)
        {
            return _contacts.FirstOrDefault(e => e.Id == id);
        }

        public Contact Save(Contact contact)
        {
            if (!string.IsNullOrEmpty(contact.Id))
            {

                var contacts = _contacts;
                var _contact = GetById(contact.Id);
                _contact.FirstName = contact.FirstName;
                _contact.LastName = contact.LastName;
                _contact.Mobile = contact.Mobile;
                _contact.Home = contact.Home;

                foreach (var con in contacts)
                {
                    if (con.Id == contact.Id)
                    {
                        con.FirstName = _contact.FirstName;
                        con.LastName = _contact.LastName;
                        con.Mobile = _contact.Mobile;
                        con.Home = _contact.Home;
                    }
                }

                _contacts = contacts;
                return _contact;

            }
           
             return Add(contact);
            
        }
    }
}
