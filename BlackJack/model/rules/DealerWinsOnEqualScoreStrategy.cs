namespace BlackJack.model.rules
{
  class DealerWinsOnEqualScoreStrategy : IWinGameStrategy
  {
    public bool Winning(Player a_dealer, Player a_player)
    {
      return a_dealer.CalcScore() >= a_player.CalcScore();
    }
  }
}
