### 🛠️ Tech Stack

| Layer        | Tech                                                     |
| ------------ | -------------------------------------------------------- |
| Framework    | ASP.NET Core 8 Web API                                   |
| ORM          | Entity Framework Core                                    |
| Database     | SQL Server (LocalDB/Express)                             |
| Auth         | JWT Bearer Authentication                                |
| Architecture | Layered (API, Application, Auth, Infrastructure, Shared) |
| DI Container | Built-in .NET Dependency Injection                       |

---

## 📂 Solution Structure

```bash
EmployeeManagement/
│
├── EmployeeManagement.API             # ASP.NET Core Web API (entry point)
│   ├── Controllers                     # API Endpoints: Auth, Employees
│   ├── Program.cs                      # Main configuration (DI, JWT, CORS, Swagger)
│   └── appsettings.json                # DB connection, JWT secrets
│
├── EmployeeManagement.Application     # Business Logic Layer
│   ├── DTOs                            # Data Transfer Objects (EmployeeDto)
│   ├── Interfaces                      # IEmployeeService (Abstractions)
│   └── Services                        # EmployeeService (Implementation)
│
├── EmployeeManagement.Auth            # Authentication & JWT generation
│   ├── Services                        # AuthService, IAuthService
│   ├── JWT                             # JwtTokenGenerator
│
├── EmployeeManagement.Infrastructure  # Database + Entity Models
│   ├── DbContext                       # AppDbContext (EF Core)
│   ├── Entities                        # Employee.cs
│   └── Migrations                      # EF Core Migration files
│
└── EmployeeManagement.Shared          # Shared Models across layers
    └── Models                          # User.cs (used in Auth)
```

---

## ⚙️ How It Works

### ✅ Employee Management (CRUD)

* `GET /api/employees` → Get all employees
* `GET /api/employees/{id}` → Get employee by ID
* `POST /api/employees` → Add new employee
* `PUT /api/employees/{id}` → Update employee
* `DELETE /api/employees/{id}` → Delete employee

> All routes are protected via JWT Bearer Auth

---

### 🔐 Authentication

* **Register**: `POST /api/auth/register`
* **Login**: `POST /api/auth/login`

Login returns a **JWT token** that is required for all employee endpoints.

---

## 🔑 Password Security

* Passwords are securely hashed using `.NET's PasswordHasher<User>`.
* Stored hashes use PBKDF2 with automatic salting.
* No plain text passwords are stored.

---

## 🚀 Getting Started (Local Setup)

### 1. ✅ Prerequisites

* [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download)
* [SQL Server Express / LocalDB](https://learn.microsoft.com/en-us/sql/database-engine/configure-windows/sql-server-express-localdb)

---

### 2. 🧱 Setup Database

Run the following in **Package Manager Console**:

```bash
Update-Database -Project EmployeeManagement.Infrastructure
```

Ensure `appsettings.json` has the correct connection string:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SERVER;Database=EmployeeDb;Trusted_Connection=True;TrustServerCertificate=True;"
}
```

---

### 3. ▶️ Run the API

From terminal or Visual Studio:

```bash
dotnet run --project EmployeeManagement.API
```

---

### 4. 🌐 Test API

* Open Swagger UI: [https://localhost\:PORT/swagger](#)
* First: Call `POST /api/auth/register`
* Then: Call `POST /api/auth/login` → Get `token`
* Click **Authorize** in Swagger → enter:

  ```
  Bearer {your_token}
  ```

Now, test any `/api/employees` routes.

---

## 🔒 Security Notes

* JWT Tokens are signed using symmetric key (`HmacSha256`).
* Token validity: 1 hour.
* Only authenticated users can access employee data.

---

## 🧼 .gitignore Highlights

* Ignores: `bin/`, `obj/`, `*.user`, `*.suo`, migration snapshots, secrets
* See full list in `.gitignore`

---

## 📚 Important Concepts Used

* ✅ **Dependency Injection** for loose coupling
* ✅ **DTO pattern** for clean data transfer
* ✅ **Layered architecture** to separate concerns
* ✅ **Entity Framework Core** for ORM and migrations
* ✅ **JWT Authentication** for secure access
* ✅ **Password Hashing** with `PasswordHasher<T>`
* ✅ **CORS policy** to allow Blazor frontend

---

## 🙋‍♂️ Author Notes

This project was built as a **fresh developer assignment** to demonstrate:

* Good backend structure
* Secure user authentication
* Clean coding practices

---
