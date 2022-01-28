using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace RabbitMqExample
{
    public static class RabbitMqExample
    {
        [FunctionName("RabbitMqExample")]
        [return: RabbitMQ(QueueName = "outputQueue", ConnectionStringSetting = "RabbitMqConnection")]
        public static string Run(
            [RabbitMQTrigger("inputQueue", ConnectionStringSetting = "RabbitMqConnection")] string name,
            ILogger log)
        {
            log.LogInformation($"Message received: {name}.");
            return $"Hello, {name}.";
        }
    }
}