# Install instructions

## Prerequisites

- Windows PowerShell 5.1 with .NET Framework 4.7.2+ or
- PowerShell Core 6.0 or greater on Windows, macOS and Linux

For a list of platforms that PowerShell Core is supported on [see](https://github.com/PowerShell/PowerShell#get-powershell).

## Getting the modules

Install from [PowerShell Gallery][psg-psrule] for all users (requires permissions)

```powershell
# Install PSRule module
Install-Module -Name 'PSRule';
```

Install from [PowerShell Gallery][psg-psrule] for current user only

```powershell
# Install PSRule module
Install-Module -Name 'PSRule' -Scope CurrentUser;
```

Save for offline use from PowerShell Gallery

```powershell
# Save PSRule module, in the .\modules directory
Save-Module -Name 'PSRule' -Path '.\modules';
```

> For pre-release versions the `-AllowPrerelease` switch must be added when calling `Install-Module` or `Save-Module`.

[psg-psrule]: https://www.powershellgallery.com/packages/PSRule