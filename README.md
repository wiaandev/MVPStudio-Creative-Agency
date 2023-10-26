

# MVP Studio - Creative Agency Management App
<p align="center">
<img height="130" width="130" src="https://github.com/wiaandev/MVPStudio-Creative-Agency/blob/main/Resources/Images/mvp_logo.png"></img>
</p>

## Introduction

MVP Studio is a versatile cross-platform application built using .NET MAUI for managing various aspects of a creative agency consisting of developers and designers, handling clients, projects, staff, or finances. It also utilizes a PostgreSQL database hosted on Aiven for data storage.

## Features

- **Client Management:** Easily add, edit, and manage client information.
- **Project Tracking:** Track and manage project details, status, and deadlines.
- **Staff Management:** Keep a record of staff members, their roles, and contact information.
- **Financial Insights:** Monitor and manage agency finances, including income and expenses.
- **Cross-Platform:** Runs on iOS and Windows with .NET MAUI.

## Installation

Follow these steps to run the MVP Studio application:

### Prerequisites

- **Visual Studio:** Ensure you have Visual Studio or Visual Studio for Mac installed.
- **.NET MAUI:** MVP Studio is built using .NET MAUI, so make sure you have the necessary MAUI workload installed in Visual Studio.
- **Aiven Account:** You will need an Aiven account to host the PostgreSQL database. [Sign up for Aiven](https://aiven.io/) if you don't have an account.
-  Clone the MVP Studio database repository from GitHub: [https://github.com/wiaandev/ASPNET-PostgreSQL-API-MVPStudio](https://github.com/wiaandev/ASPNET-PostgreSQL-API-MVPStudio). Remember to run both repositories!

### Configure the Application

1. **Clone the Repository:**
   - Clone the MVP Studio repository from GitHub: [https://github.com/wiaandev/MVPStudio-Creative-Agency](https://github.com/wiaandev/MVPStudio-Creative-Agency).

2. **Set Connection String:**
   - Open the MVP Studio solution in Visual Studio.
   - Locate the database connection string in the code.
   - Update the connection string with your Aiven database details.

### Build and Run

1. **Build the Solution:**
   - Build the MVP Studio solution in Visual Studio.

2. **Select Target Platform:**
   - Choose the target platform (Android, iOS, or Windows) for debugging.

3. **Start Debugging:**
   - Press the "Run" or "Debug" button in Visual Studio to start the application on your selected platform.

## Usage

MVP Studio offers a easy to use interface for managing clients, projects, staff, and finances. Here are some common tasks:

- **Client Management:**
  - Add new clients with relevant contact information.
  - View a list of all clients and their associated projects.

- **Project Tracking:**
  - Create new projects, specifying client details, deadlines, and staff members.
  - Track project status and update progress.

- **Staff Management:**
  - Maintain a list of staff members, their roles, and action details.
  - Delete, update or add new staff members as the company grows.
  

- **Financial Insights:**
  - Keep an eye on your agency's finances.
  - Record income and expenses to monitor your revenue, salaries to be paid and profit.

## Contributing

Contributions to MVP Studio are welcome! Feel free to open issues or submit pull requests if you have any improvements or bug fixes to suggest.

## License

MVP Studio is licensed under the [MIT License](LICENSE).

## Developers

 [Shanré Scheepers](https://github.com/shanrescheepers).
 [Wiaan Duvenhage](https://github.com/wiaandev).
 [Liam Wedge](https://github.com/NoSleepTillLambos).

## Acknowledgments

- Thanks to [.net documentation](https://learn.microsoft.com/en-us/dotnet/maui/)
