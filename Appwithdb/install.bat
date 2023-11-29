dotnet new sln -n Appwithdb

dotnet new classlib -o Entities
dotnet new classlib -o Repositories
dotnet new webapi -o ProductApi

dotnet sln Appwithdb.sln add Entities
dotnet sln Appwithdb.sln add Repositories
dotnet sln Appwithdb.sln add ProductApi

dotnet add ProductApi reference Entities
dotnet add ProductApi reference Repositories

dotnet add Repositories reference Entities

dotnet add Repositories package Microsoft.EntityFrameworkCore --version 7.0.0
dotnet add Repositories package Microsoft.EntityFrameworkCore.Tools --version 7.0.0
dotnet add Repositories package Microsoft.EntityFrameworkCore.Sqlite --version 7.0.0

dotnet add ProductApi package Microsoft.EntityFrameworkCore.Design --version 7.0.0


