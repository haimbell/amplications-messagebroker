using System.Text.Json;
using MessageBroker.Brokers.Infrastructure;

namespace MessageBroker.Brokers.Broker1;

internal class Broker1MessageHandlersContoller 
{
    private ILogger<Broker1MessageHandlersContoller> _logger;
    public Broker1MessageHandlersContoller(ILogger<Broker1MessageHandlersContoller> logger)
    {
        _logger = logger;
    }


    [Topic("your-topic")]
    public Task YourTopic(string messageItem)
    {
        KafkaMessage message = JsonSerializer.Deserialize<KafkaMessage>(messageItem);
        _logger.LogInformation("Received message: {@KafkaMessage}", message);
        return Task.CompletedTask;
    }
}
