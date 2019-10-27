
# OnlineMarketPlace API ReadMe
This project is a simple CRUD API for an online market place running an ASP .NET Core application with SQL Server.

# Running the app
Prerequisites:
* Git
* MS SQL Server
* .NET Core 2.2 SDK
* Visual Studio
* Postman if you wish to run the API tests

To run the app create a folder, cd into it and clone this repository
```
git clone git@github.com:mikethorpe/OnlineMarketPlace.git
```

Open the solution in Visual Studio and from the Package Manager Console run the below to create and seed the database:
```
Update-Database
```
Run the solution in debug mode and the swagger documentation for the app can be accessed at http://localhost:5000/swagger/index.html

# Running the API tests

API tests can be imported into Postman from the path:
```
/OnlineMarketPlace/OnlineMarketPlace/Api.Tests/tests.postman
```

Note: prior to running the tests it is essential to configure the DB to its initial seeded state.

Run the below commands to drop the DB and then recreate it:
```
Drop-Database
Update-Database
```

The test folders should be run in the following order:
1. initial_state
2. product
3. products

# Limitations of the solution
* Due to the precision assigned to the price stored in the database the max price possible is 999.99 - values larger than this will throw an error. This can be altered and is essentially arbitrary.
