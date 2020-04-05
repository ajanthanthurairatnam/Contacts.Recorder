using Contacts.Recorder.Core.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Security.Authentication;
using System.Text;

namespace Contacts.Recorder.MongoFramework
{
    public class DbService : IDbService
    {     
        public MongoClient CreateMongoClient(string ConnectionString)
        {
            MongoClientSettings settings = MongoClientSettings.FromUrl(
              new MongoUrl(ConnectionString)
            );

            settings.SslSettings =
              new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 };
            return new MongoClient(settings);
        }
      

        public IMongoDatabase GetMongoDatabase(MongoClient mongoClient)
        {
            return mongoClient.GetDatabase("ContactDB");
        }

        public IMongoCollection<Contact> GetMongoCollection(IMongoDatabase mongoDatabase)
        {
            return mongoDatabase.GetCollection<Contact>("Contact");
        }


        public Contact Insert(Contact contact,string ConnectionString)
        {
            var mongoClient = CreateMongoClient(ConnectionString);
            var mongoDatabase = GetMongoDatabase(mongoClient);
            var collection = GetMongoCollection(mongoDatabase);
            collection.InsertOne(contact);
            return contact;
        }
    }
}
