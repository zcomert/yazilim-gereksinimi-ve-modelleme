dotnet new sln -n EmployeeApp

dotnet new classlib -o Entities
dotnet new classlib -o Repositories
dotnet new webapi -o EmployeeApi

dotnet sln EmployeeApp.sln add Entities
dotnet sln EmployeeApp.sln add Repositories
dotnet sln EmployeeApp.sln add EmployeeApi

dotnet add Repositories reference Entities
dotnet add EmployeeApi reference Repositories
dotnet add EmployeeApi reference Entities

dotnet add Repositories package Microsoft.EntityFrameworkCore --version 7.0.0
dotnet add Repositories package Microsoft.EntityFrameworkCore.Tools --version 7.0.0
dotnet add Repositories package Microsoft.EntityFrameworkCore.Sqlite --version 7.0.0

dotnet add EmployeeApi package Microsoft.EntityFrameworkCore.Design --version 7.0.0

