# .NET 8 + Angular Template

A modern, production-ready full-stack application template featuring .NET 8 Web API backend with Angular frontend, complete with JWT authentication, role-based access control (RBAC), and a beautiful UI.

## 🚀 Features

### Backend (Server.Net)

- **.NET 8 Web API** - Latest .NET framework
- **JWT Authentication** - Secure token-based authentication
- **Role-Based Access Control (RBAC)** - Admin and User roles
- **Multi-Database Support** - Easy switching between SQLite and PostgreSQL
- **Entity Framework Core 8** - Modern ORM with migrations support
- **ASP.NET Core Identity** - Built-in user management
- **Swagger/OpenAPI** - Interactive API documentation with JWT support
- **CORS Configuration** - Pre-configured for Angular client

### Frontend (AngularClient)

- **Angular (Latest)** - Modern, standalone components
- **Tailwind CSS v3** - Utility-first CSS framework
- **JWT Token Management** - Automatic token storage and validation
- **Route Guards** - Protected routes with authentication
- **Splash Screen** - Loading screen during initialization
- **Modern Dashboard** - Beautiful gradient stat cards and responsive layout
- **Dark Mode Support** - Built-in dark/light theme
- **Responsive Design** - Mobile-first approach with collapsible sidebar
- **Token Expiration Handling** - Automatic logout on expired tokens

## 📋 Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Node.js](https://nodejs.org/) (v18 or higher)
- [Angular CLI](https://angular.io/cli) (`npm install -g @angular/cli`)
- (Optional) [PostgreSQL](https://www.postgresql.org/) for production database

## 🛠️ Getting Started

### 1. Clone the Repository

```bash
git clone https://github.com/Fateh-Dev/_.Net_Angular_Template.git
cd _.Net_Angular_Template
```

### 2. Backend Setup

```bash
cd Server.Net

# Restore dependencies
dotnet restore

# Update database connection (optional)
# Edit appsettings.json to configure your database

# Run the application
dotnet run
```

The API will be available at `https://localhost:5022` (or the port shown in the console).

### 3. Frontend Setup

```bash
cd AngularClient

# Install dependencies
npm install

# Run the development server
npm start
```

The Angular app will be available at `http://localhost:4200`.

## 🗄️ Database Configuration

The template supports both SQLite and PostgreSQL. Switch between them easily:

### Using SQLite (Default)

```json
{
  "DefaultDb": "SqliteDefaultConnection"
}
```

### Using PostgreSQL

```json
{
  "DefaultDb": "PostgresDefaultConnection"
}
```

Update the connection strings in `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "SqliteDefaultConnection": "Data Source=app.db",
    "PostgresDefaultConnection": "Host=localhost;Port=5432;Database=myappdb;Username=postgres;Password=yourpassword"
  },
  "DefaultDb": "SqliteDefaultConnection"
}
```

See [Server.Net/README.md](Server.Net/README.md) for more details.

## 🔐 Authentication

### Default Roles

- **Admin** - Full access
- **User** - Standard access

### Testing Authentication

1. **Register a User** (via Swagger at `https://localhost:5022/swagger`):

   - Navigate to `POST /api/auth/register`
   - Use credentials like:
     ```json
     {
       "email": "test@example.com",
       "password": "Password123!"
     }
     ```

2. **Login** (in Angular app):

   - Go to `http://localhost:4200/login`
   - Enter your credentials
   - You'll be redirected to the dashboard

3. **Token Storage**:
   - Tokens are stored in `localStorage`
   - Automatically included in API requests
   - Validated on each page load

## 📁 Project Structure

```
.
├── Server.Net/                 # .NET 8 Web API
│   ├── Controllers/           # API Controllers
│   │   └── AuthController.cs # Authentication endpoints
│   ├── Data/                  # Database context and seeding
│   │   ├── ApplicationDbContext.cs
│   │   └── DbSeeder.cs
│   ├── DTOs/                  # Data Transfer Objects
│   │   └── AuthDtos.cs
│   ├── Models/                # Entity models
│   │   └── ApplicationUser.cs
│   ├── appsettings.json       # Configuration
│   └── Program.cs             # Application entry point
│
└── AngularClient/             # Angular Frontend
    ├── src/
    │   ├── app/
    │   │   ├── components/    # Reusable components
    │   │   │   └── splash-screen/
    │   │   ├── guards/        # Route guards
    │   │   │   └── auth.guard.ts
    │   │   ├── pages/         # Page components
    │   │   │   ├── home/      # Dashboard
    │   │   │   └── login/     # Login page
    │   │   ├── services/      # Services
    │   │   │   └── auth.service.ts
    │   │   ├── app.routes.ts  # Routing configuration
    │   │   └── app.config.ts  # App configuration
    │   └── styles.scss        # Global styles (Tailwind)
    └── tailwind.config.js     # Tailwind configuration
```

## 🎨 UI Features

- **Gradient Stat Cards** - Beautiful dashboard with statistics
- **Collapsible Sidebar** - Space-efficient navigation
- **Responsive Design** - Works on all screen sizes
- **Dark Mode** - Automatic theme switching
- **Loading States** - Splash screen and loading indicators
- **Form Validation** - Real-time validation feedback

## 🔧 Configuration

### JWT Settings (appsettings.json)

```json
{
  "Jwt": {
    "Key": "YourSuperSecretKeyHere_MakeSureItIsLongEnough",
    "Issuer": "Server.Net",
    "Audience": "AngularClient",
    "ExpireDays": 30
  }
}
```

⚠️ **Important**: Change the JWT key in production and store it securely (e.g., Azure Key Vault, environment variables).

### CORS Settings

The backend is pre-configured to allow requests from `http://localhost:4200`. Update in `Program.cs` for production.

## 📝 Available Scripts

### Backend

```bash
dotnet restore          # Restore dependencies
dotnet build           # Build the project
dotnet run             # Run the application
dotnet ef migrations add [Name]  # Create migration
dotnet ef database update        # Apply migrations
```

### Frontend

```bash
npm install            # Install dependencies
npm start              # Start dev server
npm run build          # Build for production
npm test               # Run tests
```

## 🚢 Deployment

### Backend

1. Update `appsettings.json` for production
2. Use proper database (PostgreSQL recommended)
3. Set environment variables for secrets
4. Deploy to Azure App Service, AWS, or your preferred host

### Frontend

1. Build the production bundle: `npm run build`
2. Deploy the `dist/` folder to your hosting service
3. Update API URL in `auth.service.ts`

## 🤝 Contributing

Feel free to fork this template and customize it for your needs!

## 📄 License

This template is open source and available under the MIT License.

## 🙋 Support

For issues or questions, please open an issue on GitHub.

---

**Built with ❤️ using .NET 8 and Angular**
