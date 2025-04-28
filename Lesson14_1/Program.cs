using System.Text.Json;
using System.Text.Json.Serialization;

namespace Lesson14_1
{
    internal class Program
    {
        class User
        {
            [JsonPropertyName("id")]
            public int Id { get; set; } = 0;

            [JsonPropertyName("name")]
            public string Name { get; set; } = "";

            [JsonPropertyName("email")]
            public string Email { get; set; } = "";

            [JsonPropertyName("address")]
            public Address Address { get; set; }

            [JsonPropertyName("phone")]
            public string Phone { get; set; } = "";

            [JsonPropertyName("websity")]
            public string Websity { get; set; } = "";

            [JsonPropertyName("company")]
            public Company Company { get; set; }

            public void WriteData()
            {
                Console.WriteLine($"Name: \t{Name}");
                Console.WriteLine($"Email: \t{Email}");
                Console.WriteLine($"Name: \t{Company.Name}");
            }

        }

        class Address
        {
            [JsonPropertyName("street")]
            public string Street { get; set; } = "";

            [JsonPropertyName("suite")]
            public string Suite { get; set; } = "";

            [JsonPropertyName("city")]
            public string City { get; set; } = "";

            [JsonPropertyName("zipcode")]
            public string Zipcode { get; set; } = "";

            [JsonPropertyName("geo")]
            public Geo Geo { get; set; }

        }
        class Geo
        {
            [JsonPropertyName("lat")]
            string Lat { get; set; } = "0";

            [JsonPropertyName("lng")]
            string Lng { get; set; } = "0";
        }

        class Company
        {
            [JsonPropertyName("name")]
            public string Name { get; set; } = "";

            [JsonPropertyName("catchPhrase")]
            public string CatchPhrase { get; set; } = "";

            [JsonPropertyName("bs")]
            public string Bs { get; set; } = "";
        }

        static async Task Main()
        {
            HttpClient client = new HttpClient();
            var user = await client.GetAsync("https://jsonplaceholder.typicode.com/users");
            var content = await user.Content.ReadAsStringAsync();

            List<User> users = JsonSerializer.Deserialize<List<User>>(content);

            foreach(var item in users)
            {
                Console.WriteLine("-----");
                item.WriteData();
                Console.WriteLine("-----");
            }
            Console.WriteLine("");

            User newUser = new User();
            newUser.Name = "Daniil Petrovich";
            newUser.Email = "dan10Pet@gmail.com";
            //newUser.Company.Name = "Google";

            var contentUser = JsonSerializer.Serialize<User>(newUser);
            var contentHttp = new StringContent(contentUser);
            var codePost = await client.PostAsync("https://jsonplaceholder.typicode.com/users", contentHttp);
            Console.WriteLine($"{codePost.StatusCode} || {(int)codePost.StatusCode}");
        }
    }
}
