# Office Inventory System

This is a .NET-based application designed to manage office inventory. The system includes modules for handling equipment and maintenance tasks.

## Project Structure

- **OfficeInventorySystem**: The main web project.
- **OfficeInventorySystem.Application**: Contains application logic and interfaces.
- **OfficeInventorySystem.Domain**: Defines the domain models.
- **OfficeInventorySystem.Infrastructure**: Provides infrastructure support.
- **OfficeInventorySystem.Persistence**: Manages data persistence using Entity Framework Core.

## Prerequisites

- .NET SDK 8.0
- SQL Server (or any compatible database)
- Git

## Setup Instructions

### 1. Clone the Repository

```bash
git clone <repository-url>
cd OfficeInventorySystem
```

### 2. Restore NuGet Packages

```bash
dotnet restore
```

### 3. Create and Initialize Database

Execute the SQL script to create the database and tables:

```bash
sqlcmd -S <your-server-name> -d master -i OfficeInventorySystem.Persistence/Scripts/CreateOfficeInventoryDB.sql
```

### 4. Build the Solution

```bash
dotnet build
```

### 5. Run the Application

```bash
dotnet run --project OfficeInventorySystem
```

## Running the Application

After completing the setup, the application will be accessible at:
- HTTPS: `https://localhost:7288`
- HTTP: `http://localhost:5105` (if HTTPS is not configured)


## Configuration

The application configuration is stored in `appsettings.json`. You may need to modify the connection string to match your database setup:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=<your-server-name>;Integrated Security=true;Initial Catalog=OfficeInventoryDB;"
}
```

## Important Notes

- Ensure that SQL Server is running and accessible.
- Replace `<your-server-name>` with your actual SQL server instance name.
- The `CreateOfficeInventoryDB.sql` script initializes the database and inserts initial data for equipment types. Make sure to execute this script before running the application.


