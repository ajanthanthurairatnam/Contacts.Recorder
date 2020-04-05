using Contacts.Recorder.Core.Models;
using Contacts.Recorder.MongoFramework;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contacts.Recorder.Storage.Services
{
    public class Repository : IRepository
    {
        public IEnumerable<Contact> _contacts;
        public IDbService _dbService;
        private MongoClient _mongoClient;
        private IMongoDatabase _mongoDatabase;
        private IMongoCollection<Contact> _contactCollection;
        public Repository(IDbService dbService)
        {
            _dbService = dbService;
            _mongoClient = _dbService.CreateMongoClient(Configuration.ConnectionString);
            _mongoDatabase = _dbService.GetMongoDatabase(_mongoClient);
            _contactCollection = _dbService.GetMongoCollection(_mongoDatabase);
        }
        public IEnumerable<Contact> FetchAll()
        {
            return _contactCollection.Find(_ => true).ToList();
        }
        public Contact Add(Contact contact)
        {
            contact.Id = Guid.NewGuid().ToString();
            contact.ContactId = contact.Id;
            _contactCollection.InsertOne(contact);
            _contacts = FetchAll();
            return contact;
        }

        public Contact GetById(string id)
        {
            return FetchAll().FirstOrDefault(e => e.Id == id);
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
       
                var filter = Builders<Contact>.Filter.Eq("ContactId", contact.ContactId);

                var update = Builders<Contact>.Update
                                              .Set("FirstName", contact.FirstName)
                                              .Set("LastName", contact.LastName)
                                              .Set("Mobile", contact.Mobile)
                                              .Set("Home", contact.Home);

                _contactCollection.UpdateOne(filter, update);

                _contacts = FetchAll();
                return _contact;

            }
           
             return Add(contact);
            
        }
    }
}
