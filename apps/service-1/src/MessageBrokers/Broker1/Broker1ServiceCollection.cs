using MessageBroker.Brokers.Infrastructure;

namespace MessageBroker.Brokers.Broker1;

internal static class Broker1ServiceCollection
{
    /// <summary>
    /// Register Broker1 services
    /// </summary>
    /// <param name="app"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public static IServiceCollection AddBroker1(this IHostApplicationBuilder app)
    {
        var kafkaOptions = app.Configuration.GetSection("Broker1").Get<KafkaOptions>();
        if (kafkaOptions == null)
            throw new Exception("KafkaOptions not found in configuration section Broker1");
        if (kafkaOptions.ConsumerGroupId == null)
            throw new Exception("ConsumerGroupId not found in configuration section Broker1");
        if (kafkaOptions.BootstrapServers == null)
            throw new Exception("BootstrapServers not found in configuration section Broker1");
        app.Services.AddHostedService(x => new Broker1ConsumerService(x.GetRequiredService<IServiceScopeFactory>(), kafkaOptions))
            .AddScoped<Broker1MessageHandlersContoller>();

        return app.Services;
    }
}
