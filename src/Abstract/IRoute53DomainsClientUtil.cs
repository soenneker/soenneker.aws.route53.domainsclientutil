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
    AmazonRoute53DomainsClient GetSync(CancellationToken cancellationToken = default);

    ValueTask<AmazonRoute53DomainsClient> Get(CancellationToken cancellationToken = default);
}
