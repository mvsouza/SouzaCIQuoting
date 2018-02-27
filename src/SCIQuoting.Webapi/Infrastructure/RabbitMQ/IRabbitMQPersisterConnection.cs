using RabbitMQ.Client;
using System;

namespace SCIQuoting.Webapi.Infrastructure.RabbitMQ
{
    public interface IRabbitMQPersistentConnection
        : IDisposable
    {
        bool IsConnected { get; }

        bool TryConnect();

        IModel CreateModel();
    }
}
