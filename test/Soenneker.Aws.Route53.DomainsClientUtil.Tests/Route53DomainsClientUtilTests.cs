using Soenneker.Aws.Route53.DomainsClientUtil.Abstract;
using Soenneker.Tests.FixturedUnit;
using Xunit;

namespace Soenneker.Aws.Route53.DomainsClientUtil.Tests;

[Collection("Collection")]
public sealed class Route53DomainsClientUtilTests : FixturedUnitTest
{
    private readonly IRoute53DomainsClientUtil _util;

    public Route53DomainsClientUtilTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
        _util = Resolve<IRoute53DomainsClientUtil>(true);
    }

    [Fact]
    public void Default()
    {

    }
}
