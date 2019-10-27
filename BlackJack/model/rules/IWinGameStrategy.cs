namespace BlackJack.model.rules
{
  interface IWinGameStrategy
  {
    bool Winning(Player a_dealer, Player a_player);
  }
}
