# .NET Application Foundation

> A reusable, production-oriented .NET application foundation built around Clean Architecture, CQRS, Domain-Driven Design principles, and modern enterprise engineering practices.

[![Build](https://github.com/KTajerbashi/CleanArchitecture/actions/workflows/dotnet.yml/badge.svg)](https://github.com/KTajerbashi/CleanArchitecture/actions/workflows/dotnet.yml)
[![.NET](https://img.shields.io/badge/.NET-10-512BD4)](https://dotnet.microsoft.com/)
[![Architecture](https://img.shields.io/badge/Architecture-Clean%20Architecture-blue)](#architecture)
[![License](https://img.shields.io/badge/License-MIT-green)](#license)

---

## Overview

**.NET Application Foundation** is a reusable software infrastructure template for building maintainable, testable, scalable, and production-oriented .NET applications.

The purpose of this repository is not to provide a sample business application.

Instead, it provides a **pre-built application foundation** that can be cloned or used as a starting point for new software projects.

The foundation provides the architectural boundaries, cross-cutting concerns, infrastructure integrations, development conventions, and engineering patterns required to bootstrap an enterprise-grade application without rebuilding the same technical foundation for every project.

### The goal

```text
New Project
    │
    ▼
Clone Foundation
    │
    ▼
Configure Environment
    │
    ▼
Add Business Domain
    │
    ▼
Build Application Features
    │
    ▼
Deploy
```

The business domain is intentionally kept separate from the technical foundation.

---

## Why This Repository Exists

Most enterprise applications repeatedly implement the same technical capabilities:

* Authentication and authorization
* Dependency injection
* Database access
* Repository abstractions
* Unit of Work
* CQRS
* Validation
* Logging
* Exception handling
* Health checks
* Observability
* Background processing
* Messaging
* Caching
* API documentation
* Configuration
* Security
* Testing infrastructure

Rebuilding these capabilities for every project increases development time and creates architectural inconsistency.

This repository provides a reusable foundation so that a new application can start with these capabilities already organized and integrated.

---

## What This Repository Is

This repository is a:

* Software architecture template
* .NET application foundation
* Enterprise application starter
* Clean Architecture reference implementation
* Reusable infrastructure baseline
* Cross-cutting concerns foundation
* Development standardization template

---

## What This Repository Is Not

This repository is **not**:

* A complete business application
* A CRM
* An ERP
* A CMS
* A tutorial-only project
* A microservices framework
* A replacement for domain-specific architecture decisions

The template provides technical foundations while leaving business requirements to the application built on top of it.

---

# Architecture

The solution follows Clean Architecture principles with dependencies flowing toward the application core.

```text
                         ┌──────────────────────┐
                         │       Web API        │
                         │     Presentation     │
                         └──────────┬───────────┘
                                    │
                                    ▼
                         ┌──────────────────────┐
                         │    Infrastructure    │
                         │                      │
                         │ EF Core              │
                         │ SQL Server            │
                         │ Identity              │
                         │ RabbitMQ              │
                         │ Hangfire              │
                         │ Dapper                │
                         └──────────┬───────────┘
                                    │
                                    ▼
                         ┌──────────────────────┐
                         │     Application      │
                         │                      │
                         │ CQRS                 │
                         │ MediatR              │
                         │ DTOs                 │
                         │ Validation            │
                         │ Interfaces            │
                         └──────────┬───────────┘
                                    │
                                    ▼
                         ┌──────────────────────┐
                         │        Domain        │
                         │                      │
                         │ Entities             │
                         │ Value Objects        │
                         │ Domain Events        │
                         │ Business Rules        │
                         └──────────────────────┘
```

## Dependency Rule

Dependencies should point inward.

```text
Presentation
     ↓
Infrastructure
     ↓
Application
     ↓
Domain
```

The Domain layer must remain independent from infrastructure and presentation concerns.

---

# Solution Structure

```text
CleanArchitecture/
│
├── .github/
│   └── workflows/
│       └── dotnet.yml
│
├── Docs/
│
├── Src/
│   │
│   ├── 1.Core/
│   │   │
│   │   ├── CleanArchitecture.Core.Domain/
│   │   │
│   │   └── CleanArchitecture.Core.Application/
│   │
│   ├── 2.Infrastructure/
│   │   │
│   │   └── CleanArchitecture.Infra.SqlServer/
│   │
│   └── 3.EndPoints/
│       │
│       └── CleanArchitecture.EndPoint.WebApi/
│
├── CleanArchitecture.sln
├── nuget.config
├── .gitignore
└── README.md
```

The current repository is organized into Core, Infrastructure, and EndPoints projects, providing clear architectural boundaries.

---

# Architectural Layers

## 1. Domain

The Domain layer contains the business model.

Responsibilities include:

* Entities
* Aggregates
* Value Objects
* Domain Events
* Business Rules
* Domain Exceptions
* Domain Services
* Specifications

The Domain should not depend on:

* SQL Server
* Entity Framework Core
* HTTP
* Controllers
* RabbitMQ
* Hangfire
* Logging providers
* UI concerns

---

# 2. Application

The Application layer contains application-specific business workflows and use cases.

Typical responsibilities include:

```text
Commands
Queries
Handlers
DTOs
Validators
Interfaces
Application Services
Behaviors
Mappings
```

The Application layer coordinates business operations without depending on concrete infrastructure implementations.

---

# 3. Infrastructure

Infrastructure contains technical implementations of application abstractions.

Current infrastructure integrations include:

* Entity Framework Core
* SQL Server
* Dapper
* ASP.NET Core Identity
* JWT infrastructure
* RabbitMQ
* Hangfire
* Dependency Injection registration
* Infrastructure services

The infrastructure layer implements interfaces defined by the inner layers.

---

# 4. Presentation

The Web API layer is responsible for exposing application capabilities through HTTP.

Typical responsibilities include:

* HTTP endpoints
* Authentication
* Authorization
* Middleware
* Exception handling
* Swagger/OpenAPI
* Health checks
* Logging configuration
* Observability
* API configuration

Business logic should not be implemented directly inside controllers.

---

# Core Engineering Principles

The template follows the following principles:

### SOLID

* Single Responsibility
* Open/Closed
* Liskov Substitution
* Interface Segregation
* Dependency Inversion

### Clean Architecture

Dependencies point toward the application core.

### Separation of Concerns

Each layer owns a clearly defined responsibility.

### Dependency Inversion

Business logic depends on abstractions rather than infrastructure implementations.

### Explicit Boundaries

Architectural boundaries should be enforced through project references and architecture tests.

### Testability

Business logic should be independently testable without requiring external infrastructure.

---

# Technology Stack

| Technology            | Purpose                       |
| --------------------- | ----------------------------- |
| .NET 10               | Application runtime           |
| ASP.NET Core          | Web API                       |
| C#                    | Primary language              |
| Entity Framework Core | ORM                           |
| SQL Server            | Relational database           |
| Dapper                | Micro-ORM / optimized queries |
| MediatR               | CQRS / request pipeline       |
| FluentValidation      | Request validation            |
| AutoMapper            | Object mapping                |
| ASP.NET Core Identity | Identity management           |
| JWT Bearer            | API authentication            |
| RabbitMQ              | Messaging                     |
| Hangfire              | Background jobs               |
| Scrutor               | Dependency registration       |
| Serilog               | Structured logging            |
| OpenTelemetry         | Observability                 |
| Prometheus            | Metrics                       |
| Swagger / OpenAPI     | API documentation             |
| Health Checks         | Service health monitoring     |
| MiniProfiler          | Performance profiling         |

---

# CQRS

The application layer supports a CQRS-oriented application model.

Typical structure:

```text
Application/
│
├── Features/
│   ├── Users/
│   │   ├── Commands/
│   │   ├── Queries/
│   │   ├── DTOs/
│   │   └── Validators/
│   │
│   └── Organizations/
│       ├── Commands/
│       ├── Queries/
│       ├── DTOs/
│       └── Validators/
```

The goal is to keep each use case focused and independently maintainable.

---

# Data Access

The foundation supports multiple data access strategies.

## Entity Framework Core

Use EF Core for:

* Transactional operations
* Aggregates
* Change tracking
* Migrations
* Standard CRUD operations

## Dapper

Use Dapper selectively for:

* Read-heavy operations
* Complex SQL queries
* Reporting
* Performance-sensitive queries

The template does not require every operation to use the same data access technology.

---

# Authentication and Authorization

The foundation supports:

```text
ASP.NET Core Identity
        │
        ▼
JWT Authentication
        │
        ▼
Authorization Policies
        │
        ▼
Protected API Resources
```

Application-specific authorization rules should be implemented using policies, roles, claims, and domain/application permissions as appropriate.

---

# Messaging

RabbitMQ is supported as the messaging infrastructure.

Typical use cases include:

* Integration events
* Asynchronous processing
* Inter-service communication
* Event-driven workflows

Messaging should remain behind abstractions so that the application is not tightly coupled to a specific broker.

---

# Background Processing

Hangfire provides infrastructure for background jobs.

Typical use cases:

* Scheduled jobs
* Recurring jobs
* Deferred processing
* Long-running background tasks
* Retryable operations

Business code should remain independent from Hangfire-specific APIs.

---

# Caching

Caching should be exposed through an application-level abstraction.

Example conceptual boundary:

```text
Application
    │
    ▼
ICacheService
    │
    ▼
Infrastructure
    │
    ├── In-Memory
    └── Distributed Cache
```

This allows the implementation to change without modifying application use cases.

---

# Observability

The foundation includes observability capabilities for production systems.

## Logging

Structured logging is implemented with Serilog.

Typical information includes:

* Request information
* Application information
* Exception information
* Correlation information
* Execution context

## Distributed Tracing

OpenTelemetry can be used for:

* HTTP tracing
* Dependency tracing
* Distributed systems
* Telemetry export

## Metrics

Prometheus-compatible metrics can be exposed for monitoring application health and performance.

---

# Health Checks

Health checks provide visibility into application dependencies.

Typical checks include:

```text
Application
    │
    ├── Database
    ├── External Services
    ├── Network Dependencies
    └── Messaging Infrastructure
```

This is particularly useful for containerized and orchestrated environments.

---

# API Documentation

The Web API exposes OpenAPI/Swagger documentation.

The documentation should be used to:

* Explore endpoints
* Test APIs
* Understand request/response models
* Document API contracts

---

# Error Handling

Application failures should be represented consistently.

The API should provide predictable responses for:

```text
Validation Errors
Authentication Errors
Authorization Errors
Not Found
Business Rule Violations
Infrastructure Failures
Unexpected Exceptions
```

A global exception-handling strategy should prevent infrastructure exceptions from leaking directly to API consumers.

---

# Configuration

Configuration should be environment-based.

Recommended configuration hierarchy:

```text
appsettings.json
        ↓
appsettings.{Environment}.json
        ↓
Environment Variables
        ↓
User Secrets / Secret Store
```

Sensitive information must never be committed to source control.

Examples:

* Database passwords
* JWT signing secrets
* RabbitMQ credentials
* Cloud credentials
* API keys
* Connection strings containing credentials

---

# Database

The default relational database integration is SQL Server.

Typical development workflow:

```bash
dotnet restore

dotnet build

dotnet ef migrations add InitialCreate

dotnet ef database update
```

Before running migrations, configure the appropriate connection string for the target environment.

---

# Getting Started

## Prerequisites

Install:

* .NET 10 SDK
* Git
* SQL Server or SQL Server container
* Optional: RabbitMQ
* Optional: Docker

Verify .NET:

```bash
dotnet --version
```

---

## Clone

```bash
git clone https://github.com/KTajerbashi/dotnet-application-foundation.git
cd dotnet-application-foundation
```

---

## Restore Dependencies

```bash
dotnet restore
```

---

## Build

```bash
dotnet build --configuration Release
```

---

## Configure Environment

Create the required configuration for:

```text
Database
JWT
Identity
RabbitMQ
Logging
Observability
```

Do not commit secrets.

---

## Apply Database Migrations

```bash
dotnet ef database update
```

---

## Run the API

```bash
dotnet run --project Src/3.EndPoints/CleanArchitecture.EndPoint.WebApi
```

---

# Development Workflow

A typical development workflow is:

```text
1. Define domain model
        ↓
2. Create application use case
        ↓
3. Add command/query
        ↓
4. Add validation
        ↓
5. Implement infrastructure abstraction
        ↓
6. Expose API endpoint
        ↓
7. Add tests
        ↓
8. Update documentation
```

---

# Recommended Feature Structure

For a real application built from this foundation, organize features vertically where appropriate.

Example:

```text
Application/
└── Features/
    └── Organizations/
        ├── Commands/
        │   ├── CreateOrganization/
        │   ├── UpdateOrganization/
        │   └── DeleteOrganization/
        │
        ├── Queries/
        │   ├── GetOrganization/
        │   └── GetOrganizations/
        │
        ├── DTOs/
        └── Validators/
```

This keeps related use-case code close together and makes large applications easier to navigate.

---

# Testing Strategy

A production application created from this foundation should contain multiple testing levels.

```text
tests/
│
├── UnitTests/
│
├── IntegrationTests/
│
└── ArchitectureTests/
```

## Unit Tests

Test:

* Domain rules
* Value objects
* Application handlers
* Validators
* Services

## Integration Tests

Test:

* Database integration
* API endpoints
* Authentication
* Infrastructure integrations
* Messaging

## Architecture Tests

Verify:

* Domain does not depend on Infrastructure
* Domain does not depend on Presentation
* Application does not depend on Presentation
* Infrastructure does not violate dependency rules

---

# CI/CD

GitHub Actions is used to automate validation.

The CI pipeline should verify at minimum:

```text
Checkout
   ↓
Setup .NET
   ↓
Restore
   ↓
Build
   ↓
Unit Tests
   ↓
Integration Tests
   ↓
Architecture Tests
   ↓
Publish / Package
```

The CI environment must use the same major .NET SDK version as the application.

---

# Docker

The foundation is intended to support containerized deployments.

Recommended container architecture:

```text
                 ┌───────────────┐
                 │     Web API   │
                 └───────┬───────┘
                         │
          ┌──────────────┼──────────────┐
          ▼              ▼              ▼
      SQL Server       RabbitMQ       External
                                      Services
```

Recommended files:

```text
Dockerfile
.dockerignore
docker-compose.yml
```

Docker should be treated as an optional deployment/development mechanism rather than a mandatory architectural dependency.

---

# Production Readiness Checklist

Before using the foundation for production, verify:

* [ ] Environment-specific configuration exists
* [ ] Secrets are externalized
* [ ] Database migrations are managed
* [ ] Authentication is configured
* [ ] Authorization policies are defined
* [ ] Structured logging is enabled
* [ ] Health checks are configured
* [ ] Metrics are configured
* [ ] Distributed tracing is configured
* [ ] Database indexes are reviewed
* [ ] API error handling is standardized
* [ ] Rate limiting is configured where required
* [ ] CORS is configured correctly
* [ ] HTTPS is enforced
* [ ] Security headers are configured
* [ ] Dependency vulnerabilities are reviewed
* [ ] Unit tests exist
* [ ] Integration tests exist
* [ ] Architecture tests exist
* [ ] CI pipeline passes
* [ ] Container image is scanned
* [ ] Production configuration is validated

---

# Using This as a Project Template

The intended workflow is:

```text
.NET Application Foundation
            │
            ▼
       Clone / Fork
            │
            ▼
   Rename Solution / Projects
            │
            ▼
    Configure Environment
            │
            ▼
      Define Domain
            │
            ▼
    Implement Use Cases
            │
            ▼
      Add API Features
            │
            ▼
       Add Tests
            │
            ▼
         Deploy
```

The foundation should provide the technical starting point while the consuming application provides the business domain.

---

# Design Philosophy

This project follows several principles.

## 1. Business First

Infrastructure should support the business domain rather than control it.

## 2. Replaceable Infrastructure

External technologies should remain replaceable whenever practical.

```text
Application
     │
     ▼
Abstraction
     │
     ▼
Implementation
```

## 3. Explicit Complexity

Complexity should be introduced because the application requires it, not because a framework provides it.

## 4. Production-Oriented Defaults

The foundation should provide sensible defaults for:

* Security
* Logging
* Observability
* Validation
* Error handling
* Testing
* Configuration

## 5. Incremental Adoption

Optional capabilities such as messaging, caching, background processing, and advanced observability should be adoptable without changing the core architecture.

---

# Repository Roadmap

## Foundation

* [x] Clean Architecture
* [x] Domain layer
* [x] Application layer
* [x] Infrastructure layer
* [x] Web API
* [x] EF Core
* [x] SQL Server
* [x] CQRS
* [x] Validation
* [x] Logging
* [x] Health Checks
* [x] OpenAPI / Swagger

## Enterprise Capabilities

* [x] Identity
* [x] JWT Authentication
* [x] Dapper
* [x] RabbitMQ
* [x] Hangfire
* [x] OpenTelemetry
* [x] Prometheus
* [x] Performance Profiling

## Engineering Improvements

* [ ] Dedicated Unit Test project
* [ ] Dedicated Integration Test project
* [ ] Architecture Tests
* [ ] Docker development environment
* [ ] Production Dockerfile
* [ ] Environment configuration examples
* [ ] Global SDK version via `global.json`
* [ ] Automated dependency updates
* [ ] Security scanning
* [ ] Code coverage reporting
* [ ] Release/versioning strategy
* [ ] CHANGELOG
* [ ] Template initialization scripts

---

# Recommended Future Structure

The long-term target structure is:

```text
.
├── .github/
│   └── workflows/
│
├── docs/
│
├── src/
│   ├── Domain/
│   ├── Application/
│   ├── Infrastructure/
│   └── WebApi/
│
├── tests/
│   ├── UnitTests/
│   ├── IntegrationTests/
│   └── ArchitectureTests/
│
├── scripts/
│   ├── setup.ps1
│   └── setup.sh
│
├── docker/
│
├── .editorconfig
├── .gitignore
├── Directory.Build.props
├── Directory.Packages.props
├── global.json
├── docker-compose.yml
├── CHANGELOG.md
├── LICENSE
├── README.md
└── *.sln
```

---

# Engineering Standards

Projects built from this foundation should follow:

* Clean Code
* SOLID
* DRY
* KISS
* YAGNI
* Dependency Inversion
* Explicit boundaries
* Automated testing
* Automated CI validation
* Secure configuration management
* Structured logging
* Observable production services

---

# Security

Security is considered a first-class engineering concern.

Applications using this foundation should follow:

* Least privilege
* Secure secret management
* Strong authentication
* Policy-based authorization
* Input validation
* Secure headers
* HTTPS
* Dependency vulnerability scanning
* Secure database access
* Audit logging where required

Never commit credentials or production secrets to the repository.

---

# Performance

Performance optimization should be evidence-driven.

The foundation supports tools that can help diagnose performance issues:

* Dapper
* MiniProfiler
* OpenTelemetry
* Prometheus
* EF Core query analysis

The preferred approach is:

```text
Measure
   ↓
Identify bottleneck
   ↓
Optimize
   ↓
Measure again
```

Infrastructure should not introduce unnecessary complexity without a measurable requirement.

---

# Maintainability

The primary goal of this foundation is long-term maintainability.

A project created from this template should allow developers to:

* Understand the architecture quickly
* Locate features predictably
* Replace infrastructure implementations
* Test business logic independently
* Add new features without modifying unrelated components
* Upgrade infrastructure independently
* Scale the application as requirements grow

---

# When to Use This Template

This foundation is suitable for:

* Enterprise APIs
* Business applications
* Internal platforms
* SaaS backends
* Management systems
* Administrative systems
* Financial applications
* Workflow systems
* Multi-module applications
* Long-lived .NET systems

It is especially useful when the application is expected to evolve over multiple years.

---

# When Not to Use This Template

A full enterprise foundation may be unnecessary for:

* Small prototypes
* One-off scripts
* Simple CRUD applications
* Short-lived proof-of-concepts
* Tiny internal utilities

Architecture should match the complexity and lifetime of the system.

---

# Contribution

Contributions should preserve the architectural principles of the repository.

Before introducing a new dependency, consider:

1. Is it required by the business?
2. Can the feature be implemented without it?
3. Which architectural layer owns it?
4. Does it introduce an unwanted dependency?
5. Can it be replaced later?
6. Can the behavior be tested?
7. Does it increase operational complexity?

---

# License

This project is intended to be used as a reusable software foundation.

See the `LICENSE` file for licensing terms.

---

# Author

**Kamran Tajerbashi**

Software Engineer focused on:

* .NET
* C#
* ASP.NET Core
* Angular
* Software Architecture
* Enterprise Application Development
* Distributed Systems
* Cloud-Native Development

---

# Final Statement

This repository is designed around a simple idea:

> **Do not rebuild the technical foundation every time you start a new application.**

Start with a proven architectural baseline.

Keep the business domain independent.

Add only the infrastructure the application actually needs.

Test the architecture.

Automate the build.

Observe the system.

And let the application focus on solving business problems.

---

**Project:** .NET Application Foundation
**Architecture:** Clean Architecture
**Runtime:** .NET 10
**Primary Language:** C#
**Repository:** `KTajerbashi/CleanArchitecture`
