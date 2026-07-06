# BookingSystem: Event & Venue Management Platform

**Author:** Mukonazwothe R. Ntsandeni  
**Email:** mukonantsandeni@gmail.com  

The **BookingSystem** is a robust, cloud-ready web application built using **ASP.NET Core MVC**. It provides an end-to-end solution for managing events, venues, and bookings. Designed with a focus on data integrity and user experience, the application features a conflict-detection engine to prevent double-bookings, dynamic venue capacity management, and seamless Azure cloud integration.

---

## Setup Instructions

Follow these steps to prepare the environment for your application:

* **Requirements:** Ensure you have Visual Studio 2022 and the .NET 8.0 SDK (or newer) installed.
* **Cloning:** Clone the repository to your local development environment using GitHub Desktop or via the terminal.
* **Database:** The application uses Entity Framework Core. Upon opening the solution, run the following command in the **Package Manager Console** to initialize your local database:
  ```bash
  Update-Database
  ```
* **Configuration:** Update the `appsettings.json` file with your local connection strings and Azure Blob Storage credentials (if utilizing cloud storage features).
* **Compilation:** Build the solution in Visual Studio to restore all NuGet packages and dependencies.

---

## How to Use the App (Features & Examples)

### 1. Managing Venues
The Venue module allows administrators to maintain the physical locations available for booking.
* **Feature:** Upload images directly to Azure Blob Storage and set capacity limits for each venue.
* **Example:** Navigate to `Venues > Create`, enter the Venue Name, Location, and Capacity. Click *Save* to add it to the live index.

### 2. Event Scheduling
Organize events and categorize them for easy filtering.
* **Feature:** Set specific date and time stamps for events and assign them to categories (e.g., Workshop, Conference).
* **Example:** In `Events > Create`, select your event type from the dropdown, choose your date/time, and create the event. The index page will display the formatted date and time for all upcoming events.

### 3. Intelligent Booking Engine
The core of the system is the booking interface, which prevents scheduling conflicts.
* **Conflict Prevention:** The system performs a real-time availability check. If you attempt to book a venue that is already occupied during your selected time, the system will block the request and provide a clear error message.
* **Edit Validation:** Unlike basic systems, our Edit logic correctly identifies and excludes the current record from conflict checks, allowing you to modify existing bookings without triggering false alarms.

### 4. Navigation & Filtering
Quickly find relevant information using the integrated search and filter tools.
* **Filtering:** Use the search bar or filter dropdowns on the Bookings page to view events by Type, Date range, or Name.

### 5. Media Support
* **Feature:** With the use of Azure Blob Storage, users can upload and manage the images used for the venues and events.

---

## Continuous Integration & GitHub

### Cloud Deployment
The application is architected for the Azure PaaS ecosystem. Using the Visual Studio "Publish" wizard, the project is configured to deploy to an **Azure App Service**, utilizing **Azure SQL Database** for persistent storage and **Azure Blob Storage** for media assets.

### Project Demonstration
You can view the application in action here:
* **YouTube Link:** [Watch the Demonstration Video](https://youtu.be/h1alEdT6kdI?si=N3tQgh-H2OSXgQfy)

---

### The "Go Live" Migration
<img width="602" height="288" alt="Picture1" src="https://github.com/user-attachments/assets/8dbb381e-207f-47cc-adf1-247664c3a422" />

<img width="602" height="287" alt="Picture2" src="https://github.com/user-attachments/assets/259b6298-d67a-483d-995f-440018c4defd" />

<img width="602" height="165" alt="Picture3" src="https://github.com/user-attachments/assets/2ef28480-a6c3-4f1d-9d3c-45a3d5790ca6" />


### Live Deployment & Dropping of Resources

<img width="602" height="306" alt="Picture5" src="https://github.com/user-attachments/assets/fe544c95-20e0-43d7-8200-32c7c0ff8688" />

<img width="752" height="381" alt="Picture6" src="https://github.com/user-attachments/assets/4c695465-549d-4f67-ba3e-e71d8ef2afe2" />

<img width="602" height="203" alt="Picture7" src="https://github.com/user-attachments/assets/4d90c47d-fe09-469d-8dc9-9bbe193957da" />

<img width="602" height="270" alt="Picture8" src="https://github.com/user-attachments/assets/2668d352-f7d8-416b-aaff-323f1393efac" />

<img width="440" height="112" alt="Picture9" src="https://github.com/user-attachments/assets/18992fb2-1f34-48fb-9fff-1acd6aa73f04" />

<img width="602" height="267" alt="Picture10" src="https://github.com/user-attachments/assets/8f6cbcd8-1843-4f98-9d88-c828a61f5f7f" />







