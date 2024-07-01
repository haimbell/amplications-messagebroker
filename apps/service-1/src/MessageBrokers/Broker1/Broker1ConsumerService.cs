using MessageBroker.Brokers.Infrastructure;

namespace MessageBroker.Brokers.Broker1;

internal class Broker1ConsumerService(IServiceScopeFactory serviceScopeFactory, KafkaOptions kafkaOptions)
    : KafkaConsumerService<Broker1MessageHandlersContoller>(serviceScopeFactory, kafkaOptions);
