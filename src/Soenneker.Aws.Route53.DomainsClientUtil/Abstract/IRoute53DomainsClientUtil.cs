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
    /// Gets sync.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The result of the operation.</returns>
    AmazonRoute53DomainsClient GetSync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets the value.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task containing the result of the operation.</returns>
    ValueTask<AmazonRoute53DomainsClient> Get(CancellationToken cancellationToken = default);
}
