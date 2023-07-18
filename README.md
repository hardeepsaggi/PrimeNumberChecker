# Prime Number Verification

A gRPC-based dotNet application for verifying prime numbers and tracking statistics.

## Table of Contents

- [Project Description](#project-description)
- [Features](#features)
- [Installation](#installation)
- [Usage](#usage)
- [Configuration](#configuration)
- [Build](#build)
- [Contributing](#contributing).

## Project Description

The Prime Number Verification application consists of a gRPC server and a client that work together to verify prime numbers and track statistics. The server receives requests with a random number between 1 and 1000 from the client. It determines whether the number is prime or not and sends a response accordingly, including the Round Trip Time (RTT) for each request. The client sends a consistent rate of 10,000 requests per second and verifies that all responses are received. Any missing response triggers appropriate actions. On the server side, all requested valid prime numbers are tracked, and the top 10 highest requested/validated prime numbers are displayed every second. The server also keeps track of the total number of messages received.

![Sequence Diagram](https://github.com/hsaggi/PrimeNumberChecker/assets/5955969/52a23612-56b4-4ee6-a451-5d1c578b4ae9) 

## Features

- Verification of prime numbers on the server side.
- Consistent rate of 10,000 requests per second from the client.
- Response verification and appropriate action handling on the client side.
- Display of Round Trip Time (RTT) for each sent message on the client side.
- Tracking of requested valid prime numbers on the server side.
- Display the top 10 highest requested/validated prime numbers every second.
- Display the total number of messages received on the server side.

## Installation
Instructions on how to install and set up the project.

### Prerequisites:

Before running the client and server applications, make sure you have the following prerequisites installed:

#### For the Client Application:

- .NET 6.0 SDK or runtime
- Google.Protobuf package (version 3.23.4)
- Grpc.Net.Client package (version 2.55.0)
- Grpc.Tools package (version 2.56.0)
- System.Configuration.ConfigurationManager package (version 7.0.0)

#### For the Server Application:
- .NET 6.0 SDK or runtime
- Grpc.AspNetCore package (version 2.40.0)
  
Make sure to have the correct versions of the packages installed. You can use the dot-net --version command to check your .NET SDK version.
Additionally, ensure that you have a compatible development environment such as Visual Studio to build and run the applications.
Once you have the prerequisites installed, you can proceed with building and running the client and server applications.

### Visual Studio

1. Open Visual Studio.
2. Clone the repository or download the source code.
3. Open the project solution file (.sln) in Visual Studio.
4. Build the solution to restore dependencies and compile the project.
5. Set Multiple startup projects (AppClient and AppService) as the startup projects.
![image](https://github.com/hsaggi/PrimeNumberChecker/assets/5955969/445b14d2-c546-4f4a-85a2-ffc039a08de8)
6. Configure client App.config settings.
7. Run the project using the debug mode or by pressing F5.


## Usage

1. Set the appropriate configuration settings for the server and client.
2. Run the server application to start the server.
3. Run the client application to send requests to the server.
4. Monitor the console outputs of the server and client for verification results and statistics.

## Configuration

The Calculation Client can be configured using the application configuration file (app.config). The following settings are available:

- `CalculationServiceUrl`: The URL of the calculation service. Set this to the appropriate service endpoint.
- `IsCacheEnabled`: A boolean value indicating whether caching of prime numbers is enabled. Set to `true` or `false`.
- `RequestPerSecond`: The number of requests per second to send to the server. Adjust this value as needed.

## Build

Status:![Build Status](https://github.com/hsaggi/PrimeNumberChecker/actions/workflows/dotnet.yml/badge.svg)
1. Ensure that the prerequisites are met.
2. Open a terminal or command prompt in the project's root directory.
3. To build the project use   `dotnet build`.
4. Once the build is successful, run the project using  `dotnet run`.
5. The application will start, and you can access the gRPC service using the specified endpoint.

Not all projects need to be built for a working binary to be produced. Only the AppClient and AppService projects are required to be built. Test projects in PrimeNumberChecker.Tests/., is optional and can be unloaded safely from the solution.

## Contributing
Contributions to the project are welcome. To contribute, please follow these steps:

1. Fork the repository.
2. Create a new branch for your feature or bug fix.
3. Make the necessary changes and commit them.
4. Push your branch to your forked repository.
5. Submit a pull request to the main repository.
6. Ensure that your code follows the coding conventions and style guidelines.
