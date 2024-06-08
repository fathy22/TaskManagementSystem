FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

RUN dotnet tool install -g Microsoft.Web.LibraryManager.Cli
RUN ln -s ~/.dotnet/tools/libman /usr/local/bin/libman

WORKDIR /src
COPY ["src/TaskManagementSystem.Web.Mvc/TaskManagementSystem.Web.Mvc.csproj", "src/TaskManagementSystem.Web.Mvc/"]
COPY ["src/TaskManagementSystem.Web.Core/TaskManagementSystem.Web.Core.csproj", "src/TaskManagementSystem.Web.Core/"]
COPY ["src/TaskManagementSystem.Application/TaskManagementSystem.Application.csproj", "src/TaskManagementSystem.Application/"]
COPY ["src/TaskManagementSystem.Core/TaskManagementSystem.Core.csproj", "src/TaskManagementSystem.Core/"]
COPY ["src/TaskManagementSystem.EntityFrameworkCore/TaskManagementSystem.EntityFrameworkCore.csproj", "src/TaskManagementSystem.EntityFrameworkCore/"]
WORKDIR "/src/src/TaskManagementSystem.Web.Mvc"
RUN dotnet restore 

WORKDIR /src
COPY ["src/TaskManagementSystem.Web.Mvc", "src/TaskManagementSystem.Web.Mvc"]
COPY ["src/TaskManagementSystem.Web.Core", "src/TaskManagementSystem.Web.Core"]
COPY ["src/TaskManagementSystem.Application", "src/TaskManagementSystem.Application"]
COPY ["src/TaskManagementSystem.Core", "src/TaskManagementSystem.Core"]
COPY ["src/TaskManagementSystem.EntityFrameworkCore", "src/TaskManagementSystem.EntityFrameworkCore"]
WORKDIR "/src/src/TaskManagementSystem.Web.Mvc"
RUN libman restore
RUN dotnet publish -c Release -o /publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:7.0
EXPOSE 80
WORKDIR /app
COPY --from=build /publish .
ENTRYPOINT ["dotnet", "TaskManagementSystem.Web.Mvc.dll"]
