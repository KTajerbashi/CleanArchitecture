# Clean Architecture in .NET

![Clean Architecture Diagram](https://github.com/KTajerbashi/CleanArchitecture/assets/89404392/6872c1d8-b8c2-4d37-be79-2113f064056b)

## Introduction

Clean Architecture is a software design approach that promotes maintainability, testability, and flexibility by separating business logic from implementation details. In .NET applications, this architecture helps build robust, scalable systems that can evolve over time without major refactoring.

## Core Principles

![Clean Architecture Layers](https://github.com/KTajerbashi/CleanArchitecture/assets/89404392/bb8498a6-745f-442b-9692-4592d6a50ca2)

### Key Benefits:
- **Separation of Concerns**: Isolates business logic from infrastructure and UI
- **Testability**: Enables focused unit testing of core logic
- **Maintainability**: Reduces ripple effects from changes
- **Flexibility**: Allows swapping implementations without changing core logic

## Architecture Layers

![Layer Structure](https://github.com/KTajerbashi/CleanArchitecture/assets/89404392/e5396338-a2ac-4726-af1e-a4b0030d8b00)

### 1. Domain Layer
- Contains core business logic and entities
- Defines interfaces for external interactions
- Completely independent of other layers

### 2. Application Layer
- Implements use cases and application logic
- Coordinates data flow between layers
- Depends only on Domain layer

### 3. Infrastructure Layer
- Implements persistence, external services
- Provides concrete implementations of Domain interfaces
- Depends on Domain and Application layers

### 4. Presentation Layer (Web API)
- Handles HTTP requests/responses
- Contains controllers and DTOs
- Depends on Application layer

## Implemented Features

### Core Libraries:
- ✅ MediatR (CQRS pattern)
- ✅ Entity Framework Core
- ✅ Dapper (for optimized queries)
- ✅ AutoMapper (object mapping)
- ✅ FluentValidation
- ✅ Serilog (structured logging)

### Security:
- ✅ JWT Authentication
- ✅ .NET Identity
- ✅ BCrypt.NET (password hashing)

### API Features:
- ✅ Swagger/OpenAPI documentation
- ✅ Health Checks
- ✅ OpenTelemetry (distributed tracing)
- ✅ MiniProfiler (performance analysis)

### Additional Components:
- Caching (Cache Manager)
- Email (MailKit, FluentEmail)
- File Processing (EPPlus, CsvHelper)
- Testing (Moq, Bogus)
- Resilience (Polly)

## Implementation Details

### Core Libraries
| Library | Purpose | Layer | NuGet |
|---------|---------|-------|-------|
| MediatR | CQRS pattern | Application | [MediatR](https://www.nuget.org/packages/MediatR) |
| AutoMapper | Object mapping | Application | [AutoMapper](https://www.nuget.org/packages/AutoMapper) |
| FluentValidation | Validation logic | Domain | [FluentValidation](https://www.nuget.org/packages/FluentValidation) |

### Data Access
| Library | Purpose | Layer | NuGet |
|---------|---------|-------|-------|
| EntityFramework Core | ORM | Infrastructure | [EFCore](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore) |
| Dapper | High-performance queries | Infrastructure | [Dapper](https://www.nuget.org/packages/Dapper) |
| EFCore.SqlServer | SQL Server provider | Infrastructure | [EFCore.SqlServer](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.SqlServer) |

### API Features
| Library | Purpose | Layer | NuGet |
|---------|---------|-------|-------|
| Swagger | API documentation | WebApi | [Swashbuckle](https://www.nuget.org/packages/Swashbuckle.AspNetCore) |
| Serilog | Structured logging | Cross-layer | [Serilog](https://www.nuget.org/packages/Serilog) |
| HealthChecks | System monitoring | Infrastructure | [AspNetCore.HealthChecks](https://www.nuget.org/packages/AspNetCore.HealthChecks) |

### Security
| Library | Purpose | Layer | NuGet |
|---------|---------|-------|-------|
| JWT Bearer | Token authentication | WebApi | [JwtBearer](https://www.nuget.org/packages/Microsoft.AspNetCore.Authentication.JwtBearer) |
| ASP.NET Identity | User management | Infrastructure | [Identity](https://www.nuget.org/packages/Microsoft.AspNetCore.Identity.EntityFrameworkCore) |
| BCrypt.NET | Password hashing | Domain | [BCrypt](https://www.nuget.org/packages/BCrypt.Net-Next) |

## Best Practices

![C# Best Practices](https://github.com/KTajerbashi/CleanArchitecture/assets/89404392/0daad603-5979-4e09-9d84-5e51f62761b7)

1. **Keep Architecture Simple**
   - Avoid unnecessary complexity
   - Follow SOLID principles

2. **Layer Independence**
   - Strict dependency rules (inner layers don't know about outer ones)
   - Depend on abstractions, not concretions

3. **Clean Code**
   - Meaningful naming conventions
   - Small, focused classes/methods
   - Consistent coding style

4. **Continuous Refactoring**
   - Regular code quality reviews
   - Incremental improvements
   - Technical debt management

5. **Layer Isolation**
   - Inner layers never reference outer layers
   - Dependencies flow inward only
  
6. **Testability**
   - 90%+ unit test coverage for Domain/Application
   - Mock all external dependencies
  
7. **Performance**
   - Dapper for read-heavy operations
   - Caching with CacheManager
   - Query optimization with MiniProfiler


## Getting Started

1. Clone the repository
2. Configure connection strings in appsettings
3. Run database migrations
4. Start the WebApi project
