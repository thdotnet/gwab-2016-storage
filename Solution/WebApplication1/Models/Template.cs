using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Template : TableEntity
    {
        public string Content { get; private set; }

        public Template()
        {
                
        }

        public Template(string id, string template)
        {
            this.PartitionKey = "templates";
            this.RowKey = id;

            Content = template;
        }
    }
}