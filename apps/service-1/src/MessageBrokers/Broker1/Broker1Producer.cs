using Service1.MessageBrokers.Infrastructure;

namespace Service1.MessageBrokers.Broker1;

internal class Broker1Producer(string bootstrapServers)
    : InternalProducer(bootstrapServers);