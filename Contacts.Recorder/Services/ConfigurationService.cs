using Contacts.Recorder.Core;
using Contacts.Recorder.Core.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contacts.Recorder.API.Services
{
    public class ConfigurationService : IConfigurationService
    {
        public IConfiguration _Config { get; }

        public ConfigurationService(IConfiguration Config)
        {
            _Config = Config;
           
            _Config.GetConnectionString("DBConnection");
        }
     
    }
}
