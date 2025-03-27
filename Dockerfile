FROM mcr.microsoft.com/dotnet/sdk:7.0-alpine@sha256:1478c99b4bed8d297ccd000e0fdaf060cdfb281779f8c8aa47f031a09503c0d4 AS build
MAINTAINER Bengt Fredh <brf@digdir.no>

COPY src/cert-generator ./cert-generator
WORKDIR cert-generator/

RUN dotnet build cert-generator.csproj -o /app_output

FROM mcr.microsoft.com/dotnet/runtime:7.0-alpine@sha256:cc4d0d1b69099a4cb0cff57975f00e4248096bf301d1962b139b01828c84157f AS final
MAINTAINER Bengt Fredh <brf@digdir.no>

COPY --from=build /app_output /usr/local/bin/

WORKDIR /data
VOLUME /data
