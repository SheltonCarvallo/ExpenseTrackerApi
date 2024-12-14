# Expense Tracker API
> _[!NOTE]_
> This project is still under development. Features and functionality may change, and new features will be added in future updates.

This personal project is a backend API for tracking personal expenses. It's built using **.NET 8** and follows the principles of **Clean Architecture**. The API utilizes **Entity Framework (EF) Core** as the ORM, with **SQL Server** as the database provider.

## Features

- **User Authentication**: Secure login and registration (planned to use JWT authentication).
- **Expense Management**: Add, edit, delete, and view personal expenses.
- **Category Management**: Create and manage categories for expenses.
- **Transaction Filtering**: Filter transactions by date, category, and amount.

## Project Structure

The project is organized into three main layers:

1. **ModelLayer**:
   - Contains DTOs and Models that represent the core entities (Expenses, Categories, etc.).

2. **DataLayer**:
   - Responsible for database connections, migrations, and configurations.
   - Contains the `ExpenseTrackerDbContext.cs` for database operations.

3. **ExpenseTrackerApi**:
   - Main API project containing the business logic, controllers, and services.
   - Authentication, Controllers, and Services are organized into their respective folders.

## Technologies

- **.NET 8**
- **Entity Framework Core** (EF Core)
- **SQL Server**
- **JWT Authentication** (in progress)
- **Clean Architecture**

## Setup and Installation

To run this project locally:

1. Clone the repository:
   ```bash
   git clone https://github.com/your-username/expense-tracker-api.git
   cd expense-tracker-api
