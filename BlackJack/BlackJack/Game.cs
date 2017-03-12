namespace BlackJack
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text;
  using System.Threading.Tasks;

  /// <summary>
  /// The main program to connect and assemble the other cs files
  /// </summary>
  public class Game
  {
    /// <summary>
    /// The main function
    /// </summary>
    /// <param name="args"> This method does not return anything</param>
    public static void Main(string[] args)
    {
      //// Creates a new game with two players, deals those players cards and then computes their
      //// current score.
      Deck deck = new Deck();
      deck.CreateDeck();

      //// Gets input from the user and checks to make sure the input is valid or not.
      //// If the input is not valid it asks the user to re enter their input.
      Console.WriteLine("How many players are playing(2-5): ");
      string userInput = Console.ReadLine();
      Console.WriteLine();
      int numPlayers = new int();
      List<Person> players = new List<Person>();

      bool validInput = true;
      while (validInput)
      {
        while (int.TryParse(userInput, out numPlayers) == false)
        {
          Console.WriteLine("Your input was not valid. Please enter a number from 2-5.");
          Console.WriteLine("How many players are playing(2-5)");
          userInput = Console.ReadLine();
          Console.WriteLine();
        }

        if (numPlayers > 5 || numPlayers < 2)
        {
          Console.WriteLine("Your input was not valid. Please enter a number from 2-5.");
          Console.WriteLine("How many players are playing(2-5)");
          userInput = Console.ReadLine();
          Console.WriteLine();
        }
        else
        {
          validInput = false;
        }
      }

      players = AddPlayers(numPlayers);

      // Deals face up card to each player
      foreach (Person player in players)
      {
        player.DealCard(deck);
      }

      // Deals face down card to each player
      foreach (Person player in players)
      {
        player.DealCard(deck);
      }

      // Displays everyones face up card for everyone to see.
      foreach (Person player in players)
      {
        player.DisplayFaceUpCard();
      }

      //// Executes each function involved with a players turn for each player
      foreach (Person player in players)
      {
        player.Turn();
        player.DisplayCards();
        player.Score();
        DisplayFaceUpCards(players);
        player.HitOrStand(deck);
      }

      //// Calculates which player won and displays everyone's final scores.
      WhoWon(players);
      DisplayFinalScores(players);
      ////Creates a new game with two players, deals those players cards and then computes their
      //// current score.

      Console.ReadLine();
    }

    /// <summary>
    /// Figures out which player won the game.
    /// </summary>
    /// <param name="players"> The list of players that are playing the game. </param>
    public static void WhoWon(List<Person> players)
    {
      List<int> finalscore = new List<int>();

      foreach (Person player in players)
      {
        finalscore.Add(player.FinalScore());
      }

      List<int> winners = new List<int>();
      for (int i = 0; i < finalscore.Count(); i++)
      {
        if (finalscore[i] == finalscore.Max() && finalscore.Max() != 0)
        {
          winners.Add(i);
        }
      }

      if (winners.Count() > 1)
      {
        Console.Write("It was a tie between");
        foreach (int winner in winners)
        {
          if (winner == winners.Last())
          {
            Console.WriteLine(" and " + players[winner].Get_playerName());
          }
          else
          {
            Console.Write(" " + players[winner].Get_playerName() + ",");
          }
        }

        Console.WriteLine("\n");
      }
      else if (winners.Count() == 1)
      {
        Console.WriteLine(players[winners[0]].Get_playerName() + " WON!" + "\n");
      }
      else
      {
        Console.WriteLine("Everyone is a loser!" + "\n");
      }
    }

    /// <summary>
    /// Asks the user if they would like to display the face up cards again before
    /// deciding whether or not to hit or stand.
    /// </summary>
    /// <param name="players"> The list of players that are playing the game. </param>
    public static void DisplayFaceUpCards(List<Person> players)
    {
      string faceUpChoice;

      Console.WriteLine("Would you like to display the face up cards again? (Yes or no)");
      faceUpChoice = Console.ReadLine();
      Console.WriteLine("\n");
      if (faceUpChoice == "Yes" || faceUpChoice == "Y" || faceUpChoice == "yes" || faceUpChoice == "y")
      {
        foreach (Person player in players)
        {
          player.DisplayFaceUpCard();
        }

        Console.WriteLine("\n" + "\n" + "\n");
      }
    }

    /// <summary>
    /// Displays the final scores after the winner has been declared.
    /// </summary>
    /// <param name="players"> This list of players that are playing the game. </param>
    public static void DisplayFinalScores(List<Person> players)
    {
      Console.WriteLine("The final scores were: ");
      foreach (Person player in players)
      {
        Console.WriteLine("\t" + player.Get_playerName() + ": " + player.FinalScore());
      }
    }

    /// <summary>
    /// Adds the number of players based on the user's input prior to this function call by asking
    /// the user for the names of each player that is playing the game.
    /// </summary>
    /// <param name="numOfPlayers"> The literal number of players that are playing the game. </param>
    /// <returns> The list of player objects that are playing the game. </returns>
    public static List<Person> AddPlayers(int numOfPlayers)
    {
      List<Person> player = new List<Person>();
      for (int i = 0; i < numOfPlayers; i++)
      {
        Console.WriteLine("Please enter the name of Player " + (i + 1) + ": ");
        string name = Console.ReadLine();
        Console.WriteLine();
        Person person = new Person(name);
        player.Add(person);
      }

      Console.WriteLine("\n" + "\n" + "\n" + "\n" + "\n" + "\n" + "\n" + "\n" + "\n" + "\n" + "\n");

      return player;
    }
  }
}
