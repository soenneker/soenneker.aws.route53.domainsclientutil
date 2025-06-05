using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Aws.BasicCredentials.Registrars;
using Soenneker.Aws.Route53.DomainsClientUtil.Abstract;

namespace Soenneker.Aws.Route53.DomainsClientUtil.Registrars;

/// <summary>
/// A .NET thread-safe singleton For AWS's Route53 domain client, AmazonRoute53DomainsClient
/// </summary>
public static class Route53DomainsClientUtilRegistrar
{
    /// <summary>
    /// Adds <see cref="IRoute53DomainsClientUtil"/> as a singleton service. <para/>
    /// </summary>
    public static IServiceCollection AddRoute53DomainsClientUtilAsSingleton(this IServiceCollection services)
    {
        services.AddBasicAwsCredentialsUtilAsSingleton().TryAddSingleton<IRoute53DomainsClientUtil, Route53DomainsClientUtil>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="IRoute53DomainsClientUtil"/> as a scoped service. <para/>
    /// </summary>
    public static IServiceCollection AddRoute53DomainsClientUtilAsScoped(this IServiceCollection services)
    {
        services.AddBasicAwsCredentialsUtilAsSingleton().TryAddScoped<IRoute53DomainsClientUtil, Route53DomainsClientUtil>();

        return services;
    }
}