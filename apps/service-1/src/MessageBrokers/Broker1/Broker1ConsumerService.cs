using Service1.MessageBrokers.Infrastructure;

namespace Service1.MessageBrokers.Broker1;

internal class Broker1ConsumerService(IServiceScopeFactory serviceScopeFactory, KafkaOptions kafkaOptions)
    : KafkaConsumerService<Broker1MessageHandlersContoller>(serviceScopeFactory, kafkaOptions);
