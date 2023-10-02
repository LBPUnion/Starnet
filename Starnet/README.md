# Starnet

Starnet is a .NET library for interacting with ProjectLighthouse instance APIs.

## Library Contents

* `LighthouseClient` class containing asynchronous methods for interacting with a ProjectLighthouse instance's API.
* Public types (entities and enums) which can be used to write your own code for interacting with an instance's API
  without needing to model your own types.
* Public exceptions which can be thrown by the library or external code.

## Example

```csharp
using LBPUnion.Starnet;
using LBPUnion.Starnet.Types.Entities.Users;

namespace Example;

public static class Program
{
    // Both of the constructor parameters are optional.
    // Defaults to no API key and https://lighthouse.lbpunion.com.
    private static readonly LighthouseClient client = new("$2a$11$...", "https://lighthouse.example.com");
    
    public static async Task Main(string[] args)
    {
        UserEntity? user = await client.GetUserAsync("username");
        if (user == null)
        {
            Console.WriteLine("User not found.");
            return;
        }
        
        Console.WriteLine($"User ID: {user.UserId}");
        Console.WriteLine($"Username: {user.Username}");
    }
}
```