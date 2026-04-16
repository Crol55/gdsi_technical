# gdsi_technical

## How to run from a fresh start (git clone)
To run the application and its migration execute the following cmd commands:
1) **dotnet restore**
2) **dotnet ef migrations add InitialDb** (__!IMPORTANT ⚠️! execute this command only if the Migrations folder is missing__)

Before running the App, update **appsettings.json** file with a correct __user__ and __password__.

3) **dotnet run**

## About the app:
This app uses appsettings.json to prevent having the connection string hardcoded.
The app was tested using a connection string for SQL Server and the blueprint can be found inside the **appsettings.json** file.

I tried to rely as much as I could on the DI container for the creation of instances. 

The version used to build this solutions:
* .NET Core 8.*
* C# 12
* EF Core 8.*
