# https://hub.docker.com/_/microsoft-dotnet
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /source

# copy csproj and restore as distinct layers
COPY backend/*.sln .
COPY backend/backend/*.csproj ./backend/
RUN dotnet restore

# copy everything else and build app
COPY backend/backend/. ./backend/
WORKDIR /source/backend
#RUN dotnet publish -c release -o /app
ENTRYPOINT [ "dotnet", "run" ]

# final stage/image
#FROM mcr.microsoft.com/dotnet/aspnet:6.0
#WORKDIR /app
#COPY --from=build /app ./
#EXPOSE 8080
#CMD /bin/bash +x ./migrations.sh
#ENTRYPOINT ["dotnet", "backend.dll"]