﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.view
{
  class SimpleView : IView
  {
    private const Char playChar = 'p';
    private const Char hitChar = 'h';
    private const Char standChar = 's';
    private const Char quitChar = 'q';

    public void DisplayWelcomeMessage()
    {
      System.Console.Clear();
      System.Console.WriteLine("Hello Black Jack World");
      System.Console.WriteLine($"Type '{playChar}' to Play, '{hitChar}' to Hit, '{standChar}' to Stand or '{quitChar}' to Quit\n");
    }

    public int GetInput()
    {
      return System.Console.In.Read();
    }

    public int IsPlayGame() => playChar;
    public int IsHit() => hitChar;
    public int IsStand() => standChar;
    public int IsQuit() => quitChar;

    public void DisplayCard(model.Card a_card)
    {
      System.Console.WriteLine("{0} of {1}", a_card.GetValue(), a_card.GetColor());
    }

    public void DisplayPlayerHand(IEnumerable<model.Card> a_hand, int a_score)
    {
      DisplayHand("Player", a_hand, a_score);
    }

    public void DisplayDealerHand(IEnumerable<model.Card> a_hand, int a_score)
    {
      DisplayHand("Dealer", a_hand, a_score);
    }

    private void DisplayHand(String a_name, IEnumerable<model.Card> a_hand, int a_score)
    {
      System.Console.WriteLine("{0} Has: ", a_name);
      foreach (model.Card c in a_hand)
      {
        DisplayCard(c);
      }
      System.Console.WriteLine("Score: {0}", a_score);
      System.Console.WriteLine("");
    }

    public void DisplayGameOver(bool a_dealerIsWinner)
    {
      System.Console.Write("GameOver: ");
      if (a_dealerIsWinner)
      {
        System.Console.WriteLine("Dealer Won!");
      }
      else
      {
        System.Console.WriteLine("You Won!");
      }

    }
  }
}
