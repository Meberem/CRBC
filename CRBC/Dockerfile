FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
EXPOSE 5000

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY CRBC/CRBC.csproj CRBC/
RUN dotnet restore CRBC/CRBC.csproj
COPY . .
WORKDIR /src/CRBC
RUN dotnet build CRBC.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish CRBC.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "CRBC.dll"]
