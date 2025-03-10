# File System Logger

## Overview
The File System Logger is a simple application that logs the structure of a specified directory, including its subdirectories and files, into a text file.

## Usage
1. Clone the repository to your local machine.
2. Open a terminal and navigate to the project directory.
3. Build the project using your preferred method (e.g., using the .NET CLI).
4. Run the application with the following command:
   ```
   dotnet run <target_directory>
   ```
   If no directory is specified, it will log the current directory.

## Output
The application will create a log file named `FSL_log_<timestamp>.txt` in the specified directory, containing the directory structure and file details.

## Requirements
- .NET SDK installed on your machine.