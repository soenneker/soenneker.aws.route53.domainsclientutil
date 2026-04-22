using Soenneker.Aws.Route53.DomainsClientUtil.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.Aws.Route53.DomainsClientUtil.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class Route53DomainsClientUtilTests : HostedUnitTest
{
    private readonly IRoute53DomainsClientUtil _util;

    public Route53DomainsClientUtilTests(Host host) : base(host)
    {
        _util = Resolve<IRoute53DomainsClientUtil>(true);
    }

    [Test]
    public void Default()
    {

    }
}
