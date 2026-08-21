# Database Structure - lycevm.db

## Discovered Tables

* **Customers**: Primary Key (`Id`). Nullable column: `Phone`.
* **Departments**: Primary Key (`Id`). Nullable column: `Description`.
* **Employees**: Primary Key (`Id`). Foreign Key (`DepartmentId` -> `Departments.Id`). Nullable column: `JobTitle`.
* **Tags**: Primary Key (`Id`).
* **Teams**: Primary Key (`Id`). Foreign Key (`DepartmentId` -> `Departments.Id`). Nullable column: `Description`.
* **TeamMembers**: Composite Primary Key (`TeamId`, `EmployeeId`). Foreign Keys to `Teams` and `Employees`.
* **TicketCategories**: Primary Key (`Id`). Self-referencing FK (`ParentCategoryId` -> `TicketCategories.Id`). Nullable columns: `ParentCategoryId`, `Description`.
* **TicketPriorities**: Primary Key (`Id`).
* **TicketStatuses**: Primary Key (`Id`).
* **Tickets**: Primary Key (`Id`). FKs to `Customers`, `TicketCategories`, `TicketPriorities`, `TicketStatuses`. Nullable column: `DueAt`.
* **TicketAssignments**: Primary Key (`Id`). FKs to `Tickets` and `Employees`. Nullable column: `UnassignedAt`.
* **TicketComments**: Primary Key (`Id`). FKs to `Tickets` and `Employees`.
* **TicketAttachments**: Primary Key (`Id`). FK to `Tickets`.
* **TicketTags**: Composite Primary Key (`TicketId`, `TagId`). Foreign Keys to `Tickets` and `Tags`.