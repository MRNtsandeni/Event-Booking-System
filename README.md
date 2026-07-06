BookingSystem: Event & Venue Management Platform
Author:
Mukonazwothe R. Ntsandeni
Email: mukonantsandeni@gmail.com

The BookingSystem is a robust, cloud-ready web application built using ASP.NET Core MVC. It provides an end-to-end solution for managing events, venues, and bookings. Designed with a focus on data integrity and user experience, the application features a conflict-detection engine to prevent double-bookings, dynamic venue capacity management, and seamless Azure cloud integration.

Setup Instructions
Follow these steps to prepare the environment for your application:

Requirements: Ensure you have Visual Studio 2022 and the .NET 8.0 SDK (or newer) installed.

Cloning: Clone the repository to your local development environment using GitHub Desktop or via the terminal.

Database: The application uses Entity Framework Core. Upon opening the solution, run the following commands in the Package Manager Console to initialize your local database:

Update-Database

Configuration: Update the appsettings.json file with your local connection strings and Azure Blob Storage credentials (if utilizing cloud storage features).

Compilation: Build the solution in Visual Studio to restore all NuGet packages and dependencies.

How to Use the App (Features & Examples)
1. Managing Venues
The Venue module allows administrators to maintain the physical locations available for booking.

Feature: Upload images directly to Azure Blob Storage and set capacity limits for each venue.

Example: Navigate to Venues > Create, enter the Venue Name, Location, and Capacity. Click Save to add it to the live index.

2. Event Scheduling
Organize events and categorize them for easy filtering.

Feature: Set specific date and time stamps for events and assign them to categories (e.g., Workshop, Conference).

Example: In Events > Create, select your event type from the dropdown, choose your date/time, and create the event. The index page will display the formatted date and time for all upcoming events.

3. Intelligent Booking Engine
The core of the system is the booking interface, which prevents scheduling conflicts.

Conflict Prevention: The system performs a real-time availability check. If you attempt to book a venue that is already occupied during your selected time, the system will block the request and provide a clear error message.

Edit Validation: Unlike basic systems, our Edit logic correctly identifies and excludes the current record from conflict checks, allowing you to modify existing bookings without triggering false alarms.

4. Navigation & Filtering
Quickly find relevant information using the integrated search and filter tools.

Filtering: Use the search bar or filter dropdowns on the Bookings page to view events by Type, Date range, or Name.


Continuous Integration & GitHub

Cloud Deployment: The application is architected for the Azure PaaS ecosystem. Using the Visual Studio "Publish" wizard, the project is configured to deploy to an Azure App Service, utilizing Azure SQL Database for persistent storage and Azure Blob Storage for media assets.

Demonstration: You can view the application in action here:

YouTube Link: https://youtu.be/h1alEdT6kdI?si=VOKDpsA-U6rhWnMr
