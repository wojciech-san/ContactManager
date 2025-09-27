using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;


namespace ContactManager
{
    public class ContactManager : IContactManager
    {
        List<Contact> contacts = new List<Contact>();

        public ContactManager()
        {
            Contact c1 = new Contact("Anna","Cz","a@gmail.com","123");
            contacts.Add(c1);
        }

        public void AddContact()
    {
        Console.WriteLine("\n=== Dodaj nowy kontakt ===");
        Console.WriteLine("Podaj Imię: ");
        string firstName = Console.ReadLine();
        Console.WriteLine("Podaj Mazwisko: ");
        string lastName = Console.ReadLine();
        Console.WriteLine("Podaj Email: ");
        string email = Console.ReadLine();
        Console.WriteLine("Podaj Telefon: ");
        string phoneNumber = Console.ReadLine();

        Contact contact = new Contact(firstName,lastName,email,phoneNumber);

        contacts.Add(contact);

        Console.WriteLine("Kontakt został dodany!");

    }

    public  void DisplayContacts()
    {
        Console.WriteLine("\n=== Lista kontaktów ===");

        if (contacts.Count == 0)
        {
            Console.WriteLine("Brak kontaków do wyświetlenia");
        }
        else
        {
            foreach (var contact in contacts)
            {
                Console.WriteLine(contact);
            }
        }
    }

    public  void SearchContacts()
    {
        Console.WriteLine("\n=== Wyszukaj kontakt ===");
        Console.WriteLine("Podaj Imię do wyszukania");
        string searchName = Console.ReadLine();
        //var foundContacts = contacts.Where(c=>c.FirstName ==searchName).ToList();
        var foundContacts = contacts.FindAll(c=>c.FirstName.Equals(searchName, StringComparison.OrdinalIgnoreCase)).ToList();

        if (foundContacts.Count>0)
        {
            Console.WriteLine($"Znaleziono {foundContacts.Count} kontakt(ów)");
        
            foreach (var contact in foundContacts)
            {
                Console.WriteLine(contact);    
            }
        }
        else
        {
            Console.WriteLine("Brak kontaktów do wyświetlenia.");
        }

    }

    public void SaveToFile(string filePath)
    {
        try
        {
            var json = JsonSerializer.Serialize(contacts, new JsonSerializerOptions{WriteIndented = true});
            File.WriteAllText(filePath,json);
            Console.WriteLine($"Kontakty zostały zapisane do pliku: {filePath}");

        }
        catch (Exception ex)
        {
            
            Console.WriteLine($"Błąd podczas zapisywania do pliku");
        }
    }

    public void  LoadFromFile(string filePath)
    {
        try
        {
            if (File.Exists(filePath))
            {
                var json = File.ReadAllText(filePath);
                contacts = JsonSerializer.Deserialize<List<Contact>>(json) ?? new List<Contact>();
                Console.WriteLine($"Kontakty zostały wczytane z pliku {filePath}"); 
            }
            else
            {
                Console.WriteLine($"Plik o ściezce {filePath} nie istnieje.");
            }
        }
        catch (Exception ex)
        {
            
            Console.WriteLine($"Błąd podczas wczytywania pliku: {ex.Message}");
        }
    }




    
}
}