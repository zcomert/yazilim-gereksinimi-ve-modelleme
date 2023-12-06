mkdir ChatApp
cd ChatApp

dotnet new sln -n ChatApp
dotnet new webapi -o ChatApi
dotnet new classlib -o ChatEntities
dotnet new classlib -o ChatRepositories

dotnet sln ChatApp.sln add ChatApi
dotnet sln ChatApp.sln add ChatEntities
dotnet sln ChatApp.sln add ChatRepositories

dotnet add ChatApi reference ChatRepositories
dotnet add ChatApi reference ChatEntities
dotnet add ChatRepositories reference ChatEntities

dotnet add ChatRepositories package Microsoft.EntityFrameworkCore --version 7.0.0
dotnet add ChatRepositories package Microsoft.EntityFrameworkCore.Tools --version 7.0.0
dotnet add ChatRepositories package Microsoft.EntityFrameworkCore.Sqlite --version 7.0.0

dotnet add ChatApi package Microsoft.EntityFrameworkCore.Design --version 7.0.0

code .