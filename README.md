Amaris Test

This software was developed to carry out the technical test proposed by Amaris Consulting, where the goal is to generate an employee query and calculate their annual salary. All of this was developed in an MVC architecture designed with Angular and the .NET framework.

Contents
Prerequisites
Installation
Usage
Contribution
License
Contact

Prerequisites
Operating System: Ensure you have an operating system compatible with the development and execution of .NET and Angular applications, such as Windows, macOS, or Linux.

.NET 6 SDK: You must install the .NET 6.0 SDK on your system. You can download it from the official .NET website: [https://dotnet.microsoft.com/download/dotnet/6.0](https://dotnet.microsoft.com/download/dotnet/6.0)

Node.js and npm: Angular requires Node.js and npm (Node Package Manager) for installing packages and project dependencies. You can download Node.js from its official website: [https://nodejs.org/](https://nodejs.org/)

Angular CLI: Once you have Node.js and npm installed, you can globally install Angular CLI with the following command:

npm install -g @angular/cli

Code Editor: Choose a suitable code editor or IDE to work with the project's code. Microsoft Visual Studio 2022 is highly recommended.

Git: It is advisable to have Git installed to manage version control of your project and facilitate collaborative work. You can download Git from its official website: [https://git-scm.com/](https://git-scm.com/)

Once you have met the prerequisites, you will be ready to install and run the project developed with .NET 6.0 and Angular.

Installation
Clone the repository to your local machine using the following command:

git clone <repository URL>

Make sure you have the following tools installed:

- .NET SDK 6.0
- Node.js (including npm)
- Angular CLI (install it globally)

Navigate to the project directory in the terminal:

cd project-name

Restore NuGet packages for the .NET backend:

dotnet restore

Install Node.js dependencies for the Angular frontend:

cd ClientApp
npm install

Run the Application
To run the application, follow these steps:

Make sure you are in the root directory of the project:

cd Amaris

Run the .NET project:

- Open the Amaris.sln project.
- Run `dotnet run`.

Considerations
Ensure you have the appropriate versions of .NET SDK and Angular CLI installed on your machine.
If you encounter any issues while running the application, verify that dependencies are correctly installed and that there are no conflicts with package or library versions.
If you need assistance or have any questions, feel free to open an issue in the repository or contact the developer.

Usage
After having the project running, you can use the graphical interface to help with data querying. You can filter an employee by their ID or search for all available information at the moment. Remember that the ID search is optional, so the field is not required. If the input is left empty, all information will be retrieved.
Keep in mind that the server where the information is hosted may have deficiencies in the search and filtering of data. To mitigate potential errors, caching of information is implemented to improve the project's performance.

License
This software is licensed under the MIT License.

Contact
LinkedIn: [https://www.linkedin.com/in/johan-sebasti%C3%A1n-pati%C3%B1o-grajales-aa95b0148/](https://www.linkedin.com/in/johan-sebasti%C3%A1n-pati%C3%B1o-grajales-aa95b0148/)
