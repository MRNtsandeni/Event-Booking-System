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

## 1. Managing Venues 

The Venue module allows administrators to maintain the physical locations available for booking. 

Feature: Upload images directly to Azure Blob Storage and set capacity limits for each venue. 

Example: Navigate to Venues > Create, enter the Venue Name, Location, and Capacity. Click Save to add it to the live index. 

## 2. Event Scheduling 

Organize events and categorize them for easy filtering. 

Feature: Set specific date and time stamps for events and assign them to categories (e.g., Workshop, Conference). 

Example: In Events > Create, select your event type from the dropdown, choose your date/time, and create the event. The index page will display the formatted date and time for all upcoming events. 

## 3. Intelligent Booking Engine 

The core of the system is the booking interface, which prevents scheduling conflicts. 

Conflict Prevention: The system performs a real-time availability check. If you attempt to book a venue that is already occupied during your selected time, the system will block the request and provide a clear error message. 

Edit Validation: Unlike basic systems, our Edit logic correctly identifies and excludes the current record from conflict checks, allowing you to modify existing bookings without triggering false alarms. 

## 4. Navigation & Filtering 

Quickly find relevant information using the integrated search and filter tools. 

Filtering: Use the search bar or filter dropdowns on the Bookings page to view events by Type, Date range, or Name. 

## 5. Media support: 

With the use of azure blob storage users can upload and manage the 

images used for the venues and events. 

Continuous Integration & GitHub 

Cloud Deployment: The application is architected for the Azure PaaS ecosystem. Using the Visual Studio "Publish" wizard, the project is configured to deploy to an Azure App Service, utilizing Azure SQL Database for persistent storage and Azure Blob Storage for media assets. 

Demonstration: You can view the application in action here: 

YouTube Link: https://youtu.be/h1alEdT6kdI?si=VOKDpsA-U6rhWnMr 

The "Go Live" Migration/ Screenshots 

<img width="940" height="450" alt="image" src="https://github.com/userattachments/assets/74ca17a7-8e0e-4dc9-970c-10bf079cbf5f" /> 

<img width="940" height="448" alt="image" src="https://github.com/userattachments/assets/2d072d38-91bc-41cf-beaa-363112c0f453" /> 

<img width="940" height="257" alt="image" src="https://github.com/userattachments/assets/5e8debdd-2e2d-42b8-bdf4-408f89066995" /> 

Live Deployment and dropping of resources 

<img width="940" height="478" alt="image" src="https://github.com/userattachments/assets/5017368c-0abe-4fad-8658-26a29213a65a" /> 

<img width="940" height="476" alt="image" src="https://github.com/userattachments/assets/f223180f-0968-4756-ba5e-d6c068217fd4" /> 

<img width="940" height="316" alt="image" src="https://github.com/userattachments/assets/0de6813a-addb-4fcc-88c0-621624b02bc6" /> 

<img width="688" height="175" alt="image" src="https://github.com/userattachments/assets/5465d9aa-b518-4c0b-a189-9ea92f1b33be" /> 

<img width="940" height="417" alt="image" src="https://github.com/userattachments/assets/bca4d923-6c4e-40a8-b9c0-8fececc0a20e" /> 

<img width="940" height="422" alt="image" src="https://github.com/userattachments/assets/068420df-57fc-4824-8072-9026b091f2cf" /> 

