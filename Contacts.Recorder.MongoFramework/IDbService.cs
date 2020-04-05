using Contacts.Recorder.Core.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contacts.Recorder.MongoFramework
{
    public interface IDbService
    {
        MongoClient CreateMongoClient(string ConnectionString);

        IMongoDatabase GetMongoDatabase(MongoClient mongoClient);

        IMongoCollection<Contact> GetMongoCollection(IMongoDatabase mongoDatabase);

        Contact Insert(Contact contact, string ConnectionString);
    }
}
