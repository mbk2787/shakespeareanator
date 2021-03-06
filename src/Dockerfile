#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Shakespeareanator.Api/Shakespeareanator.Api.csproj", "Shakespeareanator.Api/"]
COPY ["Shakespeareanator.Services/Shakespeareanator.Services.csproj", "Shakespeareanator.Services/"]
COPY ["Shakespeareanator.Utils/Shakespeareanator.Utils.csproj", "Shakespeareanator.Utils/"]
COPY ["Clients/Shakespeareanator.FunTranslations/Shakespeareanator.FunTranslations.csproj", "Clients/Shakespeareanator.FunTranslations/"]
COPY ["Clients/Shakespeareanator.Pokemon/Shakespeareanator.Pokemon.csproj", "Clients/Shakespeareanator.Pokemon/"]
RUN dotnet restore "Shakespeareanator.Api/Shakespeareanator.Api.csproj"
COPY . .

WORKDIR "/src/Tests/Shakespeareanator.Tests"
RUN dotnet test

WORKDIR "/src/Shakespeareanator.Api"
RUN dotnet build "Shakespeareanator.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Shakespeareanator.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "Shakespeareanator.Api.dll"]
CMD ASPNETCORE_URLS=http://*:$PORT dotnet Shakespeareanator.Api.dll