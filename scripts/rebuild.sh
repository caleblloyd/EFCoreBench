#!/usr/bin/env bash
cd $(dirname $0)
cd ../

set -e
rm -f Migrations/*.cs
dotnet ef --configuration $1 database drop -f
dotnet ef --configuration $1 migrations add initial
dotnet ef --configuration $1 database update
