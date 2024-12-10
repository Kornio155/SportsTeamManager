// See https://aka.ms/new-console-template for more information

using System.ComponentModel.Design;
using System.Runtime.InteropServices.JavaScript;

public class Player
{
    private string Name { get; set; }
    private string Position { get; set; }
    private int Score { get; set; }


    public Player(string name, string position, int score)
    {
        Name = name;
        Position = position;
        Score = score;
    }

    public void UpdateScore()
    {
        
    }

    public void ChangePosition()
    {
        
    }

    static public void FindPlayerByPosition()
    {
        // po wprowadzeniu pozycji system wyświetla wszystkich zawodników grających na tej pozycji
        // jeśli nie ma zawodników na danej pozycji to pokazuje komunikat: "Brak zawodników na tej pozycji"
    }

}

public class Team
{
    private static List<Player> playersList = new List<Player>();


    public static void AddPlayer(string addName, string addPosition, string tryAddScore)
    {

        
        bool canYouAdd = int.TryParse(tryAddScore, out int addScore);
        
        if (addName == "")
        {
            Console.WriteLine("Nie podano imienia zawodnika. Proszę podać imie zawodnika: ");
            addName = Console.ReadLine();
            AddPlayer(addName, addPosition, tryAddScore);

        }

        if (addPosition == "")
        {
            Console.WriteLine("Nie podano pozycji zawodnika. Proszę podać pozycje: ");
            addPosition = Console.ReadLine();
            AddPlayer(addName, addPosition, tryAddScore);

        }

        if (canYouAdd == false)
        {
            Console.WriteLine("Podano nieprawidłowy wynik. Podaj wynik ponownie");
            tryAddScore = Console.ReadLine();
            AddPlayer(addName, addPosition, tryAddScore);
        }

        playersList.Add(new Player(addName, addPosition, addScore));
        Console.WriteLine(playersList);
        
        // tworzy nowego zawodnika i dodaje go. Podaje imie, pozycje, początkowy wynik
        // pomysł: metoda AddPlayer wywołuje konstruktor klasy Player tworząc nowego zawodnika po czym dodaje go do listy playerList
        
        // metoda sprawdza czy wszystkie dane zostały wpisane podczas dodawania: 
        // jeśli nie to podaje co trzeba jeszcze podać i wyświetla do tego okno
        
        // program pyta się o pozycje jeśli nic nie zostanie wpisane ma ustawić domyślną pozycje: default position  reserve player
        
    }


    public static void DeletePlayer()
    {
        // usuwa zawodnika 
    }

    public static void ShowStatistics()
    {
        
    }

    public static void AveragePoints()
    {
        
    }



}





internal class Program
{
    public static void Main(string[] args)
    {
        
        /*
         *
         *  funkcja filtrowania zawodników po: punktach, pozycji, po drużynie?, może coś więcej
         *
         *
         *
         *
         *
         * 
         */
        
        Console.WriteLine("To program do zarządzania drużyną.");
        Console.WriteLine("Wprowadź operacje jaką chcesz dokonąć: TAP, TDP, TSS, TAPs, end");
        string option = Console.ReadLine();
        while (true)
        {

            if (option == "end" || option == "")
            {
                break;
            }

            switch (option)
            {
                case "TAP":
                    Console.WriteLine("Proszę podać imie zawodnika");
                    string addName = Console.ReadLine();
                    
                    Console.WriteLine("Proszę podać pozycje zawodnika");
                    string addPosition = Console.ReadLine();
                    
                    Console.WriteLine("Proszę podać wynik zawodnika");
                    string tryAddScore = Console.ReadLine();
                    Team.AddPlayer(addName, addPosition, tryAddScore);
                    break;
            }

            Console.WriteLine("Wprowadź operacje jaką chcesz dokonąć: TAP, TDP, TSS, TAPs, end");
            option = Console.ReadLine();
            
            
        }
        
        
    }
}