// See https://aka.ms/new-console-template for more information

public class Player
{
    public string name;
    public string position;
    public int score;


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
    public List<string> playersList;


    public void AddPlayer()
    {
        // tworzy nowego zawodnika i dodaje go. Podaje imie, pozycje, początkowy wynik
        // pomysł: metoda AddPlayer wywołuje konstruktor klasy Player tworząc nowego zawodnika po czym dodaje go do listy playerList
        
        // metoda sprawdza czy wszystkie dane zostały wpisane podczas dodawania: 
        // jeśli nie to podaje co trzeba jeszcze podać i wyświetla do tego okno
        
        // program pyta się o pozycje jeśli nic nie zostanie wpisane ma ustawić domyślną pozycje: default position  reserve player
        
    }


    public void DeletePlayer()
    {
        // usuwa zawodnika 
    }

    public void ShowStatistics()
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
        
        
        
        
        
        
    }
}