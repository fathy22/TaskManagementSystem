FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

WORKDIR /src
COPY ["src/TaskManagementSystem.Web.Host/TaskManagementSystem.Web.Host.csproj", "src/TaskManagementSystem.Web.Host/"]
COPY ["src/TaskManagementSystem.Web.Core/TaskManagementSystem.Web.Core.csproj", "src/TaskManagementSystem.Web.Core/"]
COPY ["src/TaskManagementSystem.Application/TaskManagementSystem.Application.csproj", "src/TaskManagementSystem.Application/"]
COPY ["src/TaskManagementSystem.Core/TaskManagementSystem.Core.csproj", "src/TaskManagementSystem.Core/"]
COPY ["src/TaskManagementSystem.EntityFrameworkCore/TaskManagementSystem.EntityFrameworkCore.csproj", "src/TaskManagementSystem.EntityFrameworkCore/"]
WORKDIR "/src/src/TaskManagementSystem.Web.Host"
RUN dotnet restore 

WORKDIR /src
COPY ["src/TaskManagementSystem.Web.Host", "src/TaskManagementSystem.Web.Host"]
COPY ["src/TaskManagementSystem.Web.Core", "src/TaskManagementSystem.Web.Core"]
COPY ["src/TaskManagementSystem.Application", "src/TaskManagementSystem.Application"]
COPY ["src/TaskManagementSystem.Core", "src/TaskManagementSystem.Core"]
COPY ["src/TaskManagementSystem.EntityFrameworkCore", "src/TaskManagementSystem.EntityFrameworkCore"]
WORKDIR "/src/src/TaskManagementSystem.Web.Host"
RUN dotnet publish -c Release -o /publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:7.0
EXPOSE 80
WORKDIR /app
COPY --from=build /publish .
ENTRYPOINT ["dotnet", "TaskManagementSystem.Web.Host.dll"]
