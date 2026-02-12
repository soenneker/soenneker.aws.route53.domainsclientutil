using Amazon;
using Amazon.Route53Domains;
using Amazon.Runtime;
using Soenneker.Aws.BasicCredentials.Abstract;
using Soenneker.Aws.Route53.DomainsClientUtil.Abstract;
using Soenneker.Extensions.ValueTask;
using Soenneker.Utils.AsyncSingleton;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Aws.Route53.DomainsClientUtil;

/// <inheritdoc cref="IRoute53DomainsClientUtil"/>
public sealed class Route53DomainsClientUtil : IRoute53DomainsClientUtil
{
    private readonly AsyncSingleton<AmazonRoute53DomainsClient> _client;
    private readonly IBasicAwsCredentialsUtil _credentialsUtil;

    public Route53DomainsClientUtil(IBasicAwsCredentialsUtil credentialsUtil)
    {
        _credentialsUtil = credentialsUtil;
        _client = new AsyncSingleton<AmazonRoute53DomainsClient>(CreateClient);
    }

    private async ValueTask<AmazonRoute53DomainsClient> CreateClient(CancellationToken token)
    {
        BasicAWSCredentials credentials = await _credentialsUtil.Get(token).NoSync();

        var config = new AmazonRoute53DomainsConfig
        {
            RegionEndpoint = RegionEndpoint.USEast1
        };

        return new AmazonRoute53DomainsClient(credentials, config);
    }

    public AmazonRoute53DomainsClient GetSync(CancellationToken cancellationToken = default)
    {
        return _client.GetSync(cancellationToken);
    }

    public ValueTask<AmazonRoute53DomainsClient> Get(CancellationToken cancellationToken = default)
    {
        return _client.Get(cancellationToken);
    }

    public void Dispose()
    {
        _client.Dispose();
    }

    public ValueTask DisposeAsync()
    {
        return _client.DisposeAsync();
    }
}