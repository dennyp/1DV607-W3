using System.Collections.Generic;
using System.Linq;

namespace BlackJack.model.rules
{
  class Soft17HitStrategy : IHitStrategy
  {
    private const int g_hitLimit = 17;
    private const int targetValueOfHandWithoutAce = 6;
    private const int valueOfAce = 11;

    public bool DoHit(model.Player a_dealer)
    {
      if (a_dealer.CalcScore() == g_hitLimit)
      {
        var hand = a_dealer.GetHand();
        foreach (var card in hand)
        {
          if (card.GetValue() == Card.Value.Ace)
          {
            var remainder = a_dealer.CalcScore() - valueOfAce;
            return IsEqualToTarget(remainder);
          }
        }
        return false;
      }
      else
      {
        return a_dealer.CalcScore() < g_hitLimit;
      }
    }

    private bool IsEqualToTarget(int remainder)
    {
      return remainder == targetValueOfHandWithoutAce;
    }
  }
}
