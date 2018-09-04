FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 50584
EXPOSE 44392

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY eShopTest.Presentation/eShopTest.Presentation.csproj eShopTest.Presentation/
COPY eShopTest.ApplicationService/eShopTest.ApplicationService.csproj eShopTest.ApplicationService/
COPY eShopTest.Domain/eShopTest.Domain.csproj eShopTest.Domain/
COPY eShopTest.Infra.IoC/eShopTest.Infra.IoC.csproj eShopTest.Infra.IoC/
COPY eShopTest.Infra.Data/eShopTest.Infra.Data.csproj eShopTest.Infra.Data/
RUN dotnet restore eShopTest.Presentation/eShopTest.Presentation.csproj
COPY . .
WORKDIR /src/eShopTest.Presentation
RUN dotnet build eShopTest.Presentation.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish eShopTest.Presentation.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "eShopTest.Presentation.dll"]
