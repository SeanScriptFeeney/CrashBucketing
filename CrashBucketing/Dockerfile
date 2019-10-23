 FROM mcr.microsoft.com/dotnet/core/aspnet:3.0 AS base
 WORKDIR /app

 FROM mcr.microsoft.com/dotnet/core/sdk:3.0 AS build
 WORKDIR /src
 COPY ["CrashBucketing.csproj", "CrashBucketing/"]
 RUN dotnet restore "CrashBucketing/CrashBucketing.csproj"
 COPY . CrashBucketing/
 WORKDIR /src/CrashBucketing
 RUN dotnet build "CrashBucketing.csproj" -c Release -o /app

 #Node required for npm
 FROM node:10.16.3 as nodebuilder

 # set working directory
 RUN mkdir /usr/src/app
 WORKDIR /usr/src/app

# # install and cache app dependencies and add the app
 COPY ClientApp/. /usr/src/app
 RUN npm install && npm run build --prod

# #End Angular build
 FROM base AS final
 WORKDIR /app
 COPY --from=build /app .
 RUN mkdir -p /app/ClientApp/dist
 COPY --from=nodebuilder /usr/src/app/dist/. /app/ClientApp/dist/
 ENTRYPOINT ["dotnet", "CrashBucketing.dll"]

# # Step 1 : docker build -t crashbuckets:v1.0 .
# # Step 2 : docker run --name crshbuckets -p 5000:80 -d crashbuckets:v1.0
# # Step 3 : navigate to localhost:5000