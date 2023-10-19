FROM mcr.microsoft.com/dotnet/sdk:7.0-alpine AS build
MAINTAINER Bengt Fredh <brf@digdir.no>

COPY src/cert-generator ./cert-generator
WORKDIR cert-generator/

RUN dotnet build cert-generator.csproj -o /app_output

FROM mcr.microsoft.com/dotnet/runtime:7.0-alpine AS final
MAINTAINER Bengt Fredh <brf@digdir.no>

COPY --from=build /app_output /usr/local/bin/

WORKDIR /data
VOLUME /data
