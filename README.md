## Welcome to My Car Rental Project

### The project was developed in accordance with SOLID principles, corporate software architecture, AOP, and software development principles.
 
* Developed on the .Net Core 3.1 platform.
* Cross Cutting Concerns were developed using the Autofac library with interceptors.
  * Performance   
  * Transaction
  * Validation
  * Caching

* Developed using Entity Framework ORM.
* AOP (Aspect-Oriented Programming) was used to handle Cross Cutting Concerns in a modular way.
* Exception Middleware was developed for centralized error handling.
* Claim mechanism was used to provide more flexible role-based authorization.
* JWT (JSON Web Token) authentication was integrated.
* Fluent Validation was used to implement validation processes.
* IoC (Inversion Of Control) was applied to create loosely coupled objects.
* REST and RESTful Web Services were used for server-client communication.

### C# Backend Layers

* Core: A general layer designed to make tools reusable across other projects.
* Entities: The layer where database tables are mapped to objects.
* DataAccess: The layer responsible for database operations.
* Business: The layer where business logic is implemented
* WebAPI: The layer that facilitates server-client communication via the RESTful (Representational State Transfer) HTTP protocol. 


