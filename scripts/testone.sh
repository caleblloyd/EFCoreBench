#!/usr/bin/env bash
cd $(dirname $0)

./rebuild.sh $1
cd ../
dotnet run -c $1 testPerformance 3 50 100
