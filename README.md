# Azure AI Agent Teams

A C# .NET application for running AI agents built in the Azure AI Foundry playground.

## Project Overview

This project provides a simple development environment to run and test AI models and agents that were created in the Azure AI Foundry platform. It includes sample code that demonstrates how to interact with your deployed models and agents using the Azure OpenAI SDK.

**Key Features:**
- Run AI models locally using Azure OpenAI SDK
- Built with .NET 10.0 (also supports .NET 9.0)
- Integrated with Azure AI Foundry for model deployment
- Simple command-line interface for testing

## Prerequisites

Before running this application, ensure you have:
- **.NET SDK**: [Install .NET 10.0](https://dotnet.microsoft.com/download) or .NET 9.0
- **Azure Account**: Access to Azure AI Foundry with a deployed model/agent
- **.env file**: Your Azure credentials (see [Continuing on your local desktop](#continuing-on-your-local-desktop) section)

## Project Structure

```
Azure-AI-Agent-Teams/
├── example.csproj          # Project configuration
├── model.cs                # Core model/agent code
├── run_model.cs            # Entry point for running the model
├── instructions.md         # Setup instructions
├── README.md               # This file
└── .env                    # Environment variables (Azure credentials)
```

## Getting Started

### 1. Open the Terminal

Press ``Ctrl-` `` to open a terminal window in VS Code.

### 2. Run the Application

Execute the following command to run your deployed model:

```bash
dotnet run model.cs
```

This will execute your AI model and display the output in the terminal.

### 3. View Output

The results from your model will be printed directly to the terminal window.

## Configuration

The application uses the following NuGet packages:
- **Azure.AI.OpenAI** (v2.1.0): For interacting with Azure OpenAI models
- **Azure.Core** (v1.50.0): Core Azure SDK functionality

### Environment Variables

Your `.env` file should contain the following variables:

```dotenv
AZURE_ENV_NAME
AZURE_LOCATION
AZURE_SUBSCRIPTION_ID
AZURE_EXISTING_AIPROJECT_ENDPOINT
AZURE_EXISTING_AIPROJECT_RESOURCE_ID
AZD_ALLOW_NON_EMPTY_FOLDER
AZURE_OPENAI_KEY="your-api-key-here"
```

**Variable Descriptions:**
- `AZURE_ENV_NAME`: Name of your Azure AI environment
- `AZURE_LOCATION`: Azure region where your resources are deployed (e.g., eastus2)
- `AZURE_SUBSCRIPTION_ID`: Your Azure subscription ID
- `AZURE_EXISTING_AIPROJECT_ENDPOINT`: The endpoint URL for your Azure Cognitive Services resource
- `AZURE_EXISTING_AIPROJECT_RESOURCE_ID`: Full resource ID for your AI project
- `AZD_ALLOW_NON_EMPTY_FOLDER`: Allows Azure Developer CLI to work with non-empty folders
- `AZURE_OPENAI_KEY`: Your Azure OpenAI API key for authentication

## Continuing on Your Local Desktop

To continue development on your local machine:

1. **Download the .env file**:
   - Right-click the `.env` file in VS Code
   - Select "Download"
   - Move the file from your Downloads folder to your local git repo directory
   - For Windows, rename the file back to `.env` if needed

2. **Clone or sync the repository** to your local machine

3. **Run locally**:
   ```bash
   dotnet run run_model.cs
   ```

## Building the Project

To build the project without running:

```bash
dotnet build
```

To build for a specific framework:

```bash
dotnet build -f net10.0
```

## Additional Resources

- [Azure AI Foundry Documentation](https://learn.microsoft.com/en-us/azure/ai-studio/)
- [Azure OpenAI SDK for .NET](https://learn.microsoft.com/en-us/dotnet/api/overview/azure/openai-readme?view=azure-dotnet)
- [.NET Documentation](https://learn.microsoft.com/en-us/dotnet/)

## License

See [LICENSE](LICENSE) file for details.
