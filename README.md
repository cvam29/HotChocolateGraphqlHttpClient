# Azure Function for GraphQL Query Transport

## Overview

This is a sample Azure Function project designed to address timeout issues and problems encountered with the `GraphQlHttpClient`. The function extends the `HotChocolate` client to accept variables and queries, and transports GraphQL queries to our headless CMS system.

## Features

- **Timeout Issue Resolution**: This function is designed to handle and mitigate timeout issues that may occur during the execution of GraphQL queries.
- **Extended GraphQL Client**: We have extended the `HotChocolate` client to accept variables and queries, enhancing its capabilities.
- **GraphQL Query Transport**: This function is capable of transporting GraphQL queries to our headless CMS system, facilitating seamless data exchange and manipulation.

## Getting Started

1. **Clone the repository**: Clone this repository to your local machine to get started.

    ```bash
    git clone https://github.com/your-repo/azure-function-graphql.git
    ```

2. **Set up the environment**: Ensure that you have the Azure Function Core tools installed on your machine. You can install it using the following command:

    ```bash
    npm i -g azure-functions-core-tools@3 --unsafe-perm true
    ```

3. **Run the function locally**: Navigate to the project directory and start the function app.

    ```bash
    cd azure-function-graphql
    func start
    ```


