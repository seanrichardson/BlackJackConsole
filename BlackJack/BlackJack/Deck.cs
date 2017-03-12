namespace BlackJack
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text;
  using System.Threading.Tasks;

  /// <summary>
  /// A class that holds multiple Card objects
  /// </summary>
  public class Deck
  {
    /// <summary>
    /// List of cards that are available to be dealt out.
    /// </summary>
    private List<Card> listOfCards = new List<Card>();

    /// <summary>
    /// An array of all possible card values.
    /// </summary>
    private string[] cardValue = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace" };

    /// <summary>
    /// An array of all possible suit values.
    /// </summary>
    private Suit[] suit = { Suit.clubs, Suit.diamonds, Suit.hearts, Suit.spades };

    /// <summary>
    /// A list of cards that have been used or dealt to players.
    /// </summary>
    private List<int> usedCards = new List<int>();

    /// <summary>
    /// Creates a new deck of cards to be used in the game.
    /// </summary>
    public void CreateDeck()
    {
      foreach (Suit type in this.suit)
      {
        foreach (string value in this.cardValue)
        {
          Card tempcard = new Card(value, type);
          this.listOfCards.Add(tempcard);
        }
      }
    }

    /// <summary>
    /// Gets a random card from the deck.
    /// </summary>
    /// <returns> Returns the random card. </returns>
    public Card AddCard()
    {
      Random random = new Random();
      int randomNum = random.Next(1, 52);
      bool inList = true;

      if (this.usedCards.Count > 52)
      {
        Console.WriteLine("The deck is empty.");
        return null;
      }

      if (this.usedCards.Count > 0)
      {
        while (inList)
        {
          inList = this.usedCards.Contains(randomNum);

          if (inList)
          {
            randomNum = random.Next(1, 52);
          }
          else
          {
            this.usedCards.Add(randomNum);
            return this.listOfCards[randomNum];
          }
        }
      }
      else
      {
        this.usedCards.Add(randomNum);
        return this.listOfCards[randomNum];
      }

      return null;
    }
  }
}
