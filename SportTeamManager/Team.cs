namespace TeamPlayers;
using Checker;
public class Team
{
    public static List<Player> playersList = new List<Player>();


    public static void AddPlayer(string addName, string addPosition, int addScore)
    {
        
        if (addName == "")
        {
            Console.WriteLine("Nie podano imienia zawodnika. Proszę podać imie zawodnika: ");
            addName = Console.ReadLine();
            AddPlayer(addName, addPosition, addScore);

        }

        else if(addPosition == "")
        {
            Console.WriteLine("Nie podano pozycji zawodnika. Proszę podać pozycje: ");
            addPosition = Console.ReadLine();
            AddPlayer(addName, addPosition, addScore);

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


    public static void FilterPlayers(string inputFilter)
    {
        switch (inputFilter)
        {
            case "score":
                Console.Write("Podaj najmniejszy wynik zawodnika: ");
                var lowScoreInput = Console.ReadLine();
                var lowScore = Check.CheckIsInt(lowScoreInput);
                
                Console.Write("Podaj największy wynik zawodnika: ");
                var maxScoreInput = Console.ReadLine();
                var maxScore = Check.CheckIsInt(lowScoreInput);
                break;
            
            case "position":
                break;
            
            case "both":
                break;
            
            default:
                Console.WriteLine("nie wybrano filtrowania.");
                break;
        }
    }

}
