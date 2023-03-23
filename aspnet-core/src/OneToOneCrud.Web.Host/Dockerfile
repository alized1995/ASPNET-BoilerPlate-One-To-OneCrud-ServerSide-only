FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

WORKDIR /src
COPY ["src/OneToOneCrud.Web.Host/OneToOneCrud.Web.Host.csproj", "src/OneToOneCrud.Web.Host/"]
COPY ["src/OneToOneCrud.Web.Core/OneToOneCrud.Web.Core.csproj", "src/OneToOneCrud.Web.Core/"]
COPY ["src/OneToOneCrud.Application/OneToOneCrud.Application.csproj", "src/OneToOneCrud.Application/"]
COPY ["src/OneToOneCrud.Core/OneToOneCrud.Core.csproj", "src/OneToOneCrud.Core/"]
COPY ["src/OneToOneCrud.EntityFrameworkCore/OneToOneCrud.EntityFrameworkCore.csproj", "src/OneToOneCrud.EntityFrameworkCore/"]
WORKDIR "/src/src/OneToOneCrud.Web.Host"
RUN dotnet restore 

WORKDIR /src
COPY ["src/OneToOneCrud.Web.Host", "src/OneToOneCrud.Web.Host"]
COPY ["src/OneToOneCrud.Web.Core", "src/OneToOneCrud.Web.Core"]
COPY ["src/OneToOneCrud.Application", "src/OneToOneCrud.Application"]
COPY ["src/OneToOneCrud.Core", "src/OneToOneCrud.Core"]
COPY ["src/OneToOneCrud.EntityFrameworkCore", "src/OneToOneCrud.EntityFrameworkCore"]
WORKDIR "/src/src/OneToOneCrud.Web.Host"
RUN dotnet publish -c Release -o /publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:7.0
EXPOSE 80
WORKDIR /app
COPY --from=build /publish .
ENTRYPOINT ["dotnet", "OneToOneCrud.Web.Host.dll"]
