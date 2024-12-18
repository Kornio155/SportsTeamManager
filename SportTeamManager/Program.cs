// See https://aka.ms/new-console-template for more information

using System.ComponentModel.Design;
using System.Linq.Expressions;
using System.Runtime.InteropServices.JavaScript;
using System.Xml;
using TeamPlayers;
using Checker;



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
                    var addScore = Check.CheckIsInt(tryAddScore);
                    
                    Team.AddPlayer(addName, addPosition, addScore);
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
                                var score = Check.CheckIsInt(inputScore);
                                Team.playersList[player].UpdateScore(score);
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
