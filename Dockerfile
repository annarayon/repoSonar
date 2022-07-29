# syntax =docker/dockerfile:1

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

# creates a working directory
WORKDIR /app

# copies files from local to container
COPY . .
RUN dotnet restore
RUN dotnet publish -c Release -o /out

FROM mcr.microsoft.com/dotnet/aspnet:6.0

COPY --from=build /out .
ENTRYPOINT ["dotnet","REInvestment.dll"]
EXPOSE 3000