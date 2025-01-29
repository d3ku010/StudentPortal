# StudentPortal

## Table of Contents
1. [Project Overview](#project-overview)
2. [Objectives](#objectives)
3. [Features](#features)
4. [Technology Stack](#technology-stack)
5. [System Requirements](#system-requirements)
6. [Setup and Installation](#setup-and-installation)
7. [Usage](#usage)

---

## Project Overview

The **StudentPortal** is a web application designed to manage student records. Users can perform **CRUD** operations on students, including adding their details such as Name, Email, Phone, and Club. The system provides an intuitive interface for managing student data stored in a SQL Server database using **Entity Framework**.

---

## Objectives

- Develop a web application using **ASP.NET MVC** to manage student data.
- Implement **CRUD** operations for adding, viewing, editing, and deleting student information.
- Use **Entity Framework** for database interaction and automatic schema management.
- Provide a simple user interface using **Bootstrap**.

---

## Features

- **Add Students**: Input student details such as Name, Email, Phone, and Club affiliation.
- **List Students**: Display a list of all students in the system.
- **Edit Students**: Update existing student information.
- **Delete Students**: Remove student records from the database.
- **Validation**: Basic data validation to ensure correct input.
- **Responsive UI**: User-friendly interface built with **Bootstrap** for responsive design.

---

## Technology Stack

- **ASP.NET MVC**: Framework used for building the web application.
- **Entity Framework**: ORM for managing database interactions.
- **SQL Server**: Database to store student information.
- **Bootstrap**: Frontend framework for styling and responsive design.

---

## System Requirements

- **.NET 8.0** or later
- **SQL Server** (local or remote)
- Visual Studio or Visual Studio Code with **.NET** extensions
- **Git** (for version control)

---

## Setup and Installation

1. **Clone the repository**:
    Clone the repository to your local machine using Git:
   ```bash
   git clone https://github.com/d3ku010/StudentPortal.git
   cd StudentPortal
   ```

2. **Restore .NET dependencies:
    ```bash
   dotnet restore
    ```
3. **Configure the database:
    Open appsettings.json and configure the connection string to point to your SQL Server instance:
   ```json
   "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=StudentPortalDb;Trusted_Connection=True;"
    }
    ```
   
4. **Apply Entity Framework migrations:
   Create the database and apply the initial schema using the following commands:
    ```bash
    dotnet ef migrations add InitialCreate
    dotnet ef database update
    ```

5. **Run the application:
    Run the project using Visual Studio or the .NET CLI:
    ```bash
    dotnet run
    ```
6. **Access the application:
   After the application is running, open your browser and navigate to http://localhost:5000 (or the port specified in the output).


---

## Usage

1. **Add a Student:
  Navigate to the "Add Student" page, enter the required details (Name, Email, Phone, Club), and submit the form.
  
2. **View Students:
  The homepage lists all students stored in the database with their details.
  
3. **Edit a Student:
  Click "Edit" next to a student’s name to update their information.

4. **Delete a Student:
  Click "Delete" next to a student’s entry to remove their record from the database.


---
