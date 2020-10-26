# DDD.CQRS

A set of NuGet packages for working with DDD and CQRS.

---

*src*/**DDD.CQRS.Abstract** - Assembly that should not reference any libraries or projects. Contains basic POCO classes used by application (commands, exceptions, DTOs, API requests and responses). This assembly can be shared to other applications.

*src*/**DDD.CQRS.DataAccess.EF** - Assembly that contains database access logic. There should be implementation for Unit of Work, Repositories related to EntityFramework. The assembly references ORM directly.

*src*/**DDD.CQRS.Domain** - Domain of application. Business logic goes here. See below.

*src*/**DDD.CQRS.Infrastructure** - Shared infrastructure details: dependency injection configuration, AutoMapper profile, etc.


## Used by

- [DDD.CQRS.ProjectTemplate](https://github.com/my-repositories/DDD.CQRS.ProjectTemplate)
