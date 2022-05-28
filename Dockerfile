FROM node:14-alpine as client

WORKDIR /client
COPY ["client/package.json", "./"]
COPY ["client/package-lock.json", "./"]
ENV GENERATE_SOURCEMAP=false
RUN npm ci
COPY ["client/", "./"]
RUN npm run build


FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["server/WebAPI/WebAPI.csproj", "WebAPI/"]
COPY ["server/Domain/Domain.csproj", "Domain/"]
COPY ["server/Application/Application.csproj", "Application/"]
COPY ["server/Infrastructure/Infrastructure.csproj", "Infrastructure/"]

RUN dotnet restore "WebAPI/WebAPI.csproj"
COPY server/ .
WORKDIR "/src/WebAPI"

RUN dotnet build "WebAPI.csproj" -c Release -o /app/build

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS prod
WORKDIR /app
EXPOSE 80
COPY --from=build /app/build ./
COPY --from=client /client/build ./wwwroot
ENTRYPOINT ["dotnet", "WebAPI.dll"]