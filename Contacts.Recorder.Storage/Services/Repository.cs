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
                FirstName = "AJANTHAN",
                Home = "0112638612",
                LastName = "THURAIRATNAM",
                Mobile = "0779648396"
            };

            yield return new Contact()
            {
                FirstName = "James",
                Home = "0123456789",
                LastName = "FRANKLIN",
                Mobile = "077123456"
            };

            yield return new Contact()
            {
                FirstName = "Steve",
                Home = "023232323",
                LastName = "Smith",
                Mobile = "42525454"
            };

        }
        public void Add(Contact entity)
        {
            var contacts = _contacts.ToList();
            contacts.Add(entity);
            _contacts = contacts;
        }



    }
}
