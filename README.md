[![](https://img.shields.io/nuget/v/soenneker.aws.route53.domainsclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.aws.route53.domainsclientutil/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.aws.route53.domainsclientutil/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.aws.route53.domainsclientutil/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.aws.route53.domainsclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.aws.route53.domainsclientutil/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.aws.route53.domainsclientutil/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.aws.route53.domainsclientutil/actions/workflows/codeql.yml)

# Soenneker.Aws.Route53.DomainsClientUtil

A .NET thread-safe singleton For AWS's Route53 domain client, AmazonRoute53DomainsClient.

## Install

```bash
dotnet add package Soenneker.Aws.Route53.DomainsClientUtil
```

## Quick start

```csharp
using Soenneker.Aws.Route53.DomainsClientUtil.Registrars;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
var result = services.AddRoute53DomainsClientUtilAsSingleton();
```

Adds `IRoute53DomainsClientUtil` as a singleton service.

## What you get

- `IRoute53DomainsClientUtil` — A .NET thread-safe singleton For AWS's Route53 domain client, AmazonRoute53DomainsClient.
- `Route53DomainsClientUtilRegistrar` — A .NET thread-safe singleton For AWS's Route53 domain client, AmazonRoute53DomainsClient.

## API at a glance

| API | What it does | Result / important behavior |
| --- | --- | --- |
| `Route53DomainsClientUtilRegistrar.AddRoute53DomainsClientUtilAsSingleton(services)` | Adds `IRoute53DomainsClientUtil` as a singleton service. | The same service collection, so additional registrations can be chained. |
| `Route53DomainsClientUtilRegistrar.AddRoute53DomainsClientUtilAsScoped(services)` | Adds `IRoute53DomainsClientUtil` as a scoped service. | The same service collection, so additional registrations can be chained. |

## Practical notes

- Reuse the registered client instead of constructing one per operation.
- Calls that return a cached or singleton value reuse the same instance until the owning service is disposed.
- Dispose instances you own when their scope ends so held resources can be released.
