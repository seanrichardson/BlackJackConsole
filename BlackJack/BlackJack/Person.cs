namespace BlackJack
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text;
  using System.Threading.Tasks;

  /// <summary>
  /// A class that holds a person object
  /// </summary>
  public class Person
  {
    /// <summary>
    /// List of Cards in the players hand.
    /// </summary>
    private List<Card> cardsInHand = new List<Card>();

    /// <summary>
    /// Variable that holds the the player's current score. If they have
    /// an Ace in their hand this variable will represent their score if that 
    /// Ace is being valued as 1.
    /// </summary>
    private int score1;

    /// <summary>
    /// Variable that holds the players current score if they have an Ace in their
    /// hand and that Ace is being valued as 11.
    /// </summary>
    private int score2;

    /// <summary>
    /// Variable that stores the player's name.
    /// </summary>
    private string playerName;

    /// <summary>
    /// Variable that stores whether or not the player busts or not.
    /// </summary>
    private bool bust;

    /// <summary>
    /// A Constructor that takes in a player's name and saves that info.
    /// </summary>
    /// <param name="name"> The players name. </param>
    public Person(string name)
    {
      this.playerName = name;
      this.bust = false;
    }

    /// <summary>
    /// Computes the players score and displays it.
    /// </summary>
    public void Score()
    {
      bool ace = false;
      foreach (Card card in this.cardsInHand)
      {
        if (card.Get_cardValue() == "Ace")
        {
          ace = true;
        }
      }

      if (ace == true)
      {
        int currentscore = this.CurrentScore();
        if (currentscore == this.score1)
        {
          Console.WriteLine(this.playerName + "'s current score is: " + this.score1);
          Console.WriteLine("\n" + "\n" + "\n" + "\n");
        }
        else if (this.score1 > currentscore)
        {
          Console.WriteLine(this.playerName + "'s current score is: " + currentscore);
          Console.WriteLine("\n" + "\n" + "\n");
        }
        else
        {
          Console.Write(this.playerName + "'s current score is either: " + this.score1);
          Console.WriteLine(" or " + this.score2 + "\n");
          Console.WriteLine("\n" + "\n" + "\n");
        }
      }
      else
      {
        Console.WriteLine(this.playerName + "'s current score is: " + this.CurrentScore() + "\n");
        Console.WriteLine("\n" + "\n" + "\n");
      }
    }

    /// <summary>
    /// Computes the player's current score based on the 
    /// cards they have in their hand.
    /// </summary>
    /// <returns> This method returns the players current score. </returns>
    public int CurrentScore()
    {
      this.score1 = 0;
      this.score2 = 0;
      foreach (Card card in this.cardsInHand)
      {
        if (card.Get_cardValue() == "Jack" || card.Get_cardValue() == "Queen")
        {
          this.score1 += 10;
          this.score2 += 10;
        }
        else if (card.Get_cardValue() == "King")
        {
          this.score1 += 10;
          this.score2 += 10;
        }
        else if (card.Get_cardValue() == "Ace")
        {
          this.score2 += 11;
          this.score1 += 1;
        }
        else
        {
          this.score1 += int.Parse(card.Get_cardValue());
          this.score2 += int.Parse(card.Get_cardValue());
        }
      }

      if (this.score2 <= 21 && this.score2 >= 2)
      {
        return this.score2;
      }
      else if (this.score1 <= 21 && this.score1 > 2)
      {
        return this.score1;
      }
      else
      {
        Console.WriteLine("\t" + "\n" + "BUST");
        this.bust = true;
        return 0;
      }
    }

    /// <summary>
    /// Computes the final score of this player.
    /// </summary>
    /// <returns> The players final score. </returns>
    public int FinalScore()
    {
      if (this.bust == true)
      {
        return 0;
      }
      else
      {
        if (this.score2 <= 21 && this.score2 > 2)
        {
          return this.score2;
        }
        else if (this.score1 <= 21 && this.score1 > 2)
        {
          return this.score1;
        }
      }

      return 0;
    }

    /// <summary>
    /// Adds a card obtained from the deck to the players hand.
    /// </summary>
    /// <param name="deck"> The deck from which the card will be dealt. </param>
    public void DealCard(Deck deck)
    {
      this.cardsInHand.Add(deck.AddCard());
    }

    /// <summary>
    /// Displays each players face up card only.
    /// </summary>
    public void DisplayFaceUpCard()
    {
      Console.WriteLine(this.playerName + "'s face up card is:");
      Console.Write("\t" + this.cardsInHand[0].Get_cardValue() + " of ");
      Console.WriteLine(this.cardsInHand[0].Get_cardSuit());
      Console.WriteLine();
    }

    /// <summary>
    /// Prints out the cards that are in the player's hand to the screen
    /// </summary>
    public void DisplayCards()
    {
      Console.WriteLine(this.playerName + "'s cards:\n");
      foreach (Card card in this.cardsInHand)
      {
        Console.Write("\t" + card.Get_cardValue() + " of ");
        Console.WriteLine(card.Get_cardSuit());
      }
    }

    /// <summary>
    /// Instructs the user's which players turn it is. Tells the player to press enter when they are
    /// ready to contiune and then prints 22 new lines to the screen to basically clear the console.
    /// And hide any info about the other players cards.
    /// </summary>
    public void Turn()
    {
      Console.WriteLine("\n" + "\n" + "\n");
      Console.WriteLine("It is " + this.playerName + "'s turn. Press enter to continue.");
      Console.ReadLine();
      Console.WriteLine("\n" + "\n" + "\n" + "\n" + "\n" + "\n" + "\n" + "\n" + "\n" + "\n" + "\n");
      Console.WriteLine("\n" + "\n" + "\n" + "\n" + "\n" + "\n" + "\n" + "\n" + "\n" + "\n" + "\n");
    }

    /// <summary>
    /// Asks the user if they would like another card or not. If they decide to take another card
    /// it computes their new score.
    /// </summary>
    /// <param name="deck"> The deck that is being used for this game. </param>
    public void HitOrStand(Deck deck)
    {
      bool input = true;
      string hitChoice;

      while (input)
      {
        if (this.score1 > 21 && this.score2 > 21)
        {
          hitChoice = "no";
        }
        else
        {
          Console.WriteLine(this.playerName + " would you like a card? (Yes or No)");
          hitChoice = Console.ReadLine();
          Console.WriteLine("\n" + "\n" + "\n");
        }

        if (hitChoice == "Yes" || hitChoice == "Y" || hitChoice == "yes" || hitChoice == "y")
        {
          this.DealCard(deck);
          this.DisplayCards();
          this.Score();
        }
        else
        {
          input = false;
        }
      }

      Console.WriteLine("Press enter when you are finished with your turn to clear the screen.");
      Console.ReadLine();
      Console.WriteLine("\n" + "\n" + "\n" + "\n" + "\n" + "\n" + "\n" + "\n" + "\n" + "\n" + "\n");
      Console.WriteLine("\n" + "\n" + "\n" + "\n" + "\n" + "\n" + "\n" + "\n" + "\n" + "\n" + "\n");
    }

    /// <summary>
    /// Gets and returns the players name.
    /// </summary>
    /// <returns> The players name. </returns>
    public string Get_playerName()
    {
      return this.playerName;
    }
  }
}
