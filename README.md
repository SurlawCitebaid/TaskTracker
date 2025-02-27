# TaskTracker

A simple **ASP.NET Core** web application demonstrating:

1. **ASP.NET Core MVC** with Razor views and minimal JavaScript.
2. **Relational database** usage (Entity Framework Core).
3. **Multi-threading** with a **Hosted Service**.
4. Basic **C# / .NET** knowledge.

---

## Overview
This project is intended to show an end-to-end example of a .NET web application using ASP.NET Core MVC. The application manages simple tasks (with an optional user assignment) and periodically checks for overdue tasks in the background.

**Key Features**
- **MVC** structure with `Controllers`, `Views`, and `Models`.
- **EF Core** for database operations (SQL Server or SQLite).
- **Hosted Service** that checks overdue tasks asynchronously.

## Project Structure

- **Models**
  - `User.cs` – Represents an application user.
  - `TaskItem.cs` – Represents a task with a due date.
  - `TaskTrackerDbContext.cs` – EF Core DbContext.
- **Controllers**
  - `UsersController.cs` – Manage `User` CRUD.
  - `TasksController.cs` – Manage `TaskItem` CRUD.
- **Views** (Razor pages)
  - `Users` folder – `Index.cshtml`, `Create.cshtml`.
  - `Tasks` folder – `Index.cshtml`, `Create.cshtml`.
- **Services**
  - `OverdueTaskCheckerService.cs` – Background service to check overdue tasks.


