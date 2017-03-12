namespace BlackJack
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text;
  using System.Threading.Tasks;

  /// <summary>
  /// Assigns each suit to a number
  /// </summary>
  public enum Suit
  {
    /// <summary>
    /// Suit of clubs assigned 1
    /// </summary>
    clubs = 1,

    /// <summary>
    /// Suit of dimaonds assigned 2
    /// </summary>
    diamonds,

    /// <summary>
    /// Suit of spades assigned 3
    /// </summary>
    spades,

    /// <summary>
    /// Suit of hearts assigned 4
    /// </summary>
    hearts
  }

  /// <summary>
  /// A class that contains attributes for a card object.
  /// </summary>
  public class Card
  {
    /// <summary>
    /// A variable that holds the cards specific value.
    /// </summary>
    private string cardValue;

    /// <summary>
    /// A variable that holds the cards specific suit.
    /// </summary>
    private Suit suit;

    /// <summary>
    /// A Constructor for the Card class that takes in two 
    /// parameters and assigns those to variables in the class.
    /// </summary>
    /// <param name="cardValue"> The number or value of the card. </param>
    /// <param name="suit"> The suit of the card. </param>
    public Card(string cardValue, Suit suit)
    {
      this.cardValue = cardValue;
      this.suit = suit;
    }

    /// <summary>
    /// Gets and returns the card's value
    /// </summary>
    /// <returns> This method returns the cardValue. </returns>
    public string Get_cardValue()
    {
      return this.cardValue;
    }

    /// <summary>
    /// Gets and returns the card's suit.
    /// </summary>
    /// <returns> A string of the cards suit. </returns>
    public string Get_cardSuit()
    {
      if (this.suit == Suit.clubs)
      {
        return "Clubs";
      }
      else if (this.suit == Suit.diamonds)
      {
        return "Diamonds";
      }
      else if (this.suit == Suit.hearts)
      {
        return "Hearts";
      }
      else
      {
        return "Spades";
      }
    }
  }
}
