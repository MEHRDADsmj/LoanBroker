FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

COPY *.sln ./
COPY IBankProvider/IBankProvider.csproj ./IBankProvider/
COPY IBankProviderFactory/IBankProviderFactory.csproj ./IBankProviderFactory/
COPY BankProviderFactory/BankProviderFactory.csproj ./BankProviderFactory/
COPY BankAProvider/BankAProvider.csproj ./BankAProvider/
COPY BankBProvider/BankBProvider.csproj ./BankBProvider/
COPY BankCProvider/BankCProvider.csproj ./BankCProvider/
COPY LoanBroker/LoanBroker.csproj ./LoanBroker/

RUN dotnet restore LoanBroker/LoanBroker.csproj

COPY . ./

WORKDIR ./LoanBroker/
RUN dotnet publish -c Release -o out

From mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
EXPOSE 80
ENV DOTNET_URLS=http://+:80
WORKDIR /app
COPY --from=build-env /app/LoanBroker/out .
ENTRYPOINT [ "dotnet", "LoanBroker.dll" ]