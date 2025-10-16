# Full-Stack Mobile Catalog Management (ASP.NET Core MVC)

## 🌟 Project Overview

This is a professional full-stack web application developed during a software development internship. It serves as a comprehensive **Mobile Product Catalog Management System**, enabling users (e.g., store administrators) to efficiently manage product listings, details, and associated images.

The project demonstrates mastery of the **Model-View-Controller (MVC)** architectural pattern using the **ASP.NET Core** framework, alongside robust data persistence and file management techniques.

## 🚀 Key Features

  * **Complete CRUD Operations:** Full functionality to **C**reate, **R**ead, **U**pdate, and **D**elete mobile product records.
  * **Image Management:** Secure handling and storage of product images, leveraging the server's file system (`FileLocation.cs`).
  * **Database Seeding:** Automatic initial population of the database with sample product data on startup (`SeedData.cs`).
  * **Data Validation:** Utilizes Data Annotations in C\# models (`Mobile.cs`, `MobileViewModel.cs`) for client-side and server-side input validation.
  * **View Model Pattern:** Effective separation of Domain Models (`Mobile.cs`) from Presentation Models (`MobileViewModel.cs`, `MobileModel.cs`) to ensure type safety and optimal data transfer.
  * **Error Handling:** Implemented a standard error view model (`ErrorViewModel.cs`) for graceful exception handling.

## 🛠️ Technology Stack

| Category | Technology | Purpose |
| :--- | :--- | :--- |
| **Backend Framework** | **ASP.NET Core** | Core web application framework. |
| **Architecture** | **MVC (Model-View-Controller)** | Guiding principle for application structure. |
| **Language** | **C\#** | Primary programming language. |
| **Database/ORM** | **Entity Framework Core (EF Core)** | ORM for data persistence and database management. |
| **Web Concepts** | **HTML, CSS, JavaScript** | Frontend structure and styling (Views). |
| **File Handling** | **IFormFile** (ASP.NET) | Handling file uploads (product images). |

## 📦 Project Structure (Key Components)

The project adheres to the standard ASP.NET Core MVC convention:

| Component | Files | Role |
| :--- | :--- | :--- |
| **Models (Domain)** | `Mobile.cs` | Represents the core entity (Database Schema). Includes EF Core mapping. |
| **ViewModels (DTO)** | `MobileViewModel.cs`, `MobileModel.cs` | DTOs for view rendering and data input. `MobileViewModel` specifically handles image upload (`IFormFile`). |
| **Controllers** | *(Missing, but essential)* | Manages user interaction, handles routing, and processes CRUD logic. |
| **Data/Config** | `SeedData.cs` | Ensures the database is initialized with initial data. |
| **Utilities** | `FileLocation.cs` | Defines static constants for file upload and retrieval paths. |

## 🚀 Getting Started

To run this project locally, you will need the [.NET SDK](https://dotnet.microsoft.com/download) installed.

1.  **Clone the repository:**
    ```bash
    git clone https://github.com/MahdisSep/DotNet-MVC-Mobile-Catalog.git
    cd DotNet-MVC-Mobile-Catalog
    ```
2.  **Restore dependencies:**
    ```bash
    dotnet restore
    ```
3.  **Apply Migrations (if using a local database like SQLite/SQL Server LocalDB):**
    ```bash
    dotnet ef database update
    ```
4.  **Run the application:**
    ```bash
    dotnet run
    ```

The application will typically start on `http://localhost:5000` or the port defined in `launchSettings.json`.