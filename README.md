# Loan Broker

A middleware to provide users with loans from different banks. Written in C# and .NET Core WebAPI

## Prerequisites

Ensure you have the following installed before running the application:

- [.NET SDK v8.0](https://dotnet.microsoft.com/download) (ensure the correct version is installed)
- Git

## Getting Started

### Using Docker (Recommended)

#### 1. Get the docker image file

Download the loanbroker.tar from the latest release in the Releases.

#### 2. Load the docker image

Go to the loanbroker.tar directory and run the following command:

```bash
docker load -i loanbroker.tar
```

#### 3. Verify the image

Once loaded, verify the image by running this:

```bash
docker images
```

You should see a loan_broker image.

#### 4. Run a container

Use the following command to create and run a container from the image:

```bash
docker run -d -p <some_port_number>:80 --name loanbroker loan_broker
```

### Using command line

#### 1. Clone the Repository

Use the following command to clone the repository:

```bash
git clone https://github.com/MEHRDADsmj/LoanBroker.git
```

Navigate to the project directory:

```bash
cd LoanBroker
```

#### 2. Restore Dependencies

Restore the NuGet packages (dependencies) required for the project by running:

```bash
dotnet restore
```

#### 3. Build the Project

Once dependencies are restored, build the project using:

```bash
dotnet build
```

#### 4. Run the Application

To start the application, run:

```bash
dotnet run -lp <desired_launch_profile>
```

### Testing the API

You can use tools like [Postman](https://www.postman.com/) to test the API.

## Contributing

Feel free to submit issues or pull requests if you'd like to contribute.
