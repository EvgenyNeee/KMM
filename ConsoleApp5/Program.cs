using System;
using System.Net;
using Newtonsoft.Json;
using System.Text;




public class Country
{
    public string Name { get; set; }
    public string Capital { get; set; }
    public string Region { get; set; }
}

public class Program
{
    static void Main(string[] args)
    {
        string d="yu";
        Console.OutputEncoding = Encoding.UTF8;
        for (;d!="0" ; )
        {
            Console.WriteLine("Введіть назву країни:");
            string countryName = Console.ReadLine();

            string apiUrl = $"https://restcountries.com/v2/name/{countryName}";

            using (WebClient client = new WebClient())
            {
                try
                {
                    string json = client.DownloadString(apiUrl);

                    Country[] countries = JsonConvert.DeserializeObject<Country[]>(json);
                    Country country = countries[0];

                    if (countries.Length > 0 && country.Name== countryName)
                    {
                        
                        Console.WriteLine($"Назва країни: {country.Name}");
                        Console.WriteLine($"Столиця: {country.Capital}");
                        Console.WriteLine($"Регіон: {country.Region}");
                    }
                    else
                    {
                        Console.WriteLine("Країна не знайдена.");
                    }
                }
                catch (WebException ex)
                {
                    Console.WriteLine("Помилка при отриманні даних з API:");
                    Console.WriteLine(ex.Message);
                }
            }
            Console.WriteLine("Натисніть 0 щоб зупинитись");
            d = Console.ReadLine();
        }
    }
}
