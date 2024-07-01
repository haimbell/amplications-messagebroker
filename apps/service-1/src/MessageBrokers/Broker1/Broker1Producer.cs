using MessageBroker.Brokers.Infrastructure;

namespace MessageBroker.Brokers.Broker1;

internal class Broker1Producer(string bootstrapServers)
    : InternalProducer(bootstrapServers);