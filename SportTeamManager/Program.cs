// See https://aka.ms/new-console-template for more information

using System.ComponentModel.Design;
using System.Linq.Expressions;
using System.Runtime.InteropServices.JavaScript;
using System.Xml;

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

    public void UpdateScore(string inputScore)
    {
        bool tryParseScore = int.TryParse(inputScore, out int score);

        if (!tryParseScore)
        {
            Console.WriteLine("Podano nieprawidłowy wynik. Podaj wynik ponownie: ");
            inputScore = Console.ReadLine();
            UpdateScore(inputScore);
        }
        else
        {
            Score = score;
        }
        
    }

    public void ChangePosition(string inputPosition)
    {
        if (inputPosition == "")
        {
            Console.WriteLine("Podano pustą pozycję. Wprowadź pozycję ponownie: ");
            inputPosition =  Console.ReadLine();
            ChangePosition(inputPosition);
        }
        Position = inputPosition;
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
        
        Console.WriteLine("Zawodnicy drużyny");
        foreach (var player in playersList)
        {
            Console.WriteLine($"Imie: {player.Name}, Pozycja: {player.Position}, Wynik: {player.Score}");
        }
        
    }

    public static void AveragePoints()
    {
        int teamPoints = playersList.Aggregate(0,(acc, Score) => acc + Score.Score);
        int averageTeamPointsPoints = teamPoints / playersList.Count;
        Console.WriteLine($"Średnie punkty na zawodnika: {averageTeamPointsPoints}");
        
    }

    public static void FindPlayerByPosition(string inputPosition)
    {
        bool isPositionExists = Team.playersList.Any(player => player.Position == inputPosition);

        if (!isPositionExists)
        {
            Console.WriteLine($"Nikt nie gra na pozycji: {inputPosition}.");
        }

        else
        {
            var filteredPlayers = playersList.FindAll(player => player.Position == inputPosition);
            Console.WriteLine($"Zawodnicy grający na pozycji: {inputPosition}");
            foreach (var player in filteredPlayers)
            {
                Console.WriteLine($"Imie: {player.Name}, Pozycja: {player.Position}, Wynik: {player.Score}");
            }
        }
    }


}





internal class Program
{
    public static void Main(string[] args)
    {
        
        Console.WriteLine("To program do zarządzania drużyną.");
        Console.WriteLine("Wprowadź operacje jaką chcesz dokonąć: add player, delete player, show statistics, average points, find player, modify player, filter player,end");
        string option = Console.ReadLine();
        while (true)
        {

            if (option == "end" || option == "")
            {
                break;
            }

            switch (option)
            {
                case "add player":
                    Console.WriteLine("Proszę podać imie zawodnika");
                    string addName = Console.ReadLine();
                    
                    Console.WriteLine("Proszę podać pozycje zawodnika");
                    string addPosition = Console.ReadLine();
                    
                    Console.WriteLine("Proszę podać wynik zawodnika");
                    string tryAddScore = Console.ReadLine();
                    Team.AddPlayer(addName, addPosition, tryAddScore);
                    break;
                
                case "delete player":
                    Team.DeletePlayer();
                    break;
                
                case "show statistics":
                    Team.ShowStatistics();
                    break;
                
                case "average points":
                    Team.AveragePoints();
                    break;
                
                case "find player":
                    Console.WriteLine("Podaj pozycje jaką chcesz wyszukać: ");
                    Team.FindPlayerByPosition(inputPosition: Console.ReadLine());
                    break;
                
                
                case "modify player":
                    Console.WriteLine("Podaj imie zawodnika: ");
                    ModifyPlayer(inputName: Console.ReadLine());
                    break;
                
                case "filter player":
                    
                    break;
            }
            
            
            Console.WriteLine("Wprowadź operacje jaką chcesz dokonąć: add player, delete player, show statistics, average points, find player, modify player, end (aby zakończyć działanie programu)");
            option = Console.ReadLine();


            void ModifyPlayer(string inputName)
            {
                bool isPlayerExists = Team.playersList.Any(player => player.Name == inputName);

                if (!isPlayerExists)
                {
                    Console.WriteLine($"Nie istnieje taki zawodnik {inputName}. Podaj inne imie zawodnika: ");
                    inputName = Console.ReadLine();
                    ModifyPlayer(inputName);
                }

                else
                {
                    int player = Team.playersList.FindIndex(0, player => player.Name == inputName);
                    while (true)
                    {
                        Console.WriteLine("Podaj jaką co chcesz zmienić: score, position, end (aby zakończyć edycje zawodnika)");
                        string typeOfModificaton = Console.ReadLine();
                        
                        if (typeOfModificaton == "end" || typeOfModificaton == "")
                        {
                            break;
                        }
                        

                        switch (typeOfModificaton) 
                        {
                            case "score":
                                Console.WriteLine("Podaj wynik zawodnika: ");
                                string inputScore = Console.ReadLine();
                                Team.playersList[player].UpdateScore(inputScore);
                                break;


                            case "position":
                                Console.WriteLine("Podaj pozycje zawodnika: ");
                                string inputPosition = Console.ReadLine();
                                Team.playersList[player].ChangePosition(inputPosition);
                                break;
                        }
                    }
                }
            }

        }



    }
        
        
}
