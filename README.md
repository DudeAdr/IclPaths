# IclPaths - Walking Trails Management System

![.NET Version](https://img.shields.io/badge/.NET-9.0-blue)
![License](https://img.shields.io/badge/License-MIT-green)

A comprehensive web application for discovering, managing, and exploring walking trails across different Iceland regions. The main part of the IclPaths project is the API, which contains the core business logic and functionality for managing walking trails, regions, difficulty levels, images, and related data. The MVC application is a simple preview/demo layer created only for presentation purposes, allowing users to visually explore and test the features provided by the API.


## 📋 Table of Contents

- [Project Overview](#project-overview)
- [Features](#features)
- [Architecture](#architecture)
- [Technology Stack](#technology-stack)
- [Prerequisites](#prerequisites)
- [Installation & Setup](#installation--setup)
- [Configuration](#configuration)
- [API Endpoints](#api-endpoints)
- [Database Schema](#database-schema)
- [Authentication](#authentication)
- [Project Structure](#project-structure)
- [Contributing](#contributing)
- [License](#license)

## 🎯 Project Overview

IclPaths is a full-stack application designed to help users explore and manage walking trails. The system consists of two main components:

- **IclPaths.API** - RESTful backend API with comprehensive trail management capabilities
- **IclPaths.UI** - Simple ASP.NET Core MVC frontend for user interaction and trail discovery

![alt text](image.png)

## ✨ Features

### Core Functionality

#### Regions Management
- Browse all available regions with walking trails
- View detailed region information including code, name, and imagery
- Create new regions (Admin)
- Edit existing region details (Admin)
- Delete regions (Admin)
- Image gallery support for regions

#### Walking Paths/Trails
- Comprehensive walking path catalog with detailed descriptions
- Difficulty level classification (Easy, Moderate, Hard, Expert)
- Distance and duration information
- Elevation gain tracking
- Route descriptions and highlights
- Image galleries for each trail
- Sort and filter capabilities

#### Image Management
- Upload images for regions and walking paths
- Image storage and retrieval
- Gallery view support

#### Authentication & Authorization
- User registration and login
- JWT-based authentication
- Role-based access control (Reader, Admin)
- Secure password management using ASP.NET Core Identity
- Token generation and validation

### API Features
- RESTful API design
- API versioning (v1.0)
- Swagger/OpenAPI documentation
- Comprehensive error handling with custom middleware
- Structured logging with Serilog
- Request/response validation
- Custom action filters for validation and null checks

## 🏗️ Architecture

### Design Patterns
- **Repository Pattern** - Data access abstraction layer
- **Dependency Injection** - Loosely coupled component management
- **DTO Pattern** - Data transfer objects for API contracts
- **Auto Mapper** - Object-to-object mapping automation
- **MVC Architecture** - Separation of concerns in the UI layer

### Layered Architecture

```
IclPaths.API
├── Controllers         - API endpoints
├── Domain
│   ├── Interfaces      - Repository contracts
│   └── Repositories    - Data access implementation
├── Models
│   ├── DomainModels    - Entity models
│   ├── DTO             - Data transfer objects
│   └── Enums           - Enumeration types
├── Mappings            - Auto Mapper profiles
├── Persistance         - Database context
├── CustomActionFilters - Request validation filters
└── Middlewares         - Exception handling

IclPaths.UI
├── Controllers         - MVC controllers
├── Models              - View models
├── Services            - Business logic
├── Views               - Razor views
└── Configuration       - App settings
```

## 🛠️ Technology Stack

### Backend
- **.NET 9.0** - Application framework
- **ASP.NET Core** - Web API and MVC
- **Entity Framework Core** - ORM for data access
- **SQL Server** - Primary database
- **ASP.NET Core Identity** - Authentication and authorization
- **JWT (JSON Web Tokens)** - Token-based authentication
- **AutoMapper** - Object mapping
- **Serilog** - Structured logging
- **Swagger/Swagger UI** - API documentation

### Frontend
- **ASP.NET Core MVC** - Web application framework
- **Razor Pages** - Template engine
- **HTML5/CSS3** - Markup and styling
- **Bootstrap** - Responsive UI framework

## 📦 Prerequisites

- **.NET 9.0 SDK** or later
- **SQL Server 2019** or later (or SQL Server Express)
- **Visual Studio 2022** or Visual Studio Code
- **Git** for version control

## 🚀 Installation & Setup

### 1. Clone the Repository

```bash
git clone https://github.com/DudeAdr/IclPaths.git
cd IclPaths
```

### 2. Open the Solution

```bash
# Using Visual Studio
start IclPaths.sln

# Or using Visual Studio Code
code .
```

### 3. Restore Dependencies

```bash
dotnet restore
```

### 4. Update Database

```bash
# Navigate to API project
cd IclPaths.API

# Apply migrations
dotnet ef database update --context IclPathsDbContext
dotnet ef database update --context IclPathsAuthDbContext

# Return to root
cd ..
```

### 5. Run the Application

```bash
# Terminal 1 - Start the API
cd IclPaths.API
dotnet run

# Terminal 2 - Start the UI (in a new terminal)
cd IclPaths.UI
dotnet run
```

### 6. Access the Application

- **UI Application**: https://localhost:7000 (adjust port as needed)
- **API**: https://localhost:7001 (adjust port as needed)
- **Swagger Documentation**: https://localhost:7001/swagger/index.html

## ⚙️ Configuration

### appsettings.json (IclPaths.API)

```json
{
  "ConnectionStrings": {
    "IclPathsConnectionString": "Server=YOUR_SERVER;Database=IclPaths;Trusted_Connection=true;TrustServerCertificate=true;",
    "IclPathsAuthConnectionString": "Server=YOUR_SERVER;Database=IclPathsAuth;Trusted_Connection=true;TrustServerCertificate=true;"
  },
  "Jwt": {
    "Key": "YOUR_SECURE_JWT_KEY",
    "Issuer": "YOUR_ISSUER",
    "Audience": "YOUR_AUDIENCE"
  }
}
```

### appsettings.json (IclPaths.UI)

```json
{
  "APIUrls": {
    "IclPathsAPI": "https://localhost:7001"
  }
}
```

## 📡 API Endpoints

### Authentication Endpoints
- `POST /api/auth/register` - Register new user
- `POST /api/auth/login` - User login

### Regions Endpoints
- `GET /api/regions` - Get all regions
- `GET /api/regions/{id}` - Get region by ID
- `POST /api/regions` - Create new region (Admin)
- `PUT /api/regions/{id}` - Update region (Admin)
- `DELETE /api/regions/{id}` - Delete region (Admin)

### Walking Paths Endpoints
- `GET /api/walks` - Get all walking paths
- `GET /api/walks/{id}` - Get path by ID
- `GET /api/walks/region/{regionId}` - Get paths by region
- `POST /api/walks` - Create new path (Admin)
- `PUT /api/walks/{id}` - Update path (Admin)
- `DELETE /api/walks/{id}` - Delete path (Admin)

### Images Endpoints
- `POST /api/images/upload` - Upload image
- `GET /api/images/{id}` - Download image

All protected endpoints require JWT authentication token in the Authorization header:
```
Authorization: Bearer YOUR_JWT_TOKEN
```

## 🗄️ Database Schema

### Core Tables

#### Regions
- Id (GUID)
- Code (string)
- Name (string)
- RegionImageUrl (string, nullable)

#### WalkPaths
- Id (GUID)
- Name (string)
- Description (text)
- LengthInKm (decimal)
- ElevationGainInMeter (int)
- ImageUrl (string, nullable)
- DifficultyId (GUID)
- RegionId (GUID)

#### Difficulties
- Id (GUID)
- Name (string) - Easy, Moderate, Hard, Expert

#### Images
- Id (GUID)
- FileName (string)
- FileDescription (string, nullable)
- FileExtension (string)
- FileSizeInBytes (long)
- FilePath (string)

#### AspNetUsers (Identity)
- Id (string)
- UserName (string)
- Email (string)
- PasswordHash (string)

#### AspNetRoles (Identity)
- Id (string)
- Name (string) - Reader, Admin

## 🔐 Authentication

### User Roles

- **Reader** - Can view regions and walking paths
- **Admin** - Full access including create, update, and delete operations

### JWT Token

Tokens are issued upon successful login and valid for a configured duration. Include the token in all subsequent requests:

```http
Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...
```

## 📂 Project Structure

```
IclPaths/
├── IclPaths.API/
│   ├── Controllers/          - API endpoints
│   ├── Domain/
│   │   ├── Interfaces/       - Repository interfaces
│   │   └── Repositories/     - Data access classes
│   ├── Models/               - Domain and DTO models
│   ├── Mappings/             - AutoMapper profiles
│   ├── Persistance/          - Database contexts
│   ├── Migrations/           - EF Core migrations
│   ├── Middlewares/          - Custom middleware
│   ├── Program.cs            - Application configuration
│   └── appsettings.json      - Configuration
│
├── IclPaths.UI/
│   ├── Controllers/          - MVC controllers
│   ├── Views/                - Razor views
│   ├── Models/               - View models
│   ├── Services/             - Business logic services
│   ├── Configuration/        - App settings classes
│   ├── Program.cs            - Application configuration
│   └── appsettings.json      - Configuration
│
└── README.md                 - This file
```

## 📝 Logging

The application uses **Serilog** for structured logging with the following outputs:
- Console output
- Rolling file logs (daily) in `Logs/IclPaths_log.txt`
- Minimum log level: Information

## 🐛 Error Handling

Custom exception handling middleware provides consistent error responses:

```json
{
  "error": "Error message",
  "statusCode": 400,
  "timestamp": "2024-01-15T10:30:00Z"
}
```

