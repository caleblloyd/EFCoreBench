#!/bin/bash

docker container rm -f efbench-mysql
docker container run -d \
    --name efbench-mysql \
    -e 'MYSQL_ROOT_PASSWORD=test123!' \
    -p 48100:3306 \
    mysql:5.7

docker container rm -f efbench-postgresql
docker container run -d \
    --name efbench-postgresql \
    -e 'POSTGRES_PASSWORD=test123!' \
    -p 48101:5432 \
    postgres:9.6.4

docker container rm -f efbench-sqlserver
docker container run -d \
    --name efbench-sqlserver \
    -e 'ACCEPT_EULA=Y' \
    -e 'SA_PASSWORD=test123!' \
    -p 48102:1433 \
    microsoft/mssql-server-linux:rc2
