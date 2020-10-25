#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM node:latest AS client 
ARG skip_client_build=false 
WORKDIR /app 
COPY ICS.WepApplication/ClientApp . 
RUN [[ ${skip_client_build} = true ]] && echo "Skipping npm install" || npm install
RUN [[ ${skip_client_build} = true ]] && echo "Skipping npm install angular" || npm install -g @angular/cli
RUN [[ ${skip_client_build} = true ]] && mkdir dist || npm run-script build

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["ICS.WepApplication/ICS.WepApplication.csproj", "ICS.WepApplication/"]
COPY ["ICS.Domain/ICS.Domain.csproj", "ICS.Domain/"]
COPY ["Shared.Contracts/Shared.Contracts.csproj", "Shared.Contracts/"]
COPY ["ICS.Application.Commands/ICS.Application.Commands.csproj", "ICS.Application.Commands/"]
RUN dotnet restore "ICS.WepApplication/ICS.WepApplication.csproj"
COPY . .
WORKDIR "/src/ICS.WepApplication"
RUN dotnet build "ICS.WepApplication.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ICS.WepApplication.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY --from=client /app/dist /app/dist
ENTRYPOINT ["dotnet", "ICS.WepApplication.dll"]
