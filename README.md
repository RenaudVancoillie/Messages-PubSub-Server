# Messages-PubSub-Server
The repository for the PubSub API with the messages data as a .NET 5.0 C# server.

## Run
Clone and `dotnet run` the application in development environment on a local IIS server. 
Get the frontend application from [this repository](https://github.com/RenaudVancoillie/Messages-PubSub-Client) to view the API in action!

## Database
By default the application makes use of a local Microsoft SQL Server database called "Messages". If this has been set up locally, running the `Update-Database` command in the NuGet Package Manager Console will build the database. 
