﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlackJack.model.rules;

namespace BlackJack.model
{
  class Player
  {
    private List<Card> m_hand = new List<Card>();
    private List<IObserver> m_observers = new List<IObserver>();

    public void DealCard(Card a_card)
    {
      m_hand.Add(a_card);
      Notify();
    }

    public IEnumerable<Card> GetHand()
    {
      return m_hand.Cast<Card>();
    }

    public void ClearHand()
    {
      m_hand.Clear();
    }

    public void ShowHand()
    {
      foreach (Card c in GetHand())
      {
        c.Show(true);
      }
    }

    public int CalcScore()
    {
      int[] cardScores = new int[(int)model.Card.Value.Count]
          {2, 3, 4, 5, 6, 7, 8, 9, 10, 10 ,10 ,10, 11};
      int score = 0;

      foreach (Card c in GetHand())
      {
        if (c.GetValue() != Card.Value.Hidden)
        {
          score += cardScores[(int)c.GetValue()];
        }
      }

      if (score > 21)
      {
        foreach (Card c in GetHand())
        {
          if (c.GetValue() == Card.Value.Ace && score > 21)
          {
            score -= 10;
          }
        }
      }

      return score;
    }

    public void Add(IObserver observer)
    {
      m_observers.Add(observer);
    }

    public void Remove(IObserver observer)
    {
      m_observers.Remove(observer);
    }

    public void Notify()
    {
      foreach (var observer in m_observers)
      {
        observer.Update();
      }
    }
  }
}
