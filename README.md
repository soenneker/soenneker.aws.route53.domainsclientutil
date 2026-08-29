[![](https://img.shields.io/nuget/v/soenneker.aws.route53.domainsclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.aws.route53.domainsclientutil/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.aws.route53.domainsclientutil/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.aws.route53.domainsclientutil/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.aws.route53.domainsclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.aws.route53.domainsclientutil/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.aws.route53.domainsclientutil/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.aws.route53.domainsclientutil/actions/workflows/codeql.yml)

# Soenneker.Aws.Route53.DomainsClientUtil

Creates and caches an authenticated AWS SDK `AmazonRoute53DomainsClient` for dependency-injected applications.

## Installation

```bash
dotnet add package Soenneker.Aws.Route53.DomainsClientUtil
```

## Configuration

```json
{
  "Aws": {
    "AccessKey": "access-key-id",
    "SecretKey": "secret-access-key"
  }
}
```

Keep these values in a secret provider rather than source-controlled configuration.

## Registration and use

```csharp
using Amazon.Route53Domains;
using Amazon.Route53Domains.Model;
using Soenneker.Aws.Route53.DomainsClientUtil.Abstract;
using Soenneker.Aws.Route53.DomainsClientUtil.Registrars;

builder.Services.AddRoute53DomainsClientUtilAsSingleton();

public sealed class DomainLookup(IRoute53DomainsClientUtil clientUtil)
{
    public async Task<GetDomainDetailResponse> Get(
        string domain,
        CancellationToken cancellationToken)
    {
        AmazonRoute53DomainsClient client =
            await clientUtil.Get(cancellationToken);

        return await client.GetDomainDetailAsync(
            new GetDomainDetailRequest { DomainName = domain },
            cancellationToken);
    }
}
```

The registrar includes `Soenneker.Aws.BasicCredentials`. The client is configured for `RegionEndpoint.USEast1`, the Route 53 Domains endpoint used by this utility.

## Lifecycle

- The AWS client and credentials are initialized once and cached.
- `GetSync()` exposes the same cached client for synchronous construction paths.
- Configuration changes do not rotate an already-created client.
- Use the scoped registrar only when the wrapper should be scoped; its credential dependency remains singleton.
- Let DI dispose the utility so the AWS SDK client is released correctly.

For common registration, availability, nameserver, and DNSSEC operations, use the higher-level `Soenneker.Aws.Route53.Domains` package.
