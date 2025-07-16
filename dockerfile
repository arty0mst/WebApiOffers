FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app/WebApiOffer
COPY . .

RUN dotnet publish -c Release -o /app/WebApiOffer/publish

FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app/Release
COPY --from=build /app/WebApiOffer/publish .
ENTRYPOINT [ "dotnet", "WebApiOffer.dll" ]