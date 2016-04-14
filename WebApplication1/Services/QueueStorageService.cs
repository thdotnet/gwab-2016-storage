using Microsoft.WindowsAzure.Storage.Queue;
using Microsoft.WindowsAzure.Storage.Queue.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace WebApplication1.Services
{
    public class QueueStorageService : BaseStorageService
    {
        public QueueStorageService()
        {

        }

        public async Task AddMessage(string fileName)
        {
            CloudQueueClient queueClient = _account.CreateCloudQueueClient();

            CloudQueue cloudQueue = queueClient.GetQueueReference("images");

            await cloudQueue.CreateIfNotExistsAsync();

            await cloudQueue.AddMessageAsync(new CloudQueueMessage(fileName));
        }

        public async Task<string> ListMessages()
        {
            CloudQueueClient queueClient = _account.CreateCloudQueueClient();

            CloudQueue cloudQueue = queueClient.GetQueueReference("images");

            await cloudQueue.CreateIfNotExistsAsync();

            CloudQueueMessage message = await cloudQueue.GetMessageAsync();

            if (message == null) return "";

            await cloudQueue.DeleteMessageAsync(message);

            return message.AsString;
        }
    }
}