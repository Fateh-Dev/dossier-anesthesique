# Server.Net - Database Configuration

## Supported Databases

This application supports both **SQLite** and **PostgreSQL** databases with automatic provider detection based on the connection string pattern.

## Quick Start - Switching Databases

Simply change the `DefaultDb` value in `appsettings.json` or `appsettings.Development.json`:

### Use SQLite (Default)

```json
"DefaultDb": "SqliteDefaultConnection"
```

### Use PostgreSQL

```json
"DefaultDb": "PostgresDefaultConnection"
```

**That's it!** The application will automatically use the selected connection string and detect the appropriate database provider.

## Connection String Configuration

Both connection strings are pre-configured in `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "SqliteDefaultConnection": "Data Source=app.db",
    "PostgresDefaultConnection": "Host=localhost;Port=5432;Database=myappdb;Username=postgres;Password=yourpassword"
  },
  "DefaultDb": "SqliteDefaultConnection"
}
```

### SQLite Connection String Examples

**Detection**: Any connection string containing `Data Source=`

```
Data Source=app.db
Data Source=myapp.db
Data Source=./data/application.sqlite
Data Source=C:\\databases\\app.db
```

### PostgreSQL Connection String Examples

**Detection**: Any connection string containing `Host=`

```
Host=localhost;Port=5432;Database=myappdb;Username=postgres;Password=yourpassword
Host=localhost;Database=mydb;Username=admin;Password=secret
Host=db.example.com;Port=5432;Database=production_db;Username=app_user;Password=secure123
Host=127.0.0.1;Database=testdb;Username=postgres;Password=postgres;Pooling=true;
```

## How It Works

The application uses a two-step configuration process in `Program.cs`:

1. Reads the `DefaultDb` setting to determine which connection string to use
2. Retrieves the connection string from the `ConnectionStrings` section
3. Auto-detects the database provider:
   - Contains `"Data Source="` → Uses **SQLite**
   - Contains `"Host="` → Uses **PostgreSQL**

## Getting Started

### For SQLite (No setup required)

- The default configuration already uses SQLite
- Database file will be created automatically on first run
- Change `DefaultDb` to `"SqliteDefaultConnection"`

### For PostgreSQL

1. Install PostgreSQL on your machine or use a cloud service
2. Create a database
3. Update the PostgreSQL connection string in `appsettings.json` with your credentials
4. Change `DefaultDb` to `"PostgresDefaultConnection"`
5. Run the application

## Running the Application

```bash
# Restore packages
dotnet restore

# Build the project
dotnet build

# Run the application
dotnet run
```

## Adding Migrations (Entity Framework)

```bash
# Add a new migration
dotnet ef migrations add MigrationName

# Update the database
dotnet ef database update

# Remove last migration (if not applied)
dotnet ef migrations remove
```

## Notes

- Database is automatically created on startup using `EnsureCreated()` (development only)
- For production, use proper migrations instead of `EnsureCreated()`
- SQLite database files (\*.db) are excluded from version control via `.gitignore`
- Both connection strings can be customized to point to different databases
- You can add more connection string options if needed
