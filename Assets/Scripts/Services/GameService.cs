
using System;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using Zenject;

public class GameService : IInitializable, IDisposable
{
    public event Action<GameCanvases> ActiveGameCanvas;
    public event Action<int, Animal> PlayerFarmUpdate;
    public readonly int MAX_Players = 4;
    public readonly int MIN_Players = 2;

    [Inject]
    private BankService _bankService;

    public List<Player> players = new List<Player>();

    public int dices = 2;

    public void Initialize()
    {
        ThrowDiceEvent.Event += OnThrowDice;
        BackToMenuButton.Click += OnShowMenu;
        ExchangeMenuButton.Click += OnExchange;
        ChangeSceneButton.Click += OnChangeSceneButton;

        if (SceneManager.GetActiveScene().name == GameScenes.Game.ToString())
        {
            players.Add(new Player("P1"));
            players.Add(new Player("P2"));
        }
    }

    public int GetPlayersCount() => players.Count;

    public void AddPlayer(string name) => players.Add(new Player(name));

    public Player GetPlayer(int number) => players[number];

    private void OnThrowDice() => ActiveGameCanvas?.Invoke(GameCanvases.DiceRoller);

    private void OnShowMenu() => ActiveGameCanvas?.Invoke(GameCanvases.Menu);

    private void OnExchange() => ActiveGameCanvas?.Invoke(GameCanvases.Exchange);

    private void OnChangeSceneButton(string name)
    {
        if (name == GameScenes.Game.ToString())
        {
            _bankService.Reset();
        }
        if (name == GameScenes.Menu.ToString())
        {
            players.Clear();
        }
        SceneManager.LoadScene(name);
    }

    public void Dispose()
    {
        ThrowDiceEvent.Event -= OnThrowDice;
        BackToMenuButton.Click -= OnShowMenu;
        ExchangeMenuButton.Click -= OnExchange;
        ChangeSceneButton.Click -= OnChangeSceneButton;
    }
}

public enum GameScenes
{
    Menu,
    Game
}

public enum GameCanvases
{
    Menu,
    DiceRoller,
    Exchange,
    DefinePlayers
}
