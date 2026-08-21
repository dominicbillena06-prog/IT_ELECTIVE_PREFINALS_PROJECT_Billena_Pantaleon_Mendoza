# IT Elective Prefinals Project

## Project Overview
This is an ASP.NET Core MVC application developed using EF Core and SQLite. The system handles ticket browsing, detailed workflows, workload analytics, and database entity management.

---

## Environment & Prerequisites
* **Framework:** .NET 8 / ASP.NET Core MVC
* **Database Engine:** SQLite (`lycevm.db`)
* **ORM:** Entity Framework Core
* **IDE:** Visual Studio 2022

---

## Getting Started

### 1. Clone the Repository
```bash
git clone https://github.com/dominicbillena06-prog/IT_ELECTIVE_PREFINALS_PROJECT_Billena_Pantaleon_Mendoza.git
```
### 2. Database Configuration
* Place the `lycevm.db` SQLite database file inside the root project folder.
* Ensure the connection string in `appsettings.json` points directly to `Data Source=lycevm.db`.
* Refer to `DATABASE.md` for entity mappings, primary key configurations, and schema details.

### 3. Build & Run
1. Open `IT_ELECTIVE_PREFINALS_PROJECT.slnx` in Visual Studio 2022.
2. Restore NuGet Packages (`Tools` -> `NuGet Package Manager` -> `Restore NuGet Packages`).
3. Press `Ctrl + Shift + B` to build the solution.
4. Press `F5` to run the application locally.

---

## Application Architecture & Features
* **Core Entities:** Employees, Departments, Categories, Priorities, Statuses, Tags, Tickets, Comments, and Attachments.
* **US1 - Database Model Setup:** SQLite integration, DbContext mapping, and relational seed data.
* **US2 - Navigation & Core Browsing Views:** Controller actions and Razor views for navigating core system entities.
* **US3 - Ticket Management Flow:** Complete `Index` listing and detailed `Details` view for displaying composite ticket relationships (Tags, Assignments, Comments, Attachments).
* **US4 - Workload Analytics:** Custom LINQ queries and dynamic reporting views for active workload breakdown.

---

## Team Roles & Responsibilities
* **Billena (Member A):** Database Setup (US1), DbContext Configuration, & Workload Analytics (US4)
* **Pantaleon (Member B):** Dependency Injection Setup, Core Browsing Views (US2), & Layout Design
* **Mendoza (Member C):** Core Ticket Management Flow (US3) & Database Model Fixes