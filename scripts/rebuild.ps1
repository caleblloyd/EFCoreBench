#!/usr/bin/env powershell

Push-Location (Join-Path (Split-Path $MyInvocation.MyCommand.Path) "../")

Remove-Item (Join-Path "Migrations" "*.cs")
dotnet ef --configuration SQLSERVER database drop -f
dotnet ef --configuration SQLSERVER migrations add initial
dotnet ef --configuration SQLSERVER database update

Pop-Location
