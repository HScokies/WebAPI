## init.sh
```sh
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package System.ComponentModel.Annotations
clear
rm -- "$0"
```
## dc.sh [args]
```sh
docker-compose -f "docker-compose.yml" [args]
```