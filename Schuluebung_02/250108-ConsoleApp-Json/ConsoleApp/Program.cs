using System.Net.Http.Json;
using System.Text.Json;


using HttpClient client = new()
{
    BaseAddress = new Uri("https://jsonplaceholder.typicode.com")
};

var options = new JsonSerializerOptions
{
    PropertyNameCaseInsensitive = true
};


// Get the user information.
Rootobject? user = await client.GetFromJsonAsync<Rootobject>("users/1", options);
Console.WriteLine($"Id: {user?.Id}");
Console.WriteLine($"Name: {user?.Name}");
Console.WriteLine($"Username: {user?.Username}");
Console.WriteLine($"Email: {user?.email}");
Console.WriteLine($"Street: {user?.address?.street}");
Console.WriteLine($"Suite: {user?.address?.suite}");
Console.WriteLine($"City: {user?.address?.city}");
Console.WriteLine($"Zipcode: {user?.address?.zipcode}");
Console.WriteLine($"Lat: {user?.address?.geo?.lat}");
Console.WriteLine($"Lng: {user?.address?.geo?.lng}");
Console.WriteLine($"Phone: {user?.phone}");
Console.WriteLine($"Website: {user?.website}");
Console.WriteLine($"Company Name: {user?.company?.name}");
Console.WriteLine($"Company CatchPhrase: {user?.company?.catchPhrase}");
Console.WriteLine($"Company BS: {user?.company?.bs}");


// Post a new user.
HttpResponseMessage response = await client.PostAsJsonAsync("users", user);
Console.WriteLine(
    $"{(response.IsSuccessStatusCode ? "Success" : "Error")} - {response.StatusCode}");

public class User {
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Username { get; set; }
    public string? Email { get; set; }
}

// Produces output like the following example but with different names:
//
//Id: 1
//Name: Tyler King
//Username: Tyler
//Email: Tyler@contoso.com
//Success - Created