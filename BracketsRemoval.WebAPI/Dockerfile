#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app

# Copy everything
COPY . ./
# Restore as distinct layers
RUN dotnet restore
# Build and publish a release
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "BracketsRemoval.WebAPI.dll"]


#FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
#WORKDIR /app
#EXPOSE 80
#EXPOSE 443
#
#FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
#WORKDIR /src
#COPY ["BracketsRemoval.WebAPI/BracketsRemoval.WebAPI.csproj", "BracketsRemoval.WebAPI/"]
#RUN dotnet restore "BracketsRemoval.WebAPI/BracketsRemoval.WebAPI.csproj"
#COPY . .
#WORKDIR "/src/BracketsRemoval.WebAPI"
#RUN dotnet build "BracketsRemoval.WebAPI.csproj" -c Release -o /app/build
#
#FROM build AS publish
#RUN dotnet publish "BracketsRemoval.WebAPI.csproj" -c Release -o /app/publish

#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "BracketsRemoval.WebAPI.dll"]
