// See https://aka.ms/new-console-template for more information

using System.ComponentModel.Design;
using System.Linq.Expressions;
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
    public static List<Player> playersList = new List<Player>();


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
            Console.WriteLine("Zawodnik został dodany do drużyny.");
        }
        
        
    }


    public static void DeletePlayer()
    {
        Console.WriteLine("Podaj imie zawodnika, którego chcesz usunąć: ");
        string nameInput = Console.ReadLine();
        playersList.RemoveAll(x => x.Name == nameInput); // funkcja zaproponowana przez rider: x przyjmuje element listy po czym funkcja RemoveAll usuwa element gdzie imie zawodnika jest takie samo jak imie podane przez użytkownika
        Console.WriteLine("Usunięto zawodnika!");
    }

    public static void ShowStatistics()
    {
        int teamPoints = playersList.Aggregate(0,(acc, Score) => acc + Score.Score);
        Console.WriteLine($"Wszystkie punkty zdobyte przez drużynę: {teamPoints}");
        int bestScorePlayer = playersList.Max(acc => acc.Score);
        Console.WriteLine($"Najlepiej punkutjący zawodnik: {bestScorePlayer}");
        int worstScorePlayer = playersList.Min(acc => acc.Score);
        Console.WriteLine($"Najgorzej punktujący zawodnik: {worstScorePlayer}");
    }

    public static void AveragePoints()
    {
        int teamPoints = playersList.Aggregate(0,(acc, Score) => acc + Score.Score);
        int averageTeamPointsPoints = teamPoints / playersList.Count;
        Console.WriteLine($"Średnie punkty na zawodnika: {averageTeamPointsPoints}");
        
    }



}





internal class Program
{
    public static void Main(string[] args)
    {
        
        /*
         *  funkcja filtrowania zawodników po: punktach, pozycji, po drużynie?, może coś więcej
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
                
                case "TDP":
                    Team.DeletePlayer();
                    break;
                
                case "TSS":
                    Team.ShowStatistics();
                    break;
                case "TAPs":
                    Team.AveragePoints();
                    break;
            }
            
            
            Console.WriteLine("Wprowadź operacje jaką chcesz dokonąć: TAP, TDP, TSS, TAPs, end");
            option = Console.ReadLine();
            
            
            
            
        }
        
        
    }
}