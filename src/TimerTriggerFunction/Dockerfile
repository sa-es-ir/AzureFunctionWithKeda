FROM mcr.microsoft.com/dotnet/sdk:6.0 AS installer-env

# Build requires 3.1 SDK
COPY --from=mcr.microsoft.com/dotnet/core/sdk:3.1 /usr/share/dotnet /usr/share/dotnet

WORKDIR /src
COPY ["src/Suxxeed.Analytixx.CronFunctions/Suxxeed.Analytixx.CronFunctions.csproj", "src/Suxxeed.Analytixx.CronFunctions/"]
COPY ["src/Suxxeed.Analytixx.Data/Suxxeed.Analytixx.Data.csproj", "src/Suxxeed.Analytixx.Data/"]
COPY ["src/Suxxeed.Analytixx.Domain/Suxxeed.Analytixx.Domain.csproj", "src/Suxxeed.Analytixx.Domain/"]

COPY . /src/dotnet-function-app
RUN cd /src/dotnet-function-app && \
    mkdir -p /home/site/wwwroot && \
    dotnet publish "src/Suxxeed.Analytixx.CronFunctions/Suxxeed.Analytixx.CronFunctions.csproj" --output /home/site/wwwroot

# To enable ssh & remote debugging on app service change the base image to the one below
# FROM mcr.microsoft.com/azure-functions/dotnet:4-appservice
FROM mcr.microsoft.com/azure-functions/dotnet:4
ENV AzureWebJobsScriptRoot=/home/site/wwwroot \
    AzureFunctionsJobHost__Logging__Console__IsEnabled=true

COPY --from=installer-env ["/home/site/wwwroot", "/home/site/wwwroot"]