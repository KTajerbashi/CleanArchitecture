# Library-Clean-Architecture
##  Library Project is Started on .Net 7 in Clean Architecture with CQRS Pattern
![CleanArchitecture](https://github.com/KTajerbashi/Library-Clean-Architecture/assets/89404392/1a4967ec-8901-4999-a395-06c82e29168e)

<h1>Features and Packages</h1>
<ul>
  <li>Serilog.AspNetCore Or NLog.AspNetCore</li>
  <li>Microsoft.AspNetCore.Authentication.JwtBearer</li>
  <li>Microsoft.AspNetCore.Authentication - gRPC</li>
  <li>Newtonsoft Json.NET</li>
  <li>RestFul API</li>
  <li>CacheManager</li>
  <li>Swashbuckle.AspNetCore.Swagger</li>
  <li>Microsoft.EntityFrameworkCore</li>
  <li>FluentValidation.AspNetCore</li>
  <li>Mapster</li>
  <li>Microsoft.AspNetCore.MVC.Versioning</li>
  <li>Refit</li>
  <li>StackExchange.Redis</li>
  <li>MediatR</li>
  <li>xUnit.net</li>
  <li>Moq</li>
</ul>
<h1>Advantages of Clean architecture</h1>

Clean Architecture offers a number of benefits for software development, including:

1. Makes code easier to maintain – Separating the different layers of the architecture makes code easier to maintain in the long term, since changes in one layer do not affect the other layers.
2. Improves the scalability of the system: allows adding new functionalities to the system in a modular way, without affecting other parts of the code. Also, by separating the layers of the system, they can be independently optimized and scaled, making it easy to adapt the system to different situations and needs.
3. Increases software quality – encourages the use of design patterns and good programming practices, resulting in cleaner, more readable, and maintainable code.
4. Automated testing is much easier: By separating the layers of the system, testing can be done in isolation from the infrastructure, making it easier to develop unit and integration tests. Also, business rules can be tested without the user interface, database, web server, or any other external elements.
5. It facilitates the evolution of the system: it facilitates the evolution of the system in the long term, since it allows it to adapt to changes in technologies, business requirements, etc. In addition, the separation of the system layers allows reuse of components and functionality in different parts of the system, which facilitates development and reduces maintenance costs.
6. Independent of the database  and anything external, you can swap Oracle or SQL Server for Mongo or anything else. Your trading rules are not tied to the database, they just don’t know anything about the outside world.
Clean Architecture is a methodology that helps develop scalable, maintainable and flexible software systems, by separating responsibilities into different layers and using design patterns and good programming practices. This translates into a cleaner, more readable and maintainable code, which facilitates the evolution of the system and increases the quality of the software.
