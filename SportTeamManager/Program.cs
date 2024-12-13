// See https://aka.ms/new-console-template for more information

using System.ComponentModel.Design;
using System.Runtime.InteropServices.JavaScript;

public class Player
{
    public string Name { get; set; }
    public string Position { get; set; }
    public int Score { get; set; }


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

        else if(addPosition == "")
        {
            Console.WriteLine("Nie podano pozycji zawodnika. Proszę podać pozycje: ");
            addPosition = Console.ReadLine();
            AddPlayer(addName, addPosition, tryAddScore);

        }

        else if(canYouAdd == false)
        {
            Console.WriteLine("Podano nieprawidłowy wynik. Podaj wynik ponownie");
            tryAddScore = Console.ReadLine();
            AddPlayer(addName, addPosition, tryAddScore);
        }

        else
        {
            playersList.Add(new Player(addName, addPosition, addScore));
        }
        
        
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