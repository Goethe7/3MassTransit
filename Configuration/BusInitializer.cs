﻿namespace Configuration
{
    using System;
    using MassTransit;
    using MassTransit.BusConfigurators;
    using MassTransit.Log4NetIntegration.Logging;

    public class BusInitializer
    {
        public static IServiceBus CreateBus(string queueName, Action<ServiceBusConfigurator> moreInitialization)
        {
            Log4NetLogger.Use();
            var bus = ServiceBusFactory.New(x =>
            {
                x.UseRabbitMq();
                x.ReceiveFrom(GetUri(queueName));
                moreInitialization(x);
            });

            return bus;
        }

        public static Uri GetUri(string queueName)
        {
            return new Uri("rabbitmq://localhost/" + queueName);
        }
    }
}
