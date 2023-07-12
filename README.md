# Prime Number Verification

A gRPC-based dotNet application for verifying prime numbers and tracking statistics.

## Table of Contents

- [Project Description](#project-description)
- [Features](#features)
- [Installation](#installation)
- [Usage](#usage)
- [Configuration](#configuration)
- [Contributing](#contributing)
- [License](#license)

## Project Description

The Prime Number Verification application consists of a gRPC server and client that work together to verify prime numbers and track statistics. The server receives requests with a random number between 1 and 1000 from the client. It determines whether the number is prime or not and sends a response accordingly, including the Round Trip Time (RTT) for each request. The client sends a consistent rate of 10,000 requests per second and verifies that all responses are received. Any missing response triggers appropriate actions. On the server side, all requested valid prime numbers are tracked, and the top 10 highest requested/validated prime numbers are displayed every second. The server also keeps track of the total number of messages received.

## Features

- Verification of prime numbers on the server side.
- Consistent rate of 10,000 requests per second from the client.
- Response verification and appropriate action handling on the client side.
- Display of Round Trip Time (RTT) for each sent message on the client side.
- Tracking of requested valid prime numbers on the server side.
- Display of the top 10 highest requested/validated prime numbers every second.
- Display of the total number of messages received on the server side.

## Installation
Instructions on how to install and set up the project.

### Visual Studio

1. Open Visual Studio.
2. Clone the repository or download the source code.
3. Open the project solution file (.sln) in Visual Studio.
4. Build the solution to restore dependencies and compile the project.
5. Set the both projects as the startup project.
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

## Contributing

Contributions to the project are welcome. To contribute, please follow these steps:

1. Fork the repository.
2. Create a new branch for your feature or bug fix.
3. Make the necessary changes and commit them.
4. Push your branch to your forked repository.
5. Submit a pull request to the main repository.
6. Ensure that your code follows the coding conventions and style guidelines.

## License

This project is licensed under the [MIT License](LICENSE).