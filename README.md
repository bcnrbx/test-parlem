# README #

### MySQL ###

```
docker run -p 3322:3306 --name parlem-mariadb -e MARIADB_ROOT_PASSWORD=admin1234 -d mariadb:latest --lower-case-table-names=1
```

### Migrations ###

```
dotnet ef migrations add P01 --project .\Parlem.DAL\Parlem.DAL.csproj --startup-project .\Parlem.API\Parlem.API.csproj --context ParlemDBContext
dotnet ef database update --project .\Parlem.DAL\Parlem.DAL.csproj --startup-project .\Parlem.API\Parlem.API.csproj --context ParlemDBContext
```