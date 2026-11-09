# RaceDay - Event Management System (PROG6212 POE)

## Project Description
RaceDay is a full-stack web application designed for the South African road running, walking, and cycling community. It allows Organisers to create and manage events, and Participants to browse and enter events.

## Roles
1. **Organiser**: Can create, edit, and delete events. Can view participant enrolments.
2. **Participant**: Can browse upcoming events, enter events, and view their personal results.

## Architecture
This project is split into two main solutions:
* **`RaceDay.API`**: A C# RESTful API using Entity Framework Core and SQL Server.
* **`RaceDay.Web`**: An ASP.NET Core MVC Web Application that consumes the API.

## How to Run Locally
1. **Start the Database & API:**
   * Open the `RaceDay.API` project in Visual Studio.
   * Press `F5` to run it. A Swagger page will open (e.g., `https://localhost:7202/swagger`).
   
2. **Start the Web App:**
   * Open the `RaceDay.Web` project.
   * Make sure the `Program.cs` file points to the correct API port.
   * Press `F5` to run it. The web application will open in your browser (e.g., `https://localhost:7172`).

## How to Run with Docker
We have containerised the MVC Web Application. To build and run it using Docker, use the following commands:

1. Navigate to the root folder (where the Dockerfile is located).
2. Build the Docker image:
   ```bash
   docker build -t raceday-web -f RaceDay.Web/Dockerfile .# RaceDay.Web

   ## Youtube video link
   https://youtube.com/shorts/LkNlAJuAIOU?si=0OM3kwAJ6vtHcNLl
   
