# What is going on in here?

This is my `test/` directory, that I use to house the tests for my project.

I currently am creating a test project for each of the `src/` projects, and 
attempting to create a `[Src_File]Test.cs` file for each `[Src_File].cs` file.

I really want to try to test as much as possible, early and often. I want to see 
how far I can get with this and how beneficial it will be in the short and long term. 

I created a shared class library called `FoodPantry.Tests.Shared` that includes some 
infrastructure type code that I figure will be shared between the test projects.

## Testing against the database

Within the `FoodPantry.Tests.Shared` project is a `DatabaseFixture.cs` file that is used
as an xUnit fixture to create a database using Docker containers, which leverages the
`Testcontainers.PostgreSql` NuGet package to make it very easy to spin up a Postgres database
in a Docker container for testing purposes. This fixture also creates a `FoodPantryDbContext`
instance and calls the `EnsureCreated()` method to ensure that the database is created and ready to go.
This `DatabaseFixture.cs` is designed to be shared between the different test projects to abstract 
the complexities of creating that database container and the `FoodPantryDbContext` instance.
Within a test project, the test classes can implement the `IClassFixture<DatabaseFixture>` interface,
which will inject the `DatabaseFixture` instance into the test class.
I think that this will allow a separate database for each test class, which will allow some
degree of test isolation.

The `FoodPantry.Data.Tests` project tests the `FoodPantry.Data` project. 
Given that the `FoodPantry.Data` project is responsible for the data access layer, 
most of the tests in this project are integration tests. 

I don't quite know yet how this will work with the more rapid-response TDD practices that 
I am used to with unit testing. I am hoping that I can still use TDD with integration tests,
but time will tell.

