using Amazon.Route53Domains;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Aws.Route53.DomainsClientUtil.Abstract;

/// <summary>
/// A .NET thread-safe singleton For AWS's Route53 domain client, AmazonRoute53DomainsClient
/// </summary>
public interface IRoute53DomainsClientUtil : IDisposable, IAsyncDisposable
{
    /// <summary>
    /// Returns the configured amazon Route53 Domains Client used by the route53 domains client.
    /// </summary>
    /// <param name="cancellationToken">Token used to cancel the operation.</param>
    /// <returns>The requested amazon Route53 Domains Client.</returns>
    AmazonRoute53DomainsClient GetSync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns the configured amazon Route53 Domains Client used by the route53 domains client.
    /// </summary>
    /// <param name="cancellationToken">Token used to cancel the operation.</param>
    /// <returns>A task whose result is the requested amazon Route53 Domains Client.</returns>
    ValueTask<AmazonRoute53DomainsClient> Get(CancellationToken cancellationToken = default);
}
