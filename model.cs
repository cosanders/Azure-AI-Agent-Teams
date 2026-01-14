// Install the .NET library via NuGet: dotnet add package Azure.AI.OpenAI --prerelease
using Azure;
using Azure.AI.OpenAI;
using OpenAI.Chat;

using static System.Environment;
using System.Text.Json;

async Task RunAsync()
{
  // Retrieve the OpenAI endpoint from environment variables
  var endpoint = GetEnvironmentVariable("AZURE_OPENAI_ENDPOINT") ?? "https://colburnsanders2360-resource.cognitiveservices.azure.com/";
  if (string.IsNullOrEmpty(endpoint))
  {
      Console.WriteLine("Please set the AZURE_OPENAI_ENDPOINT environment variable.");
      return;
  }

  var key = GetEnvironmentVariable("AZURE_OPENAI_KEY");
  if (string.IsNullOrEmpty(key))
  {
      Console.WriteLine("Please set the AZURE_OPENAI_KEY environment variable.");
      return;
  }

    AzureKeyCredential credential = new AzureKeyCredential(key);

    // Initialize the AzureOpenAIClient
    AzureOpenAIClient azureClient = new(new Uri(endpoint), credential);

    // Initialize the ChatClient with the specified deployment name
    ChatClient chatClient = azureClient.GetChatClient("gpt-5-chat");
    
    // List of messages to send
    var messages = new List<ChatMessage>
    {
        new SystemChatMessage(@"You are an AI assistant that helps people find information."),
              new UserChatMessage(@"I am going to Paris, what should I see?"),
              new AssistantChatMessage(@"Paris, the capital of France, is known for its stunning architecture, art museums, historical landmarks, and romantic atmosphere. Here are some of the top attractions to see in Paris:

1. The Eiffel Tower: The iconic Eiffel Tower is one of the most recognizable landmarks in the world and offers breathtaking views of the city.
2. The Louvre Museum: The Louvre is one of the world's largest and most famous museums, housing an impressive collection of art and artifacts, including the Mona Lisa.
3. Notre-Dame Cathedral: This beautiful cathedral is one of the most famous landmarks in Paris and is known for its Gothic architecture and stunning stained glass windows.

These are just a few of the many attractions that Paris has to offer. With so much to see and do, it's no wonder that Paris is one of the most popular tourist destinations in the world."),
              new UserChatMessage(@"What is so great about #1?"),
    };


    // Create chat completion options

    var options = new ChatCompletionOptions();
        
      // <!-- NOTE: this section only needs to be included if max tokens are configured -->
      // Setting MaxOutputTokenCount requires a temporary workaround using 2.2.0-beta.1
      // See related:
      // https://github.com/Azure/azure-sdk-for-net/pull/48218#issuecomment-2652005055
      //
        options
          .GetType()
          .GetProperty(
              "SerializedAdditionalRawData",
              System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)!
          .SetValue(options, new System.Collections.Generic.Dictionary<string, BinaryData>());
          options.MaxOutputTokenCount = 800;
        //   options.SetNewMaxCompletionTokensPropertyEnabled();
      

    try
    {
        // Create the chat completion request
        ChatCompletion completion = await chatClient.CompleteChatAsync(messages, options);

        // Print the response
        if (completion != null)
        {
            Console.WriteLine(JsonSerializer.Serialize(completion, new JsonSerializerOptions() { WriteIndented = true }));
        }
        else
        {
            Console.WriteLine("No response received.");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"An error occurred: {ex.Message}");
    }
}

await RunAsync();