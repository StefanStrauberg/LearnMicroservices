# LearnMicroservices
Main goal of this repo is the view about what is the microservices architecture and how it implements on a backend

This repository made by the course [Microservices Architecture and Implementation on .NET 5](https://www.udemy.com/course/microservices-architecture-and-implementation-on-dotnet/)

In this repository I investigated how to build microservices on .NET environments with using ASP.NET Core Web API applications, Docker for containerize and orchestrate, communications between Microservices by gRPC and RabbitMQ, and using API Gateway with Ocelot API Gateway, different databases platforms NoSQL(MongoDB, Redis) and Relational databases(PostgreSQL, MSSQL Server), and using Dapper, Entity Framework Core for ORM Tools.

<div>
  <p align="center">
    <img src="https://miro.medium.com/v2/resize:fit:1400/format:webp/1*LkHA1vkfdcG6Zko2mj-PAQ.png"width="600"/>  
  </p>
</div>

There is a couple of microservices which implemented e-commerce modules over Catalog, Basket, Discount and Ordering microservices with NoSQL (MongoDB, Redis) and Relational databases (PostgreSQL, Sql Server) with communicating over gRPC and RabbitMQ Event Driven Communication and using Ocelot API Gateway.

### Catalog microservice
- ASP.NET Core Web API application
- REST API principles, CRUD operations
- MongoDB NoSQL database connection on docker containerization
- N-Layer implementation with Repository Pattern
- Swagger Open API implementation
- Dockerfile and docker-compose implementation

### Basket microservice
- ASP.NET Core Web API application
- REST API principles, CRUD operations
- Redis database connection on docker containerization
- Consume Discount Grpc Service for inter-service sync communication to calculate product final price
- Publish BasketCheckout Queue with using MassTransit and RabbitMQ
- Swagger Open API implementation
- Dockerfile and docker-compose implementation

### Discount microservice
- ASP.NET Grpc Server application
- Build a Highly Performant inter-service gRPC Communication with Basket Microservice
- Exposing Grpc Services with creating Protobuf messages
- Using Dapper for micro-orm implementation to simplify data access and ensure high performance
- PostgreSQL database connection and containerization
- Dockerfile and docker-compose implementation

### Ordering microservice
- ASP.NET Core Web API application
- Implementing DDD, CQRS and Clean Architecture with using Best Practices
- Developing CQRS with using MediatR, FluentValidation and AutoMapper nuget packages
- Consuming RabbitMQ BasketCheckout event queue with using MassTransit-RabbitMQ Configuration
- SqlServer database connection and containerization
- Using Entity Framework Core ORM and auto migrate to SqlServer when application Startup
- Swagger Open API implementation
- Dockerfile and docker-compose implementation