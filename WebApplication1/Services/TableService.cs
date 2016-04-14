using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class TableService : BaseStorageService
    {
        public TableService()
        {

        }

        public async Task AddTemplate(string template)
        {
            string templateName = string.Concat("GWAB", DateTime.Now.ToString("ddMMyyyyhhmmss"));

            CloudTableClient tableClient = _account.CreateCloudTableClient();
            CloudTable table = tableClient.GetTableReference("templates");

            await table.CreateIfNotExistsAsync();

            Template t = new Template(templateName, template);
            
            await table.ExecuteAsync(TableOperation.Insert(t));
        }

        public IEnumerable<Template> GetTemplates()
        {
            CloudTableClient tableClient = _account.CreateCloudTableClient();
            CloudTable table = tableClient.GetTableReference("templates");

            TableQuery<Template> query = new TableQuery<Template>().Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, "templates"));

            return table.ExecuteQuery(query);
        }
    }
}