# Spendle

**Spendle** is a modern finance tracker web application that helps users manage their income, expenses, assets, and debts. Built with a C# (ASP.NET Core) backend, Spendle allows users to log financial data and view their net worth in real-time.

🚧 **This project is currently under active development.** Expect frequent changes, incomplete features, and ongoing improvements.

## Tech Stack
#### Backend Core:
- **Framework**: ASP.NET Core 8.0 (Web API)
- **Language**: C#

#### Data & Infrastructure:
- **Database**: Microsoft SQL Server
- **ORM**: Entity Framework Core 8.0
- **Containerization**: Docker
- 
#### Security & Tools
- **Hashing**: BCrypt.Net-Next 
- **API Documentation**: Swagger / OpenAPI 
- **IDE**: JetBrains Rider 

## Features (Work In Progress)

- Track income and expenses
- Calculate and display total net worth
- API status checker endpoint (`/api/status`)

## Getting Started

### Prerequisites

- [.NET SDK 8+](https://dotnet.microsoft.com/)
- A code editor (Rider, VS Code, etc.)
- Docker Desktop (for Mac/Linux users)

### Key Technical Decisions
#### Transition to Relational Data
- The project was migrated from **MongoDB** to **SQL Server** to enforce strict data integrity. While NoSQL offers flexibility, financial tracking 
requires robust relational links between Users, Transactions, and Accounts. SQL Server's ACID compliance ensures that every entry is accurate and consistent.