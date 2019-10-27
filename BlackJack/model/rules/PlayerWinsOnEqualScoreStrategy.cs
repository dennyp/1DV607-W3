namespace BlackJack.model.rules
{
  class PlayerWinsOnEqualScoreStrategy : IWinGameStrategy
  {
    public bool Winning(Player a_dealer, Player a_player)
    {
      return a_dealer.CalcScore() > a_player.CalcScore();
    }
  }
}
