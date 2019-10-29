using BlackJack.model;
using BlackJack.model.rules;
using BlackJack.view;

namespace BlackJack.controller
{
  class PlayGame : IObserver
  {
    private Game m_game;
    private IView m_view;

    public PlayGame(Game a_game, IView a_view)
    {
      m_game = a_game;
      m_view = a_view;
      m_game.Subscribe(this);
    }
    public bool Play()
    {
      m_view.DisplayWelcomeMessage();

      m_view.DisplayDealerHand(m_game.GetDealerHand(), m_game.GetDealerScore());
      m_view.DisplayPlayerHand(m_game.GetPlayerHand(), m_game.GetPlayerScore());

      if (m_game.IsGameOver())
      {
        m_view.DisplayGameOver(m_game.IsDealerWinner());
      }

      int input = m_view.GetInput();

      if (input == m_view.IsPlayGame())
      {
        m_game.NewGame();
      }
      else if (input == m_view.IsHit())
      {
        m_game.Hit();
      }
      else if (input == m_view.IsStand())
      {
        m_game.Stand();
      }

      return input != m_view.IsQuit();
    }

    public void Update()
    {
      // System.Threading.Thread.Sleep(1500);
      m_view.DisplayWelcomeMessage();

      m_view.DisplayDealerHand(m_game.GetDealerHand(), m_game.GetDealerScore());
      m_view.DisplayPlayerHand(m_game.GetPlayerHand(), m_game.GetPlayerScore());
    }
  }
}
