#!/usr/bin/env bash
cd $(dirname $0)

./testone.sh MYSQL
./testone.sh NPGSQL
./testone.sh SQLSERVER
