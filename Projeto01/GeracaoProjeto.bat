echo 'Criacao dos Projetos'
dotnet new console -n Projeto.ConsoleApp -o Projeto.ConsoleApp
dotnet new classlib -n Projeto.LogicaNegocio -o Projeto.LogicaNegocio
dotnet new classlib -n Projeto.Modelo -o Projeto.Modelo
dotnet new mstest -n Projeto.Tests -o Projeto.Tests

echo 'Criacao da Solucao'
dotnet new sln -n Solucao
dotnet sln add Projeto.ConsoleApp
dotnet sln add Projeto.LogicaNegocio
dotnet sln add Projeto.Modelo
dotnet sln add Projeto.Tests

echo 'Preparacao dos Testes'
dotnet add Projeto.ConsoleApp/Projeto.ConsoleApp.csproj reference Projeto.LogicaNegocio/Projeto.LogicaNegocio.csproj
dotnet add Projeto.Tests/Projeto.Tests.csproj reference Projeto.LogicaNegocio/Projeto.LogicaNegocio.csproj

echo 'Validacao do Preparo'
dotnet restore
dotnet build
dotnet test
