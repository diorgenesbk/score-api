FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /app

COPY *.sln .
COPY Blue.Core/*.csproj ./Blue.Core/
COPY Blue.Domain/*.csproj ./Blue.Domain/
COPY Blue.Infrastructure/*.csproj ./Blue.Infrastructure/
COPY Blue.Service.Business/*.csproj ./Blue.Service.Business/
COPY Blue.Service.Proxy/*.csproj ./Blue.Service.Proxy/
RUN dotnet restore

COPY Blue.Core/. ./Blue.Core/
COPY Blue.Domain/. ./Blue.Domain/
COPY Blue.Infrastructure/. ./Blue.Infrastructure/
COPY Blue.Service.Business/. ./Blue.Service.Business/
COPY Blue.Service.Proxy/. ./Blue.Service.Proxy/
WORKDIR /app/Blue.Service.Proxy
RUN dotnet publish -c Release -o out

FROM microsoft/dotnet:2.2-aspnetcore-runtime AS runtime
WORKDIR /app
COPY --from=build /app/Blue.Service.Proxy/out ./
ENTRYPOINT ["dotnet", "Blue.Service.Proxy.dll"]