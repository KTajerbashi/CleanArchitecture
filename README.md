# Library-Clean-Architecture
## Library Project is Started on .Net 7 in Clean Architecture with CQRS Pattern

<h6>Main Layer</h6>

![Diagram-Clean-Architecture](https://github.com/KTajerbashi/CleanArchitectureLibrary/assets/89404392/39ce33b8-7f72-4209-aabe-730e64b4ff49)


<hr/>

### This is a 5-layer model that fully covers all dimensions of clean architecture, and it should be noted that you can not use the <b>Persistance</b> layer and develop your project with only 4 other layers.

<h6>Special Cases Layer</h6>

![Clean-Architecture-1](https://github.com/KTajerbashi/CleanArchitectureLibrary/assets/89404392/9ab25657-b91f-4a80-96aa-d32fa018372d)

<h1>Why do we need to architect?</h1>
<p>
  Software architecture is the foundation of a software system. Like any other engineering field, if the foundation is not solid, you can’t guarantee the quality of what is built on top of it. When this foundation is built, an architect needs to take several important decisions for software quality, maintenance, and successful delivery in the future. The greater the size and complexity of a software system, the more you will need a well-thought-out architecture to succeed. A good software architecture provides several benefits such as:
</p>
<ul>
  <li>
    <h6>Testable</h6>
    A good software architecture enables fast and reliable tests that are easy to write, execute and maintain.   </li>
  <li>
    <h6>Maintainable</h6>
    A good software architecture makes it easier to maintain existing software as the structure of the code is visible and well-kn
  </li>
  <li>
    <h6>Changeable</h6>
    A good software architecture allows us to accommodate changes and upgrades with minimum effort and impact.   </li>
  <li>
    <h6>Easy to Develop</h6>
    A good software architecture not only reduces the complexity of the system but also reduces code duplicity.  
  </li>
  <li>
    <h6>Easy to Deploy</h6>
    A good software architecture encourages loosely coupled services and components which makes deployment easy.
  </li>
</ul>

  <hr />
<h1>What is Clean Architecture?</h1>
<p>
  Clean Architecture is introduced by Robert C. Martin (also known as Uncle Bob) in 2012 and has gained popularity in recent years. It is derived from many architectural guidelines like Hexagonal Architecture, Onion Architecture, etc. and it emphasizes the separation of concerns and maintainability of code. In this architecture, the business logic is kept separate from the infrastructure and presentation layers, which allows developers to build scalable, testable, and maintainable software.
</p>

![1](https://github.com/KTajerbashi/CleanArchitectureLibrary/assets/89404392/8812ba51-e190-4153-b896-4464da5699ea)

<p>
  The Domain and Application layers are the center stage of the Clean Architecture and are often known as the Core of the System. The Domain layer contains enterprise logic and types and the Application layer contains business logic and types. The difference is that enterprise logic could be shared across many systems, whereas business logic will typically only be used within a system. The Infrastructure layer contains data access or other infrastructure concerns and dependencies flow inwards. The Core should not be dependent on the Infrastructure layer rather Infrastructure layer depends on the Core. This functionality is achieved by defining abstractions, or interfaces within Core, which are then implemented by types defined in the Infrastructure layer.
</p>
<hr />
<h1>Key Principles of Clean Architecture</h1>
<p>
  The clean architecture combines many software design principles and practices in a single architecture. Some of the key principles of clean architecture are as follows:
</p>
<ul>
  <li>
    <h5>Separation of Concerns</h5>
    <p>
      Clean architecture organized the code into layers in such a way that each layer is responsible for a specific part of the application. All layers of the system are independent or decoupled, allowing us to introduce a change and test business logic or user interfaces without impacting other layers or areas of the application.
    </p>
  </li>
  <li>
    <h5>Dependency Inversion Principle (DIP)</h5>
    <p>
      In clean architecture, the high-level modules are defined close to the domain or business logic, and low-level modules are defined close to the input and output of the program. The dependency inversion principle states that high-level modules should not depend on low-level modules. The dependencies should be inverted towards the inner layers. In other words, the abstractions should not depend upon details, the details should depend upon abstractions.
    </p>
  </li>
  <li>
    <h5>Single Responsibility Principle (SRP)</h5>
    <p>
      The single responsibility principle states that every module, class, or function in the code should have only one responsibility and only one reason to change. It makes your software easier to implement and prevents unexpected side effects of future changes.
    </p>
  </li>
  <li>
    <h5>Open/Closed Principle</h5>
    <p>
      The code should be open for extension but closed for modification. This means that if your business requirements change, your existing code should not be changed (closed for modifications). Instead, you should add a new code by extending the old code (open for extension). This principle makes your code more stable because you can add new features without affecting the existing code.
    </p>
  </li>
</ul>

<hr />

  
<h1>Advantages of Clean architecture</h1>
Clean Architecture offers a number of benefits for software development, including:
 <dl>
     <dt>1. Makes code easier to maintain</dt>
         <dd>
            Separating the different layers of the architecture makes code easier to maintain in the long                   term since changes in one layer do not affect the other layers.
         </dd>
   <dt>2. Improves the scalability of the system</dt>
         <dd>
           allows adding new functionalities to the system in a modular way, without affecting other parts of the code. Also, by separating the layers of the system, they can be independently optimized and scaled, making it easy to adapt the system to different situations and needs.
         </dd>
   <dt>3. Increases software quality</dt>
         <dd>
           encourages the use of design patterns and good programming practices, resulting in cleaner, more readable, and maintainable code.
         </dd>
   <dt>4. Automated testing is much easier</dt>
         <dd>
            By separating the layers of the system, testing can be done in isolation from the infrastructure, making it easier to develop unit and integration tests. Also, business rules can be tested without the user interface, database, web server, or any other external elements.
         </dd>
   <dt>5. It facilitates the evolution of the system</dt>
         <dd>
            it facilitates the evolution of the system in the long term, since it allows it to adapt to changes in technologies, business requirements, etc. In addition, the separation of the system layers allows reuse of components and functionality in different parts of the system, which facilitates development and reduces maintenance costs.
         </dd>
   <dt>5. Independent of the database  and anything external</dt>
         <dd>
            you can swap Oracle or SQL Server for Mongo or anything else. Your trading rules are not tied to the database, they just don’t know anything about the outside world.
Clean Architecture is a methodology that helps develop scalable, maintainable and flexible software systems, by separating responsibilities into different layers and using design patterns and good programming practices. This translates into a cleaner, more readable and maintainable code, which facilitates the evolution of the system and increases the quality of the software.
         </dd>
 </dl>
<hr />
<h1>Layers of Clean Architecture</h1>
  
<h2>Implementing Clean Architecture in ASP .NET Core</h2>
To apply Clean Architecture, we can divide the application into four primary layers

<h4>Domain Layer → </h4> 
The Domain layer is the core of the application. It contains the business logic and rules that define the behavior of the system. This layer should be independent of any external dependencies and frameworks. It should only contain pure business logic and data structures.

The Domain layer should define the entities, value objects, and domain services that represent the core concepts of the application. It should also define the interfaces for any external dependencies that the application needs to interact with, such as databases or external APIs.

The domain layer encapsulates business rules (Enterprise business rules). The domain is not affected by external changes, as it does not have references to other layers.

Unit tests are performed here.

The project contains the domain layer, including the entities, value objects, and domain services

<h4>Domain layer contains</h4>
<ul>
  <li>Entities</li>
  <li>Aggregates</li>
  <li>Value Objects</li>
  <li>Domain Events</li>
  <li>Enums</li>
  <li>Constants</li>
</ul>

<h4>Domain layer packages</h4>
<ul>
  <li>MediatR</li>
</ul>






<hr />
<h4>Application Layer → </h4> 
The Application layer is responsible for coordinating the interactions between the Domain layer and the Infrastructure layer. It contains the use cases and application services that define the high-level behavior of the system.

The Application layer should not contain any business logic. Instead, it should delegate to the Domain layer to perform the necessary operations. The Application layer should also define the interfaces for any external dependencies that the system needs to interact with.

The project contains the application layer and implements the application services, DTOs (data transfer objects), and mappers. It should reference the Domain project.

The application layer contains application business rules.

This layer defines interfaces that are implemented by external layers. For example, if the app needs to access a notification service, a new interface would be added to the app and an implementation would be created within the framework.

This layer implements CQRS and Command Query Responsibility Segregation (mediator) pattern, with each business use case represented by a single command or query.

Integration tests are performed here.

<h4>Application layer contains</h4>
<ul>
  <li>Abstractions/Contracts/Interfaces</li>
  <li>Application Services/Handlers</li>
  <li>Ports</li>
  <li>
    <dl>
      <dt>Interfaces</dt>
        <dd>IDataBaseContext</dd>
    </dl>
  </li>
  <li>Commands and Queries</li>
  <li>Exceptions</li>
  <li>Models (DTOs)</li>
  <li>Mappers</li>
  <li>Validators</li>
  <li>Behaviors</li>
  <li>Specifications</li>
</ul>

<h4>Application layer refernce</h4>
<ul>
  <li>Domain Layer</li>
</ul>

<h4>Application layer packages</h4>
<ul>
  <li>MediatR</li>
  <li>Microsoft.EntityFrameworkCore</li>
  <li>AutoMapper</li>
  <li>AutoMapper.Extensions.Microsoft.DependencyInjection</li>
  <li>FluentValidation</li>
  <li>FluentValidation.AspNetCore</li>
</ul>





<hr />
<h4>Infrastructure Layer → </h4> 
The Infrastructure layer is responsible for providing the implementation details for the interfaces defined in the Domain and Application layers. It contains the code that interacts with external dependencies such as databases, file systems, and external APIs.

The Infrastructure layer should be designed to be easily replaceable. This means that the code should be decoupled from any specific implementation details, such as the choice of database or web framework.

The project contains the infrastructure layer, including the implementation of data access, logging, email, and other communication mechanisms. It should reference the Application project.

The Infrastructure layer contains classes for accessing external resources. These classes must be based on interfaces defined within the application layer.

<h4>Infrastructure layer contains</h4>
<ul>
  <li>Authentication and Identity Services</li>
  <li>File/Object Storage</li>
  <li>Message Queue Storage</li>
  <li>Third-Party Services</li>
  <li>Email and Notification Services</li>
  <li>Logging Services</li>
  <li>Payment Services</li>
  <li>Social Logins</li>
</ul>

<h4>Infrastructure layer refernce</h4>
<ul>
  <li>null</li>
</ul>

<h4>Infrastructure layer packages</h4>
<ul>
  <li>null</li>
</ul>

<hr />

<h4>Persistance Layer → </h4> 

Persistence Layer
This layer handles database and caching-related operations. This layer implements the interfaces and repositories defined in the Application layer using specific frameworks or libraries e.g. Entity Framework, Dapper, etc. This layer also contains dependencies related to specific databases e.g. SQL Server, Oracle, etc.

<ul>
  <li>Data Context</li>
  <li>Repositories</li>
  <li>Data Migrations</li>
  <li>Data Seeding</li>
  <li>In Memory Caching</li>
  <li>Distributed Caching e.g. Redis, Memcached, etc.</li>
</ul>

<h4>Persistence layer reference</h4>
<ul>
  <li>Domain Layer</li>
  <li>Application Layer</li>
</ul>

<h4>Persistence layer packages</h4>
<ul>
  <li>Microsoft.EntityFrameworkCore</li>
  <li>Microsoft.EntityFrameworkCore.Tools</li>
  <li>Microsoft.EntityFrameworkCore.Relational</li>
  <li>Microsoft.EntityFrameworkCore.SqlServer</li>
</ul>

<hr />
<h4>Presentation Layer → </h4> 
The Presentation layer is responsible for handling the user interface and user input. It contains the code that handles HTTP requests, renders HTML templates, and interacts with JavaScript on the client side.

The Presentation layer should be designed to be easily replaceable. This means that the code should be decoupled from any specific web framework or front-end library.

By organizing the codebase into these four layers, we can achieve a high degree of modularity and maintainability. Each layer has a specific purpose and responsibility, and changes in one layer should not affect the others.
The main project contains the presentation layer and implements the ASP.NET Core web API. It should reference the Application and Infrastructure projects.

<h4>Presentation layer contains</h4>
<ul>
  <li>Web Pages</li>
  <li>Web Components</li>
  <li>Web APIs</li>
  <li>Controller</li>
  <li>Views</li>
  <li>Middleware</li>
  <li>Filters</li>
  <li>Attributes</li>
  <li>Logger</li>
  <li>Configuration</li>
  <li>View Models</li>
  <li>Style Sheets</li>
  <li>Java Script Files</li>
  <li>Security using ASP.NET Core Identity + IdentityServer</li>
</ul>

<h4>Presentation layer reference</h4>
<ul>
  <li>Application Layer</li>
  <li>Persistance Layer</li>
</ul>

<h4>Presentation layer packages</h4>
<ul>
  <li>Microsoft.EntityFrameworkCore</li>
  <li>Microsoft.EntityFrameworkCore.Design</li>
  <li>Microsoft.EntityFrameworkCore.SqlServer</li>
</ul>

<hr />
<h1>Technologies</h1>
<ul>
  <li>Web API using ASP.NET Core 7</li>
  <li>Open API with Swashbuckle</li>
  <li>Data access with Entity Framework Core 6</li>
  <li>CQRS with MediatR</li>
  <li>Object-Object Mapping with AutoMapper</li>
  <li>Validation with FluentValidation</li>
  <li>Automated testing with xUnit, FluentAssertions, Moq & Respawn</li>
  <li>Containerized with Docker</li>
  <li>Security using ASP.NET Core Identity + IdentityServer</li>
</ul>

<hr />
<h1>Design Patterns</h1>
<ul>
  <li>Unit Of Work and Facad Pattern for Service Repositories</li>
  <li>CQRS Pattern for Read&Write on Application Layer</li>
</ul>
