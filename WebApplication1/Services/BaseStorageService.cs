using Microsoft.WindowsAzure.Storage;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace WebApplication1.Services
{
    public class BaseStorageService : IDisposable
    {
        private string _connectionString;
        protected CloudStorageAccount _account;

        public BaseStorageService()
        {
            _connectionString = ConfigurationManager.AppSettings["storageConnectionString"];

            if (string.IsNullOrWhiteSpace(_connectionString))
                throw new Exception("Invalid Storage Account ConnectionString");

            _account = CloudStorageAccount.Parse(_connectionString);
        }

        public void Dispose()
        {
            _account = null;
        }
    }
}