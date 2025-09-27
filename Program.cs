using ContactManager;

namespace ContactManager;

public class Program
{
    static void Main(string[] args)
    {
        IContactManager manager = new ContactManager();

        string filePath = "contacts.json";

        manager.LoadFromFile(filePath);

        string userInput;

        Console.WriteLine("=== Witaj w aplikacji do zarządzania kontaktami ===");

        do
        {
            Console.WriteLine("\nWybierz jedną z opcji");
            Console.WriteLine("1. Dodaj nowy kontakt");
            Console.WriteLine("2. Wyświetl wszystkie kontakty");
            Console.WriteLine("3. Wyszukaj kontakt po imieniu");
            Console.WriteLine("4. Zapisz kontakty do pliku.");
            Console.WriteLine("5. Wczytaj kontakty z pliku.");
            Console.WriteLine("6. Wyjdź z aplikacji" );

            userInput = Console.ReadLine();

            switch (userInput)
            {   
                case "1":
                    manager.AddContact();
                    break;
                case "2":
                    manager.DisplayContacts();
                    break;
                case "3":
                    manager.SearchContacts();
                    break;
                case "4":
                    manager.SaveToFile(filePath);
                    break;
                case "5":
                    manager.LoadFromFile(filePath);
                    break;
                case "6":
                    //manager.SaveToFile(filePath);
                    Console.WriteLine("Dziękujemy za skorzystanie z aplikacji. Do widzenia!!!");
                    break;
                default:
                    Console.WriteLine("Niepoprawny wybór. Spróbuj ponownie...");
                    break;
            }

        } while (userInput!= "4");
    }

}
