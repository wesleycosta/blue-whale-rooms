using Microsoft.Extensions.Configuration;
using Orangotango.Core.Bus;
using Orangotango.Core.Bus.Abstractions;
using Orangotango.Events.Rooms.Category;

namespace Orangotango.Rooms.Application;

public class TopologyConfig : IBusConfiguration
{
    public BusConfiguration GetConfiguration(IConfiguration configuration)
    {
        var topologyReservationsSection = GetTopologyReservationsSection(configuration);
        var exchangeNameReservations = topologyReservationsSection[nameof(PublishConfiguration.ExchangeName)];
        var queueNameReservations = topologyReservationsSection[nameof(PublishEventConfig.QueueName)];

        return new BusConfiguration()
        {
            Publishes =
            [
                new PublishConfiguration
                {
                    ExchangeName = exchangeNameReservations,
                    Configs = GetPublishEventConfigReservations(queueNameReservations)
                }
            ]
        };
    }

    private static IConfigurationSection GetTopologyReservationsSection(IConfiguration configuration)
        => configuration.GetSection("Topology")
           .GetSection("Reservations");

    private static IEnumerable<Type> GetEventsTypeToReservations()
    {
        yield return typeof(CategoryUpsertedEvent);
        yield return typeof(CategoryRemovedEvent);
        yield return typeof(RoomUpsertedEvent);
        yield return typeof(RoomUpsertedEvent);
    }

    private static IEnumerable<PublishEventConfig> GetPublishEventConfigReservations(string queueName)
    {
        var eventsToReservations = GetEventsTypeToReservations();
        return eventsToReservations.Select(type => new PublishEventConfig
        {
            EventType = type,
            QueueName = queueName
        });
    }
}
