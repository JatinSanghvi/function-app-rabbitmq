using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace RabbitMqExample
{
    public static class RabbitMqExample
    {
        [FunctionName("RabbitMqExample")]
        [return: RabbitMQ(QueueName = "%RabbitMqOutQueueName%", ConnectionStringSetting = "RabbitMqConnectionString")]
        public static string Run(
            [RabbitMQTrigger(queueName: "%RabbitMqInQueueName%", ConnectionStringSetting = "RabbitMqConnectionString")] string name,
            ILogger log)
        {
            log.LogInformation($"Message received: {name}.");
            return $"Hello, {name}.";
        }
    }
}