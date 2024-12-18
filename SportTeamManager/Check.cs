namespace Checker;

public class Check
{
    public static int CheckIsInt(string inputScore)
    {
        while (true)
        {
            bool tryParseScore = int.TryParse(inputScore, out int score);

            if (!tryParseScore)
            {
                Console.WriteLine("Podano nieprawidłowy wynik. Podaj wynik ponownie: ");
                inputScore = Console.ReadLine();
            }
            else
            {
                return score;
                break;
            }
            
        }

    }
}
