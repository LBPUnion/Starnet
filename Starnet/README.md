# Starnet

Starnet is a .NET library for interacting with ProjectLighthouse instance APIs.

## Example

```csharp
using LBPUnion.Starnet;
using LBPUnion.Starnet.Types.Entities.Users;

namespace Example;

public static class Program
{
    // Both of the constructor parameters are optional.
    // Defaults to no API key and https://lighthouse.lbpunion.com.
    private static readonly LighthouseClient client = new("my-api-key", "https://lighthouse.example.com");
    
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