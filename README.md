This is an API for interacting with the equipment state history but it also includes a few orders endpoints.

It is split into 2 controllers:
  1. State history controller with the following endpoints:
     1. GetCurrentState/{equipmentId} GET endpoint that returns the current state (last entry in history) for the equipment 
     2. GetEquipmentHistory/{equipmentId} GET endpoint returns all the states that we have in history for the equipment
     3. AddStateToHistory POST endpoint that adds a new state to the database
    
  2. Orders controller with the following endpoints:
     1. GetCurrentOrder/{equipmentId}  GET endpoint that returns the order that is currently executed by the equipment
     2. GetScheduledOrders/{equipmentId} GET endpoint that returns the list of orders that ar queued for the equipment

I have decided to use a local Sqlite database that contains only 2 tables for this exercise. 
  1. EquipmentState :
        "Id"	INTEGER NOT NULL UNIQUE,
        "EquipmentId"	INTEGER NOT NULL,
        "State"	INTEGER NOT NULL,
        "DateModified"	TEXT,
  2. Orders :
      	"Id"	INTEGER NOT NULL UNIQUE,
      	"EquipmentId"	INTEGER,
      	"OrderState"	INTEGER,
      	"DateAdded"	TEXT,

The solution contains implementations for the endpoints mentioned above and it can be tested using swagger ui with the
EquipmentId 123, or you can create your own data for testing.

I have added some unit tests, given the time restrictions of course it's not a lot of coverage but I think what I've added 
is enough to have a discussion on. 
I did not attempt to add any integration testing given the time restrictions. 
