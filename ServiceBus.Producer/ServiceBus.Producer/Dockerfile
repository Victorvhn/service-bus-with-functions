#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["ServiceBus.Producer/ServiceBus.Producer.csproj", "ServiceBus.Producer/"]
RUN dotnet restore "ServiceBus.Producer/ServiceBus.Producer.csproj"
COPY . .
WORKDIR "/src/ServiceBus.Producer"
RUN dotnet build "ServiceBus.Producer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ServiceBus.Producer.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ServiceBus.Producer.dll"]
#
#FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
#
#WORKDIR /src
#COPY . .
#
#RUN dotnet restore "ServiceBus.Producer.csproj"
#RUN dotnet publish "ServiceBus.Producer.csproj" -c Release -o /src/ServiceBus.Producer/out --no-restore
#
#FROM build AS publish
#RUN dotnet publish "ServiceBus.Producer.csproj" -c Release -o /app/publish
#
#FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS runtime
#
#COPY --from=build /src/ServiceBus.Producer/out .
#ENTRYPOINT ["dotnet", "ServiceBus.Producer.dll"]
#
#EXPOSE 80
#EXPOSE 443