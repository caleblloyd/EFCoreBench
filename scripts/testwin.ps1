#!/usr/bin/env powershell

Push-Location (Join-Path (Split-Path $MyInvocation.MyCommand.Path) "../")

dotnet run -c SQLSERVER testPerformance 3 50 100

Pop-Location
