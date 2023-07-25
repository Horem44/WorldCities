using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Net.NetworkInformation;

namespace WorldCities.Api.Middlewares
{
    public class ICMPHealthCheck : IHealthCheck
    {
        private readonly string Host;
        private readonly int HealthyRoundtripTime;

        public ICMPHealthCheck(string host, int healthyRoundtripTime)
        {
            Host = host;
            HealthyRoundtripTime = healthyRoundtripTime;
        }

        public async Task<HealthCheckResult> CheckHealthAsync(
            HealthCheckContext context,
            CancellationToken cancellationToken = default
        )
        {
            try
            {
                using var ping = new Ping();
                var reply = await ping.SendPingAsync(Host);

                switch (reply.Status)
                {
                    case IPStatus.Success:
                        string msg = $"ICMP to {Host} took {reply.RoundtripTime} ms.";

                        return reply.RoundtripTime > HealthyRoundtripTime
                            ? HealthCheckResult.Degraded(msg)
                            : HealthCheckResult.Healthy(msg);

                    default:
                        string err = $"ICMP to {Host} failed: {reply.Status}";

                        return HealthCheckResult.Unhealthy(err);
                }
            }
            catch (Exception e)
            {
                string err = $"ICMP to {Host} failed: {e.Message}";

                return HealthCheckResult.Unhealthy(err);
            }
        }
    }

    public static class HealthCheckExtensions
    {
        public static IHealthChecksBuilder AddICMPHealthCheck(
            this IHealthChecksBuilder checksBuilder,
            int ping,
            string host
        )
        {
            checksBuilder.AddCheck("ICMP", new ICMPHealthCheck(host, ping));
            return checksBuilder;
        }
    }
}
