# What am I trying to do here?

I'd like to do a "Test-Driven Development" style workflow with my data access layer.  
I'd like to be able to write tests that use a real database, but these databases should 
be able to spin up and tear down quickly. 

I'd also like to be able to run these tests in a CI/CD pipeline. 

I'm currently using a package called `Testcontainers`, which makes
it easy to spin up and tear down containers.  I'm using the Postgres
container, and this package provides a `Testcontainers.PostgreSql` 
package to make it easier easier to work with PostgreSql packages 
specifically. 

I currently have a `DatabaseFixture` class that spins up a PostgreSql 
container, and then creates a `DbContext` that uses the connection string
from the container, and then creates the database.  

This `DatabaseFixture` can be used as a `ClassFixture` or a `CollectionFixture`
in my test classes. 

## What do I really need to test here?
This is a good question.. I don't need to test EfCore, I am banking on Microsoft to test 
that for me. 

I do need to test that my `FoodPantryDbContext` is configured correctly, and that my `DbSet` 
properties are configured correctly. This, I think, will allow me to do a TDD approach 
as I add more functionality to the data access layer, which is mostly in the form of adding new 
`DbSet` properties to the `FoodPantryDbContext` class.



