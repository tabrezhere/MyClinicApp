# Clinic Management System

## Overview
The Clinic Management System is a Blazor-based web application designed to facilitate the management of clinics. It provides functionalities for managing patient information, doctor prescriptions, and clinic operations across multiple clinics. The application supports various user roles, including admin, receptionists, and doctors.

## Technology Stack
- **Frontend**: Blazor (WebAssembly)
- **Backend**: ASP.NET Core (C#) - 8.0
- **Database**: SQL Server
- **ORM**: Entity Framework Core

## Key Features
1. **Receptionist Login**: Receptionists can log in to register new patients and check their BP/Diabetes status.
2. **Doctor Login**: Doctors can log in to view the latest patients and manage prescriptions.
3. **Prescription Management**: Doctors can create, edit, and delete prescriptions for patients.
4. **Prescription Reports**: Generate and print prescription reports, including patient details and barcodes.
5. **Admin Panel**: Admins can manage clinics, users, and oversee the entire system.
6. **Data Modeling**: Utilizes Entity Framework Core for data storage and management.

## Project Structure
```
ClinicManagementSystem
├── Client
│   ├── wwwroot
│   ├── Pages
│   ├── Shared
│   ├── Program.cs
│   └── App.razor
├── Server
│   ├── Controllers
│   ├── Data
│   ├── Models
│   ├── Services
│   ├── Program.cs
│   ├── Startup.cs
│   └── appsettings.json
├── Shared
│   ├── DTOs
│   └── Enums
├── Tests
│   ├── ClientTests
│   ├── ServerTests
│   └── SharedTests
├── ClinicManagementSystem.sln
└── README.md
```

## Getting Started
1. Clone the repository.
2. Open the solution in your preferred IDE.
3. Restore the NuGet packages.
4. Update the connection string in `Server/appsettings.json` to point to your SQL Server database.
5. Run the application.

## Contributing
Contributions are welcome! Please submit a pull request or open an issue for any enhancements or bug fixes.

## License
This project is licensed under the MIT License. See the LICENSE file for details.