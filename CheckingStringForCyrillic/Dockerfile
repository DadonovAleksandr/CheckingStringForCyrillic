﻿FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["CheckingStringForCyrillic/CheckingStringForCyrillic.csproj", "CheckingStringForCyrillic/"]
RUN dotnet restore "CheckingStringForCyrillic/CheckingStringForCyrillic.csproj"
COPY . .
WORKDIR "/src/CheckingStringForCyrillic"
RUN dotnet build "CheckingStringForCyrillic.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CheckingStringForCyrillic.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CheckingStringForCyrillic.dll"]
