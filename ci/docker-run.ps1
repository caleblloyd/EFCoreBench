#!/usr/bin/env powershell

docker container rm -f efbench-sqlserver
docker container run -d `
    --name efbench-sqlserver `
    -e 'ACCEPT_EULA=Y' `
    -e 'SA_PASSWORD=test123!' `
    -p 48102:1433 `
    microsoft/mssql-server-windows:vnext-rc1-windowsservercore-10.0.14393.1480
