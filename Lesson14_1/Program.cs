using System.Text.Json;

namespace Lesson14_1
{
    internal class Program
    {
        class User
        {
            public int Id { get; set; }
            
            public string Name { get; set; }

            public string Email { get; set; }

            public Address Address { get; set; }

            public string Phone { get; set; }

            public string Websity { get; set; }

            public Company Company { get; set; }
        }

        class Address
        {
            public string Street { get; set; }

            public string Suite { get; set; }
            
            public string City { get; set; }

            public string Zipcode { get; set; }

            public struct Geo
            {
                decimal Lat { get; set; }
                
                decimal Lng { get; set; }
            }
        }

        class Company
        {
            public string Name { get; set; }

            public string CatchPhrase { get; set; }

            public string Bs { get; set; }
        }

        static async Task Main()
        {
            HttpClient client = new HttpClient();
            var user = await client.GetAsync("https://jsonplaceholder.typicode.com/users");
            var content = await user.Content.ReadAsStringAsync();
            Console.WriteLine(content);

        }
    }
}
