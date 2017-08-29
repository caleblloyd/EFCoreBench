# EF Core Benchmark

**Overview**

Runs a concurrency benchmark on 3 Databases on Linux:

- MySQL
- PostgreSQL
- SQL Server (Linux/Windows)

Each test uses async I/O and runs on 50 connections to Database:

1. Inserts 1 record 100 times on each connection
2. Selects 10 random records 100 times on each connection
3. Sleeps 16ms 100 times on each connection

**Running Tests**

Docker for Linux Containers (MySQL, PostgreSQL, SQL Server on Linux):

1. Start Docker Containers: `./ci/docker-run.sh`
2. Run Tests: `./scripts/testall.sh`

Docker for Windows Containers (SQL Server on Windows):

1. Start Docker Containers: `./ci/docker-run.ps1`
2. Adjust `config.json` with correct IP Addresses and port for SQL Server container
3. Run Tests: `./scripts/testwin.ps1`

**Results**

Results as of August 29, 2017.  All run on quad core i5 (Kaby Lake) with 16GB of RAM on Ubuntu 17.04 x64.

Database|EF Core Provider
-|-
MySQL 5.7.17|Pomelo.EntityFrameworkCore.MySql 2.0.0-rtm-10058
PostgreSQL 9.6.4|Npgsql.EntityFrameworkCore.PostgreSQL 2.0.0
SQL Server 2017 RC2 (Linux)|Microsoft.EntityFrameworkCore.SqlServer 2.0.0
SQL Server 2017 RC1 (Windows)|Microsoft.EntityFrameworkCore.SqlServer 2.0.0

Results reported are fastest time of 3 test runs.  Time is in seconds, lower is better.

Test|MySQL|PostgreSQL|SQL Server (Linux)|SQL Server (Windows)
-|-|-|-|-
Insert|2.43|1.94|6.02|1.97
Select|5.28|3.68|7.05|7.60
Sleep|2.54|1.87|4.07|3.12
