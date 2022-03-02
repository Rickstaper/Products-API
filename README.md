# Products Web API project
### PostmanCollection 
    - folder contains a set of http requests to Web API server
### Products.API 
    - main folder for work with Web API server. This folder contains differences folders for work with server. For example:
#### Controllers 
        - folers of controllers
#### Extension 
        - folder contains two extension classes(ServiceExtensions(extensions of IServiceCollection) and ExceptionMiddlewareException(extension of IApplicationBuilder))
#### Mappings 
        - contains MappingProfile
#### ModelBinder 
        - need to send request with 'ids' collection
### Products.Contracts 
    - contains interfaces
### Products.Data 
    - contains models and configurations for EF Core
### Products.Repository
    - folder for work with repository of controllers
### StoredProcedure
    - a sql code for create a stored procedure 'FindFridgeProductsWithZeroQuantity'