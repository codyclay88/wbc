# `FoodPantry.Core`

## Domain Objects

The following items represent the core domain objects for the food pantry application. The Domain Objects 
are the objects that are persisted to the database, and are the foundation for implementing the business logic. 
Because they are persisted to the database, each domain object has an implicit `Id` field that is strictly used by 
`EF Core` for maintaining database integrity and establishing relationships to other objects. 

Each Domain Object should be simple and focused on a single responsibility. I am going to attempt to keep business logic 
out of the Domain Objects and instead implement business logic through "pure functions" that operate on the Domain Objects.
For displaying data to the user, "Computed Values" (discussed in the next section) are derived from the Domain Objects. 


### `Product`
Each product represents an item that our food pantry offers. Each product has the following properties:
- `Name`: The name of the product
- `Category`: Used to group similar products together
- `UnitSize`: The size of the product (e.g. 1 lb, 1 gallon, 15 oz can). This is represented as text because it can be anything.


### `Pantry Event`
A pantry event represents a single event where we distribute food to our customers. 
Each pantry event has the following properties:
- `StartsAt`: The date/time that the event will start
- `EndsAt`: The date/time that the event will end

Each `PantryEvent` is also loosely coupled to a collection of `EventInventoryRequirement` items. 
These requirements are used to determine what products we need to have on hand for the event.

### `EventInventoryRequirement`
For each `PantryEvent`, we need to manage a list of products that we will be offering, along with a minimum quantity of each product that we need to have on hand.
Each `EventInventoryRequirement` has the following properties:
- `ProductId`: References the `Product` that we will be offering.
- `PantryEventId`: References the `PantryEvent` that this requirement is for.
- `MinimumQuantity`: The minimum quantity of the `Product` that we need to have on hand for the event.

### `InventoryPledge`
Church members should be able to view the inventory needs for future `PantryEvent`s and pledge to donate a certain quantity of a product, 
this is represented by the `InventoryPledge` object. Each `InventoryPledge` has the following properties:
- `ProductId`: References the `Product` that the pledge is for.
- `MemberId`: References the `Member` that is making the pledge.
- `Quantity`: the quantity of the `Product` that the member is pledging to donate.
- `PledgedOn`: The date/time that the pledge was made.
- `FulfilledOn`: The date/time that the pledge was fulfilled.

`InventoryPledge` instances should not be linked directly to a `PantryEvent` or even an `EventInventoryRequirement`.

### `InventoryDonation`
When a member fulfills an `InventoryPledge`, a `InventoryDonation` is created. Each `InventoryDonation` has the following properties:
- `ProductId`: References the `Product` that was donated.
- `MemberId`: References the `Member` that made the donation.
- `Quantity`: The quantity of the `Product` that was donated.
- `DonatedOn`: The date/time that the donation was made.


## Computed Values

The following items represent computed values that are derived from the core domain objects. Computed values 
should not be saved directly to the database, but rather should be computed on the fly as needed. 

### `InventoryStatusOnDate`

