namespace TeamPlayers;

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

    public void UpdateScore(int score)
    {
        Score = score;
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
