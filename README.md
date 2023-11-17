# StarTrek4Fun
An example of 3 web apis. front end calls two backend webapis, all REST compliant with examples of ClientSDK libraries for consuming APIs

# Project Notes:
- Client libraries include service extensions for easy registration in DI
- Client libraries are made to be referenced and provide everything needed to consume their respective APIs
- Backing DB is mocked out with simple collection with LINQ querying
- A decoupled repository pattern abstracts the database implementation from the repository consumers
- Note the decoupled nature of the different layers like Service, Client, Data.
- Dto are mapped to data to decouple the model dependencies
- Running it will display Swagger, have fun
