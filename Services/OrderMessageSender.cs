using System.Text.Json;
using Azure.Messaging.ServiceBus;
using Microsoft.Extensions.Options;
using WebCoreApi.Configurations;
using WebCoreApi.Models;

namespace WebCoreApi.Services;

public class OrderMessageSender
{
    private readonly ServiceBusSender _sender;

    public OrderMessageSender(IOptions<ServiceBusConfig> options)
    {
        var config = options.Value;
        var client = new ServiceBusClient(config.ConnectionString);
        _sender = client.CreateSender(config.QueueName);
    }

    public async Task CreateOrderAsync(OrderCreateRequestDto dto)
    {
        var json = JsonSerializer.Serialize(dto);
        var message = new ServiceBusMessage(json);
        await _sender.SendMessageAsync(message);
    }
}