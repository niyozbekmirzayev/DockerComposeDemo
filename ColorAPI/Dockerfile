# Getting .net sdk as building environment
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env

# Creating a directory called /app in the container
WORKDIR /app

# Copying file ends with "csproj" to current directory in the container(/app) 
COPY *csproj ./

# Restoring used libraries
RUN dotnet restore 

# Copying everything to the /app directory
COPY . ./

# Publishing relese in /out directory 
RUN dotnet publish -c Relese -o out 

# Getting aspnet run time 
FROM mcr.microsoft.com/dotnet/aspnet:6.0

# Getting back to /app
WORKDIR /app

# Specifying listening port for http and https
EXPOSE 80
EXPOSE 81

# Copying app/out folder in build-env image to to current directory(/app)
COPY --from=build-env /app/out .

# Specifying commands to run when the container starts
ENTRYPOINT ["dotnet", "ColorAPI.dll"]