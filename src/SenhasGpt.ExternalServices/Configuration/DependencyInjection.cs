using Microsoft.Extensions.DependencyInjection;
using System.Security.Authentication;
using SenhasGpt.Domain.IServices;
using Polly.Extensions.Http;
using Polly.Timeout;
using Polly;

namespace SenhasGpt.ExternalServices.Configuration;
public static class DependencyInjection
{
    public static IServiceCollection RegisterExternalServices(this IServiceCollection services)
    {
        services.AddHttpClient<IWsChatGpt, WsChatGpt>() 
                .ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler() { SslProtocols = SslProtocols.Tls12 | SslProtocols.Tls13 })
                .AddPolicyHandler(RetryPolicy())
                .AddPolicyHandler(TimeoutPolicy());

        return services;
    }

    private static IAsyncPolicy<HttpResponseMessage> TimeoutPolicy() => Policy.TimeoutAsync<HttpResponseMessage>(TimeSpan.FromMinutes(3));

    private static IAsyncPolicy<HttpResponseMessage> RetryPolicy() =>
        HttpPolicyExtensions
            .HandleTransientHttpError()
            .OrResult(msg => msg.StatusCode == System.Net.HttpStatusCode.NotFound)
            .Or<TimeoutRejectedException>()
            .WaitAndRetryAsync(3, sleepDuration => TimeSpan.FromSeconds(2));
}
